﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System.Management.Automation;
using SharpSvn;

namespace PoshSvn.CmdLets
{
    [Cmdlet("Invoke", "SvnDelete", DefaultParameterSetName = ParameterSetNames.Local)]
    [Alias("svn-delete", "svn-remove")]
    [OutputType(typeof(SvnCommitOutput))]
    public class SvnDelete : SvnClientCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ValueFromRemainingArguments = true)]
        public SvnTarget[] Target { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.Remote)]
        [Alias("m")]
        public string Message { get; set; }

        [Parameter()]
        [Alias("f")]
        public SwitchParameter Force { get; set; }

        [Parameter()]
        [Alias("keep-local")]
        public SwitchParameter KeepLocal { get; set; }

        protected override void Execute()
        {
            SvnDeleteArgs args = new SvnDeleteArgs
            {
                Force = Force,
                KeepLocal = KeepLocal,
                LogMessage = Message,
            };

            TargetCollection targets = TargetCollection.Parse(GetTargets(Target));
            targets.ThrowIfHasPathsAndUris();

            if (targets.HasPaths)
            {
                SvnClient.Delete(targets.Paths, args);
            }
            else
            {
                SvnClient.RemoteDelete(targets.Uris, args);
            }
        }
    }
}
