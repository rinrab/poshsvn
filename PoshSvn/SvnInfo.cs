﻿using System;
using System.Management.Automation;
using SharpSvn;

namespace PoshSvn
{
    [Cmdlet("Invoke", "SvnInfo", DefaultParameterSetName = TargetParameterSetNames.Target)]
    [Alias("svn-info")]
    [OutputType(typeof(SvnInfoOutput))]
    public class SvnInfo : SvnCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = TargetParameterSetNames.Target, ValueFromRemainingArguments = true)]
        public string[] Target { get; set; } = new string[] { "" };

        [Parameter(ParameterSetName = TargetParameterSetNames.Path)]
        public string[] Path { get; set; }

        [Parameter(ParameterSetName = TargetParameterSetNames.Url)]
        public Uri[] Url { get; set; }

        [Parameter()]
        [Alias("r", "rev")]
        public SvnRevision Revision { get; set; } = null;

        [Parameter()]
        public SvnDepth Depth { get; set; } = SvnDepth.Empty;

        [Parameter()]
        [Alias("include-externals")]
        public SwitchParameter IncludeExternals { get; set; }

        protected override void ProcessRecord()
        {
            using (SvnClient client = new SvnClient())
            {
                try
                {
                    SvnInfoArgs args = new SvnInfoArgs
                    {
                        Revision = Revision,
                        IncludeExternals = IncludeExternals,
                        Depth = Depth.ConvertToSharpSvnDepth(),
                    };

                    args.Progress += Progress;

                    foreach (SvnTarget target in GetTargets(Target, Path, Url))
                    {
                        client.Info(target, args, InfoHandler);
                    }
                }
                catch (SvnException ex)
                {
                    if (ex.ContainsError(SvnErrorCode.SVN_ERR_WC_NOT_WORKING_COPY))
                    {
                        WriteWarning(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        protected override string GetActivityTitle(SvnNotifyEventArgs e)
        {
            return "svn-info";
        }

        private void InfoHandler(object sender, SvnInfoEventArgs e)
        {
            SvnInfoOutput svnInfo = new SvnInfoOutput
            {
                Path = e.Path,
                WorkingCopyRoot = e.WorkingCopyRoot,
                Url = e.Uri,
                RelativeUrl = e.RepositoryRoot.MakeRelativeUri(e.Uri),
                RepositoryRoot = e.RepositoryRoot,
                RepositoryId = e.RepositoryId,
                Revision = e.Revision,
                NodeKind = e.NodeKind,
                LastChangedAuthor = e.LastChangeAuthor,
                LastChangedRevision = e.LastChangeRevision,
                LastChangedDate = e.LastChangeTime,
            };

            if (e.HasLocalInfo)
            {
                UpdateAction(e.Path);
                svnInfo.Schedule = e.Schedule;
                svnInfo.WorkingCopyRoot = e.WorkingCopyRoot;
            }
            else
            {
                UpdateAction(e.Uri.ToString());
            }

            WriteObject(svnInfo);
        }
    }

    public class SvnInfoOutput
    {
        public string Path { get; set; }
        public Uri Url { get; set; }
        public Uri RelativeUrl { get; set; }
        public Uri RepositoryRoot { get; set; }
        public Guid RepositoryId { get; set; }
        public long Revision { get; set; }
        public SvnNodeKind NodeKind { get; set; }
        public string LastChangedAuthor { get; set; }
        public long LastChangedRevision { get; set; }
        public DateTime LastChangedDate { get; set; }

        public SvnSchedule? Schedule { get; set; } = null;
        public string WorkingCopyRoot { get; set; } = null;
    }
}