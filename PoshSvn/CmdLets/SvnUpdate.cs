﻿using System.Management.Automation;
using SharpSvn;

namespace PoshSvn.CmdLets
{
    [Cmdlet("Invoke", "SvnUpdate")]
    [Alias("svn-update")]
    [OutputType(typeof(SvnUpdateOutput))]
    public class SvnUpdate : SvnClientCmdletBase
    {
        [Parameter(Position = 0, ValueFromRemainingArguments = true)]
        public string[] Path { get; set; } = new string[] { "" };

        [Parameter()]
        [Alias("rev")]
        public SvnRevision Revision { get; set; } = null;

        protected override string GetActivityTitle(SvnNotifyEventArgs e)
        {
            return e == null ? "Updating" : string.Format("Updating '{0}'", e.Path);
        }

        protected override void Execute()
        {
            string[] resolvedPaths = GetPathTargets(Path, null);

            try
            {
                SvnUpdateArgs args = new SvnUpdateArgs
                {
                    Revision = Revision,
                };

                SvnClient.Update(resolvedPaths, args);
            }
            catch (SvnException ex)
            {
                if (ex.ContainsError(SvnErrorCode.SVN_ERR_WC_NOT_WORKING_COPY))
                {
                    WriteSvnError(ex);
                }
                else
                {
                    throw;
                }
            }
        }
    }

    public class SvnUpdateOutput
    {
        public long Revision { get; set; }
    }
}
