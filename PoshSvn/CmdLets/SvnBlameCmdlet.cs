﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System.Linq;
using System.Management.Automation;
using SharpSvn;

namespace PoshSvn.CmdLets
{
    [Cmdlet("Invoke", "SvnBlame")]
    [Alias("svn-blame")]
    [OutputType(typeof(SvnBlameLine))]
    public class SvnBlameCmdlet : SvnClientCmdletBase
    {
        [Parameter(Position = 0)]
        public SvnTarget Target { get; set; }

        [Parameter()]
        [Alias("rev", "r")]
        public PoshSvnRevisionRange Revision { get; set; }

        [Parameter()]
        public SwitchParameter RetrieveMergedRevisions { get; set; }

        [Parameter()]
        public SwitchParameter IgnoreMimeType { get; set; }

        [Parameter()]
        public SwitchParameter IgnoreLineEndings { get; set; }

        [Parameter()]
        public SvnIgnoreSpacing IgnoreSpacing { get; set; } = SvnIgnoreSpacing.None;

        protected override void Execute()
        {
            SvnBlameArgs args = new SvnBlameArgs
            {
                Range = Revision?.ToSharpSvnRevisionRange(),
                RetrieveMergedRevisions = RetrieveMergedRevisions,
                IgnoreMimeType = IgnoreMimeType,
                IgnoreLineEndings = IgnoreLineEndings,
                IgnoreSpacing = IgnoreSpacing.ToSharpSvnIgnoreSpacing(),
            };

            SharpSvn.SvnTarget target = TargetCollection.ConvertTargetToSvnTarget(GetTarget(Target));

            SvnClient.Blame(target, args, Blamer);
        }

        private void Blamer(object sender, SvnBlameEventArgs e)
        {
            WriteObject(new SvnBlameLine
            {
                Revision = e.Revision,
                Author = e.Author,
                Line = e.Line,

                LineNumber = e.LineNumber,
                EndRevision = e.EndRevision,
                LocalChange = e.LocalChange,
                Time = e.Time,
                MergedTime = e.MergedTime,
                MergedAuthor = e.MergedAuthor,
                MergedPath = e.MergedPath,
                MergedRevision = e.MergedRevision,
                MergedRevisionProperties = e.MergedRevisionProperties?.ToArray(),
            });
        }
    }
}
