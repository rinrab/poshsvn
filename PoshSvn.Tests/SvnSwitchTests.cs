﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System.IO;
using NUnit.Framework;
using PoshSvn.CmdLets;
using PoshSvn.Tests.TestUtils;

namespace PoshSvn.Tests
{
    public class SvnSwitchTests
    {
        [Test]
        public void BasicTest()
        {
            using (var sb = new ProjectStructureSandbox())
            {
                sb.RunScript($@"svn-copy '{sb.ReposUrl}/trunk' '{sb.ReposUrl}/branches/test' -m branch");
                sb.RunScript($@"svn-mkdir wc-trunk\a");
                sb.RunScript($@"svn-commit wc-trunk -m test");
                sb.RunScript($@"svn-mkdir '{sb.ReposUrl}/branches/test/b' -m test");

                var actual = sb.RunScript($@"svn-switch '{sb.ReposUrl}/branches/test' wc-trunk");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateDelete, Path = Path.Combine(sb.TrunkPath, "a") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateAdd, Path = Path.Combine(sb.TrunkPath, "b") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateUpdate, Path = Path.Combine(sb.TrunkPath) },
                        new SvnSwitchOutput { Revision = 4 },
                    },
                    actual);
            }
        }

        [Test]
        public void ToRevisionTest()
        {
            using (var sb = new ProjectStructureSandbox())
            {
                sb.RunScript($@"svn-copy '{sb.ReposUrl}/trunk' '{sb.ReposUrl}/branches/test' -m branch");
                sb.RunScript($@"svn-mkdir wc-trunk\a");
                sb.RunScript($@"svn-commit wc-trunk -m test");
                sb.RunScript($@"svn-mkdir '{sb.ReposUrl}/branches/test/b' -m test");

                var actual = sb.RunScript($@"svn-switch '{sb.ReposUrl}/branches/test' wc-trunk -rev 3");

                PSObjectAssert.AreEqual(
                    new object[]
                    {
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateDelete, Path = Path.Combine(sb.TrunkPath, "a") },
                        new SvnNotifyOutput { Action = SharpSvn.SvnNotifyAction.UpdateUpdate, Path = Path.Combine(sb.TrunkPath) },
                        new SvnSwitchOutput { Revision = 3 },
                    },
                    actual);
            }
        }
    }
}