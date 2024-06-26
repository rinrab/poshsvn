// Copyright 2007-2024 The SharpSvn Project
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

#include "Stdafx.h"

#include "Args/SvnMergingSummaryArgs.h"

using namespace SharpSvn;

bool SvnClient::GetMergingSummary(SvnTarget^ target, SvnTarget^ source, SvnMergingSummaryArgs^ args, [Out] SvnMergingSummaryEventArgs^% mergingSummary) {
    EnsureState(SvnContextState::AuthorizationInitialized);
    AprPool pool(% _pool);
    ArgsStore store(this, args, % pool);

    svn_boolean_t is_reintegration;

    const char* yca_url;
    svn_revnum_t yca_rev;

    const char* base_url;
    svn_revnum_t base_rev;

    const char* right_url;
    svn_revnum_t right_rev;

    const char *target_url;
    svn_revnum_t target_rev;

    const char* repos_root_url;

    svn_error_t *r = svn_client_get_merging_summary(
        &is_reintegration,
        &yca_url, &yca_rev,
        &base_url, &base_rev,
        &right_url, &right_rev,
        &target_url, &target_rev,
        &repos_root_url,
        source->AllocAsString(% pool),
        source->GetSvnRevision(SvnRevision::Working, SvnRevision::Head)->AllocSvnRevision(% pool),
        target->AllocAsString(% pool),
        target->GetSvnRevision(SvnRevision::Working, SvnRevision::Head)->AllocSvnRevision(% pool),
        CtxHandle,
        pool.Handle,
        pool.Handle);

    mergingSummary = gcnew SvnMergingSummaryEventArgs(
        is_reintegration,
        yca_url, yca_rev,
        base_url, base_rev,
        right_url, right_rev,
        target_url, target_rev,
        repos_root_url,
        SvnCommandType::GetMergingSummary, % pool);

    return args->HandleResult(this, r);
}
