﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System.Collections.Generic;
using System.Management.Automation;

namespace PoshSvn.CmdLets
{
    [Cmdlet("Invoke", "SvnMerge")]
    [Alias("svn-merge")]
    [OutputType(typeof(SvnNotifyAction))]
    public class SvnMergeCmdlet : SvnClientCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true)]
        public SvnTarget Source { get; set; }

        [Parameter(Position = 1)]
        [PSDefaultValue(Value = ".")]
        public string Path { get; set; } = ".";

        [Parameter(Position = 2)]
        [Alias("rev")]
        [PSDefaultValue(Value = null)]
        public SvnRevisionRange[] Revision { get; set; } = null;

        [Parameter()]
        public SvnDepth Depth { get; set; } = SvnDepth.Infinity;

        [Parameter()]
        public SwitchParameter Force { get; set; }

        [Parameter()]
        public SwitchParameter DryRun { get; set; }

        [Parameter()]
        public SwitchParameter RecordOnly { get; set; }

        [Parameter()]
        public SwitchParameter IgnoreAncestry { get; set; }

        [Parameter()]
        public SwitchParameter AllowMixedRevisions { get; set; }

        protected override void Execute()
        {
            SvnResolvedTarget source = ResolveTarget(Source);

            string path = GetUnresolvedProviderPathFromPSPath(Path);

            SharpSvn.SvnMergeArgs args = new SharpSvn.SvnMergeArgs
            {
                Depth = Depth.ConvertToSharpSvnDepth(),
                Force = Force,
                DryRun = DryRun,
                RecordOnly = RecordOnly,
                IgnoreAncestry = IgnoreAncestry,
                CheckForMixedRevisions = !AllowMixedRevisions,
            };

            SvnClient.Merge(path, source.ConvertToSharpSvnTarget(), GetRange(), args);
        }

        private ICollection<SharpSvn.SvnRevisionRange> GetRange()
        {
            if (Revision == null)
            {
                return null;
            }
            else
            {
                List<SharpSvn.SvnRevisionRange> ranges = new List<SharpSvn.SvnRevisionRange>();

                foreach (SvnRevisionRange revision in Revision)
                {
                    ranges.Add(revision?.ToSharpSvnRevisionRange());
                }

                return ranges;
            }
        }

        protected override string GetProcessTitle() => "Merging...";
    }
}
