﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;

namespace PoshSvn.Common.Tests
{
    public class PegRevisionParserTests
    {
        [Test]
        public void ParsePegRevisionTargetTest1()
        {
            PegRevision.Parse(@"C:\path\to\file", out var remainingTarget, out var revision);
            ClassicAssert.AreEqual(@"C:\path\to\file", remainingTarget);
            ClassicAssert.AreEqual(null, revision);
        }

        [Test]
        public void ParsePegRevisionTargetTest2()
        {
            PegRevision.Parse(@"C:\path\to\file@123", out var remainingTarget, out var revision);
            ClassicAssert.AreEqual(@"C:\path\to\file", remainingTarget);
            ClassicAssert.AreEqual(new SvnRevision("123"), revision);
        }

        [Test]
        public void ParsePegRevisionTargetTest3()
        {
            PegRevision.Parse(@"http://svn.example.com/svn/repo/trunk/test.txt@HEAD", out var remainingTarget, out var revision);
            ClassicAssert.AreEqual(@"http://svn.example.com/svn/repo/trunk/test.txt", remainingTarget);
            ClassicAssert.AreEqual(new SvnRevision("HEAD"), revision);
        }

        [Test]
        public void ParsePegRevisionTargetTest4()
        {
            Assert.Throws<ArgumentException>(() => PegRevision.Parse(
                @"http://svn.example.com/svn/repo/trunk/test.txt@the_incorrect_revision",
                out var remainingTarget,
                out var revision));
        }

        [Test]
        [Ignore("TODO:")]
        public void NotPegRevisionTest()
        {
            PegRevision.Parse(@"C:\path\to\file\@not-peg-rev\test.txt@123", out var remainingTarget, out var revision);
            ClassicAssert.AreEqual(@"C:\path\to\file\@not-peg-rev", remainingTarget);
            ClassicAssert.AreEqual(new SvnRevision("123"), revision);
        }

        [Test]
        [Ignore("TODO:")]
        public void NotPegRevisionTestNoPegRevision()
        {
            PegRevision.Parse(@"C:\path\to\file\@not-peg-rev\test.txt", out var remainingTarget, out var revision);
            ClassicAssert.AreEqual(@"C:\path\to\file\@not-peg-rev", remainingTarget);
            ClassicAssert.AreEqual(null, revision);
        }
    }
}
