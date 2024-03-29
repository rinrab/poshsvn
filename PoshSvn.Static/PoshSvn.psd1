﻿@{
    GUID                   = "{49B991B6-D257-4122-AEDA-0C317118596A}"
    Author                 = "Timofei Zhakov"
    CompanyName            = "Rinrab"
    Copyright              = "(c) Timofei Zhakov. All rights reserved."
    ModuleVersion          = "0.5.2"
    PowerShellVersion      = "3.0"
    CLRVersion             = "4.0"
    Description            = "Apache Subversion client for PowerShell

Project website: https://www.poshsvn.com"
    ProcessorArchitecture  = "Amd64"
    RootModule             = "PoshSvn.dll"
    DotNetFrameworkVersion = "4.7.2"
    CmdletsToExport        = @(
        "Invoke-SvnStatus"
        "Invoke-SvnUpdate"
        "Invoke-SvnCheckout"
        "Invoke-SvnCleanup"
        "Invoke-SvnCommit"
        "Invoke-SvnMkdir"
        "Invoke-SvnInfo"
        "Invoke-SvnAdd"
        "Invoke-SvnDelete"
        "Invoke-SvnAdminCreate"
        "Invoke-SvnMove"
        "Invoke-SvnLog"
        "Invoke-SvnList"
        "Invoke-SvnRevert"
        "Invoke-SvnCopy"
        "Invoke-SvnSwitch"
        "Invoke-SvnExport"
        "Invoke-SvnImport"
        "Invoke-SvnCat"
        "Invoke-SvnDiff"
        "Invoke-SvnBlame"
        "Invoke-SvnLock"
        "Invoke-SvnUnlock"
        "New-SvnTarget"
    )
    AliasesToExport        = @(
        "svn-status"
        "svn-update"
        "svn-checkout"
        "svn-cleanup"
        "svn-commit"
        "svn-mkdir"
        "svn-info"
        "svn-add"
        "svn-delete"
        "svn-remove"
        "svn-move"
        "svn-log"
        "svn-list"
        "svn-revert"
        "svn-copy"
        "svn-switch"
        "svn-export"
        "svn-import"
        "svn-cat"
        "svn-diff"
        "svn-blame"
        "svn-lock"
        "svn-unlock"
        "svnadmin-create"
    )
    FunctionsToExport      = @()
    FormatsToProcess       = @(
        "SvnStatus.format.ps1xml"
        "SvnInfo.format.ps1xml"
        "SvnNotifyOutput.format.ps1xml"
        "SvnLog.format.ps1xml"
        "SvnItem.format.ps1xml"
        "SvnBlame.format.ps1xml"
    )
    PrivateData            = @{
        PSData = @{
            Tags                     = @("svn", "subversion")
            ReleaseNotes             = "# Changelog

All notable changes to this project will be documented in this file.

## [0.5.0]

- Implement `svn-cat` cmdlet.
- Implement `svn-diff` cmdlet.
- Implement `svn-blame` cmdlet.
- Some fixes in commit output.
- Minor fixes and improvement.

## [0.4.0]

- Added vscode extension.
- Minor fixes and improvement.

## [0.3.0]

- Add `-Revision` parameter to `svn-log` cmdlet.
- Implement `svn-import` and `svn-export` cmdlets.
- Minor fixes and improvement.

## [0.2.0]

- Rework targets of cmdlets.
- Implement `svn-switch`.
- Minor fixes and improvement.

## [0.1.3]

- Minor fixes and improvement.
- Implement `svn-copy`.

## [0.1.2]

- Add documentation.
- Some fixes in metadata.

## [0.1.1]

- Include CRT to package
- Minor fixes in module manifest

## [0.1.0]

- Initial release
"
            # LicenseUri = "https://aka.ms/azps-license"
            ProjectUri = "https://www.poshsvn.com"
            IconUri = "https://www.poshsvn.com/icon.svg"
            RequireLicenseAcceptance = $false
            # ExternalModuleDependencies = @()
        }
    }
}
