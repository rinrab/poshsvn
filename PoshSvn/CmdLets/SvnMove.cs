﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System;
using System.Management.Automation;
using SharpSvn;

namespace PoshSvn.CmdLets
{
    [Cmdlet("Invoke", "SvnMove", DefaultParameterSetName = ParameterSetNames.Local)]
    [Alias("svn-move")]
    [OutputType(typeof(SvnNotifyOutput), typeof(SvnCommitOutput))]
    public class SvnMove : SvnClientCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true)]
        public SvnTarget[] Source { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        public SvnTarget Destination { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.Remote, Mandatory = true)]
        [Alias("m")]
        public string Message { get; set; }

        [Parameter()]
        public SwitchParameter Force { get; set; }

        [Parameter()]
        public SwitchParameter Parents { get; set; }

        [Parameter()]
        public SwitchParameter AllowMixedRevisions { get; set; }

        protected override void Execute()
        {
            SvnMoveArgs args = new SvnMoveArgs
            {
                Force = Force,
                CreateParents = Parents,
                AllowMixedRevisions = AllowMixedRevisions,
                LogMessage = Message,
            };

            TargetCollection sources = TargetCollection.Parse(GetTargets(Source));
            sources.ThrowIfHasPathsAndUris();
            object destination = GetTarget(Destination);

            if (destination is string destinationPath)
            {
                SvnClient.Move(sources.Paths, destinationPath, args);
            }
            else if (destination is Uri destinationUrl)
            {
                SvnClient.RemoteMove(sources.Uris, destinationUrl, args);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
