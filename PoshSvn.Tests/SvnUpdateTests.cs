﻿using NUnit.Framework;
using NUnit.Framework.Legacy;
using PoshSvn.CmdLets;
using PoshSvn.Tests.TestUtils;
using System.IO;

namespace PoshSvn.Tests
{
    public class SvnUpdateTests
    {
        [Test]
        public void CheckoutOutputTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"1..3 | foreach { svn-mkdir wc\$_; svn-commit wc -m 'init' }");

                var actual = sb.RunScript($"svn-checkout '{sb.ReposUrl}' wc2");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateAdd, Path = Path.Combine(sb.RootPath, @"wc2\1") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateAdd, Path = Path.Combine(sb.RootPath, @"wc2\2") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateAdd, Path = Path.Combine(sb.RootPath, @"wc2\3") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateUpdate, Path = Path.Combine(sb.RootPath, @"wc2") },
                        new SvnCheckoutOutput { Revision = 3 },
                    },
                    actual);
            }
        }

        [Test]
        public void UpdateOutputTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"1..3 | foreach { svn-mkdir wc\$_; svn-commit wc -m 'init' }");
                sb.RunScript($"svn-checkout '{sb.ReposUrl}' wc2");

                var actual = sb.RunScript("svn-update wc2 -r 2");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateDelete, Path = Path.Combine(sb.RootPath, @"wc2\3") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateUpdate, Path = Path.Combine(sb.RootPath, @"wc2") },
                        new SvnUpdateOutput { Revision = 2 },
                    },
                    actual);
            }
        }
    }
}