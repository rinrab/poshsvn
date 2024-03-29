﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using NUnit.Framework;
using PoshSvn.Tests.TestUtils;

namespace PoshSvn.Tests
{
    public class SvnDiffCmdletTests
    {
        [Test]
        public void BasicTest()
        {
            using (var sb = new WcSandbox())
            {
                var forwardSlashWcPath = sb.WcPath.Replace('\\', '/');

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2,line3");
                sb.RunScript(@"svn-add wc\a.txt");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,'modified line2',line3");
                var actual = sb.RunScript(@"svn-diff wc\a.txt");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        $@"Index: {forwardSlashWcPath}/a.txt",
                        $@"===================================================================",
                        $@"--- {forwardSlashWcPath}/a.txt	(revision 1)",
                        $@"+++ {forwardSlashWcPath}/a.txt	(working copy)",
                        $@"@@ -1,3 +1,3 @@",
                        $@" line1",
                        $@"-line2",
                        $@"+modified line2",
                        $@" line3",

                    },
                    actual);
            }
        }

        [Test]
        public void OldNewTest()
        {
            using (var sb = new WcSandbox())
            {
                var forwardSlashRootPath = sb.RootPath.Replace('\\', '/');

                sb.RunScript(@"Set-Content -Path a.txt -Value line1,line2,line3");
                sb.RunScript(@"Set-Content -Path b.txt -Value line1,'modified line2',line3");
                var actual = sb.RunScript(@"svn-diff -Old a.txt -New b.txt");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        $@"Index: a.txt",
                        $@"===================================================================",
                        $@"--- a.txt	(.../a.txt)	(working copy)",
                        $@"+++ a.txt	(.../b.txt)	(working copy)",
                        $@"@@ -1,3 +1,3 @@",
                        $@" line1",
                        $@"-line2",
                        $@"+modified line2",
                        $@" line3",

                    },
                    actual);
            }
        }
    }
}
