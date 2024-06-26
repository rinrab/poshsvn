﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using PoshSvn.Tests.TestUtils;

namespace PoshSvn.Tests
{
    public class SvnBlameCmdletTests
    {
        [Test]
        public void BasicTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2");
                sb.RunScript(@"svn-add wc\a.txt");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2,line3");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,'modified line2',line3");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript(@"svn-blame wc\a.txt");

                PSObjectAssert.AreEqual(
                    new[]
                    {
                        new SvnBlameLine
                        {
                            Revision = 1,
                            EndRevision = 3,
                            LineNumber = 0,
                            Line = "line1",
                        },
                        new SvnBlameLine
                        {
                            Revision = 3,
                            EndRevision = 3,
                            LineNumber = 1,
                            Line = "modified line2"
                        },
                        new SvnBlameLine
                        {
                            Revision = 2,
                            EndRevision = 3,
                            LineNumber = 2,
                            Line = "line3"
                        },
                    },
                    actual,
                    nameof(SvnBlameLine.Author),
                    nameof(SvnBlameLine.Time));
            }
        }

        [Test]
        public void FormatListTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2");
                sb.RunScript(@"svn-add wc\a.txt");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2,line3");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,'modified line2',line3");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.FormatObject(
                    new[]
                    {
                        new SvnBlameLine
                        {
                            Revision = 1,
                            LineNumber = 0,
                            Line = "line1",
                            Author = "sally",
                            Time = DateTime.Parse("5/5/2024 11:39:18 AM")
                        },
                        new SvnBlameLine
                        {
                            Revision = 3,
                            LineNumber = 1,
                            Line = "modified line2",
                            Author = "harry",
                            Time = DateTime.Parse("5/5/2024 11:39:18 AM")
                        },
                        new SvnBlameLine
                        {
                            Revision = 2,
                            LineNumber = 2,
                            Line = "line3",
                            Author = "sally",
                            Time = DateTime.Parse("5/5/2024 11:39:18 AM")
                        },
                        new SvnBlameLine
                        {
                            Revision = 5,
                            LineNumber = 3,
                            Line = "line4",
                            Author = "John.Doe",
                            Time = DateTime.Parse("5/5/2024 11:39:18 AM")
                        },
                        new SvnBlameLine
                        {
                            Revision = 5,
                            LineNumber = 4,
                            Line = "line5",
                            Author = "John.Doe",
                            Time = DateTime.Parse("5/5/2024 11:39:18 AM")
                        },
                    },
                    "Format-List");

                CollectionAssert.AreEqual(
                    new object[]
                    {
                        "",
                        "",
                        "Revision           : 1",
                        "Author             : sally",
                        "Line               : line1",
                        "RevisionProperties :",
                        "LocalChange        : False",
                        "Time               : 5/5/2024 11:39:18 AM",
                        "LineNumber         : 0",
                        "EndRevision        : 0",
                        "StartRevision      : 0",
                        "",
                        "Revision           : 3",
                        "Author             : harry",
                        "Line               : modified line2",
                        "RevisionProperties :",
                        "LocalChange        : False",
                        "Time               : 5/5/2024 11:39:18 AM",
                        "LineNumber         : 1",
                        "EndRevision        : 0",
                        "StartRevision      : 0",
                        "",
                        "Revision           : 2",
                        "Author             : sally",
                        "Line               : line3",
                        "RevisionProperties :",
                        "LocalChange        : False",
                        "Time               : 5/5/2024 11:39:18 AM",
                        "LineNumber         : 2",
                        "EndRevision        : 0",
                        "StartRevision      : 0",
                        "",
                        "Revision           : 5",
                        "Author             : John.Doe",
                        "Line               : line4",
                        "RevisionProperties :",
                        "LocalChange        : False",
                        "Time               : 5/5/2024 11:39:18 AM",
                        "LineNumber         : 3",
                        "EndRevision        : 0",
                        "StartRevision      : 0",
                        "",
                        "Revision           : 5",
                        "Author             : John.Doe",
                        "Line               : line5",
                        "RevisionProperties :",
                        "LocalChange        : False",
                        "Time               : 5/5/2024 11:39:18 AM",
                        "LineNumber         : 4",
                        "EndRevision        : 0",
                        "StartRevision      : 0",
                        "",
                        "",
                        "",
                    },
                    actual);
            }
        }

        [Test]
        public void RevisionRangeTest()
        {
            using (var sb = new WcSandbox())
            {
                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2");
                sb.RunScript(@"svn-add wc\a.txt");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,line2,line3");
                sb.RunScript(@"svn-commit wc -m test");

                sb.RunScript(@"Set-Content -Path wc\a.txt -Value line1,'modified line2',line3");
                sb.RunScript(@"svn-commit wc -m test");

                var actual = sb.RunScript(@"svn-blame wc\a.txt -r 1:2");

                PSObjectAssert.AreEqual(
                    new[]
                    {
                        new SvnBlameLine
                        {
                            Revision = 1,
                            EndRevision = 2,
                            LineNumber = 0,
                            Line = "line1",
                        },
                        new SvnBlameLine
                        {
                            Revision = 1,
                            EndRevision = 2,
                            LineNumber = 1,
                            Line = "line2"
                        },
                        new SvnBlameLine
                        {
                            Revision = 2,
                            EndRevision = 2,
                            LineNumber = 2,
                            Line = "line3"
                        },
                    },
                    actual,
                    nameof(SvnBlameLine.Author),
                    nameof(SvnBlameLine.Time));
            }
        }

        [Test]
        public void FormatTest()
        {
            using (var sb = new PowerShellSandbox())
            {
                var actual = sb.FormatObject(
                    new[]
                    {
                        new SvnBlameLine
                        {
                            Revision = 1,
                            LineNumber = 0,
                            Line = "line1",
                            Author = "sally",
                        },
                        new SvnBlameLine
                        {
                            Revision = 3,
                            LineNumber = 1,
                            Line = "modified line2",
                            Author = "harry"
                        },
                        new SvnBlameLine
                        {
                            Revision = 2,
                            LineNumber = 2,
                            Line = "line3",
                            Author = "sally"
                        },
                        new SvnBlameLine
                        {
                            Revision = 5,
                            LineNumber = 3,
                            Line = "line4",
                            Author = "John.Doe"
                        },
                        new SvnBlameLine
                        {
                            Revision = 5,
                            LineNumber = 4,
                            Line = "line5",
                            Author = "John.Doe"
                        },
                    },
                    "Format-Custom");

                CollectionAssert.AreEqual(
                    new string[]
                    {
                        "",
                        "       r1 sally            line1",
                        "       r3 harry            modified line2",
                        "       r2 sally            line3",
                        "       r5 John.Doe         line4",
                        "       r5 John.Doe         line5",
                        "",
                        "",
                    },
                    actual);
            }
        }

        [Test]
        public void FormatTableTest()
        {
            using (var sb = new PowerShellSandbox())
            {
                var actual = sb.FormatObject(
                    new[]
                    {
                        new SvnBlameLine
                        {
                            Revision = 1,
                            LineNumber = 0,
                            Line = "line1",
                            Author = "sally",
                        },
                        new SvnBlameLine
                        {
                            Revision = 3,
                            LineNumber = 1,
                            Line = "modified line2",
                            Author = "harry"
                        },
                        new SvnBlameLine
                        {
                            Revision = 2,
                            LineNumber = 2,
                            Line = "line3",
                            Author = "sally"
                        },
                        new SvnBlameLine
                        {
                            Revision = 5,
                            LineNumber = 3,
                            Line = "line4",
                            Author = "John.Doe"
                        },
                        new SvnBlameLine
                        {
                            Revision = 5,
                            LineNumber = 4,
                            Line = "line5",
                            Author = "John.Doe"
                        },
                    },
                    "Format-Table");

                CollectionAssert.AreEqual(
                    new string[]
                    {
                        "",
                        "Revision Author           Line",
                        "-------- ------           ----",
                        "       1 sally            line1",
                        "       3 harry            modified line2",
                        "       2 sally            line3",
                        "       5 John.Doe         line4",
                        "       5 John.Doe         line5",
                        "",
                        "",
                    },
                    actual);
            }
        }
    }
}
