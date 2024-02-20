﻿using System.IO;
using NUnit.Framework;
using PoshSvn.CmdLets;
using PoshSvn.Tests.TestUtils;

namespace PoshSvn.Tests
{
    public class SvnMoveTests
    {
        [Test]
        public void MoveNotCommittedNode()
        {
            using (var sb = new WcSandbox())
            {
                var actual = sb.RunScript(
                    @"svn-mkdir wc\src",
                    @"svn-move wc\src wc\dst");

                PSObjectAssert.AreEqual(
                    new SvnMoveOutput[]
                    {
                        new SvnMoveOutput
                        {
                            Action = SharpSvn.SvnNotifyAction.Add,
                            Path = Path.Combine(sb.WcPath, "dst")
                        },
                        new SvnMoveOutput
                        {
                            Action = SharpSvn.SvnNotifyAction.Delete,
                            Path = Path.Combine(sb.WcPath, "src")
                        },
                    },
                    actual);

                actual = sb.RunScript("svn-status wc");

                PSObjectAssert.AreEqual(
                    new SvnLocalStatusOutput[]
                    {
                        new SvnLocalStatusOutput
                        {
                            LocalNodeStatus = SharpSvn.SvnStatus.Added,
                            Path = Path.Combine(sb.WcPath, "dst"),
                            LocalTextStatus = SharpSvn.SvnStatus.Normal,
                            Versioned = true,
                            Conflicted = false,
                            LocalCopied = false,
                        }
                    },
                    actual);
            }
        }

        [Test]
        public void MoveCommittedNode()
        {
            using (var sb = new WcSandbox())
            {
                var actual = sb.RunScript(
                    @"svn-mkdir wc\src",
                    @"svn-commit wc -m 'test'",
                    @"svn-move wc\src wc\dst");

                PSObjectAssert.AreEqual(
                    new SvnMoveOutput[]
                    {
                        new SvnMoveOutput
                        {
                            Action = SharpSvn.SvnNotifyAction.Add,
                            Path = Path.Combine(sb.WcPath, "dst")
                        },
                        new SvnMoveOutput
                        {
                            Action = SharpSvn.SvnNotifyAction.Delete,
                            Path = Path.Combine(sb.WcPath, "src")
                        },
                    },
                    actual);

                actual = sb.RunScript("svn-status wc");

                PSObjectAssert.AreEqual(
                    new SvnLocalStatusOutput[]
                    {
                        new SvnLocalStatusOutput
                        {
                            LocalNodeStatus = SharpSvn.SvnStatus.Added,
                            Path = Path.Combine(sb.WcPath, "dst"),
                            LocalTextStatus = SharpSvn.SvnStatus.Normal,
                            Versioned = true,
                            Conflicted = false,
                            LocalCopied = true,
                            LastChangedRevision = 1,
                        },
                        new SvnLocalStatusOutput
                        {
                            LocalNodeStatus = SharpSvn.SvnStatus.Deleted,
                            Path = Path.Combine(sb.WcPath, "src"),
                            LocalTextStatus = SharpSvn.SvnStatus.Normal,
                            Versioned = true,
                            Conflicted = false,
                            LocalCopied = false,
                        }
                    },
                    actual,
                    nameof(SvnLocalStatusOutput.LastChangedAuthor),
                    nameof(SvnLocalStatusOutput.LastChangedTime));
            }
        }

        [Test]
        public void FormatTest()
        {
            using (var sb = new WcSandbox())
            {
                var actual = sb.RunScript(
                    @"svn-mkdir wc\src",
                    @"$out = svn-move wc\src wc\dst",
                    @"($out | Out-String -Stream).TrimEnd()");

                PSObjectAssert.AreEqual(
                    new string[]
                    {
                        $@"",
                        $@"Action  Path",
                        $@"------  ----",
                        $@"A       wc\dst",
                        $@"D       wc\src",
                        "",
                        "",
                    },
                    actual);
            }
        }
    }
}
