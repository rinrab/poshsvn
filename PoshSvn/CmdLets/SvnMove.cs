﻿using System.Management.Automation;
using SharpSvn;

namespace PoshSvn.CmdLets
{
    [Cmdlet("Invoke", "SvnMove")]
    [Alias("svn-move")]
    [OutputType(typeof(SvnNotifyOutput), typeof(SvnCommitOutput))]
    public class SvnMove : SvnClientCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string[] Source { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        public string Destination { get; set; }

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
            };

            SvnClient.Move(GetPathTargets(Source, null), GetPathTarget(Destination), args);
        }
    }
}