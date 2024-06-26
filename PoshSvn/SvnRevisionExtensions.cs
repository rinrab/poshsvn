﻿// Copyright (c) Timofei Zhakov. All rights reserved.

using System;

namespace PoshSvn
{
    public static class SvnRevisionExtensions
    {
        public static SvnRevision ToPoshSvnRevision(this SharpSvn.SvnRevision revision)
        {
            if (revision.RevisionType == SharpSvn.SvnRevisionType.Number)
            {
                return new SvnRevision(revision.Revision);
            }
            else if (revision.RevisionType == SharpSvn.SvnRevisionType.Time)
            {
                throw new NotImplementedException();
            }
            else
            {
                return new SvnRevision(revision.RevisionType.ToPoshSvnRevisionType());
            }
        }

        public static SharpSvn.SvnRevision ToSharpSvnRevision(this SvnRevision revision)
        {
            if (revision.RevisionType == SvnRevisionType.Number)
            {
                return new SharpSvn.SvnRevision(revision.Revision);
            }
            else
            {
                return new SharpSvn.SvnRevision(revision.RevisionType.ToSharpSvnRevisionType());
            }
        }
    }
}
