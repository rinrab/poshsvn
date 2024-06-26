﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System.IO;
using NUnit.Framework;
using PoshSvn.Tests.TestUtils;

namespace PoshSvn.Tests
{
    public class SvnPropgetCmdletTests
    {
        [Test]
        public void SimpleTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"svn-propset name value wc\test");

                var actual = sb.RunScript(@"svn-propget name wc\test");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value",
                            Path = Path.Combine(sb.WcPath, "test"),
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void RevisionTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-propset name value1 wc");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"svn-propset name value2 wc");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"svn-propset name value3 wc");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript(@"svn-proplist wc -r 2");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value2",
                            Path = sb.ReposUrl.Replace('/', '\\'), // Little bug in Subversion
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void UrlRevisionTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-propset name value1 wc");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"svn-propset name value2 wc");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"svn-propset name value3 wc");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript($@"svn-proplist {sb.ReposUrl} -r 2");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value2",
                            Path = sb.ReposUrl,
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void UrlPegRevisionTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-propset name value1 wc");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"svn-propset name value2 wc");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"svn-propset name value3 wc");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript($@"svn-proplist {sb.ReposUrl}@2");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value2",
                            Path = sb.ReposUrl,
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void RevporopBasicTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript($@"svn-propget svn:log {sb.ReposUrl} -Revprop -Revision 1");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "svn:log",
                            Path = sb.ReposUrl,
                            Value = "test"
                        },
                    },
                    actual);
            }
        }

        [Test]
        public void RevporopByPathTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript($@"svn-propget svn:log wc -Revprop -Revision 1");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "svn:log",
                            Path = sb.ReposUrl + "/",
                            Value = "test"
                        },
                    },
                    actual);
            }
        }

        [Test]
        public void RevporopByCurrentDirectoryTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript($@"cd wc; svn-propget svn:log -Revprop -Revision 1");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "svn:log",
                            Path = sb.ReposUrl + "/",
                            Value = "test"
                        },
                    },
                    actual);
            }
        }

        [Test]
        public void RemoteTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"svn-propset name value wc\test");
                sb.RunScript(@"svn-commit wc -m 'setup props'");

                var actual = sb.RunScript($@"svn-propget name {sb.ReposUrl}/test");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value",
                            Path = $"{sb.ReposUrl}/test",
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void NonExistingTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"svn-propset name value wc\test");
                sb.RunScript(@"svn-commit wc -m 'setup props'");

                var actual = sb.RunScript($@"svn-propget non-existing {sb.ReposUrl}/test");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                    },
                    actual);
            }
        }

        [Test]
        public void RemoteManyRecurseTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\Project1");
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-propset svn:ignore ""bin`nobj`n.vs`n"" wc");
                sb.RunScript(@"svn-propset 'svn:mergeinfo' '/subversion/branches/resolve-incoming-add:1762797-1764284' wc");
                sb.RunScript(@"svn-propset svn:ignore ""bin`nobj`n.vs`nx64`nx86"" wc\Project1");
                sb.RunScript(@"svn-propset foo 'this is a foo value!!' wc\test");
                sb.RunScript(@"svn-propset bar 'this is a bar value!!1!' wc\test");

                sb.RunScript(@"svn-commit wc -m 'setup props'");

                var actual = sb.RunScript($@"svn-propget svn:ignore {sb.ReposUrl} -Depth Infinity | Sort-Object -Property Path");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "svn:ignore",
                            Value = "bin\r\nobj\r\n.vs\r\n",
                            Path = $"{sb.ReposUrl}",
                        },
                        new SvnProperty
                        {
                            Name = "svn:ignore",
                            Value = "bin\r\nobj\r\n.vs\r\nx64\r\nx86\r\n",
                            Path = $"{sb.ReposUrl}/Project1",
                        },
                    },
                    actual);
            }
        }

        [Test]
        public void FromCurrentDirectoryTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"svn-propset name value wc\test");

                var actual = sb.RunScript(@"cd wc\test; svn-propget name");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value",
                            Path = Path.Combine(sb.WcPath, "test"),
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void NotExistingTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\test");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"svn-propset name value wc\test");

                var actual = sb.RunScript(@"svn-propget not-exiting wc\test");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                    },
                    actual);
            }
        }

        [Test]
        public void ManyTargetsTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"svn-mkdir wc\dir1");
                sb.RunScript(@"svn-mkdir wc\dir2");
                sb.RunScript(@"svn-mkdir wc\dir3");
                sb.RunScript(@"svn-commit wc -m test");
                sb.RunScript(@"svn-propset name value wc\dir1 wc\dir2");
                sb.RunScript(@"svn-propset name valueqq wc\dir3");

                var actual = sb.RunScript(@"svn-propget name wc\dir1 wc\dir2 wc\dir3");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value",
                            Path = Path.Combine(sb.WcPath, "dir1"),
                        },
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "value",
                            Path = Path.Combine(sb.WcPath, "dir2"),
                        },
                        new SvnProperty
                        {
                            Name = "name",
                            Value = "valueqq",
                            Path = Path.Combine(sb.WcPath, "dir3"),
                        },
                    },
                    actual);
            }
        }
    }
}
