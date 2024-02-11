﻿@{
    GUID="{49B991B6-D257-4122-AEDA-0C317118596A}"
    Author="Timofei Zhakov"
    Copyright="(c) Timofei Zhakov. All rights reserved."
    ModuleVersion="0.1.0.0"
    PowerShellVersion="3.0"
    CLRVersion="4.0"
    RootModule = "SvnPosh.dll"
    CmdletsToExport= @(
        "Invoke-SvnStatus"
        "Invoke-SvnUpdate"
    )
    AliasesToExport = @(
        "svn-status"
        "svn-update"
    )
    FunctionsToExport = @()
    FormatsToProcess = @(
        "SvnStatus.format.ps1xml"
        "SvnUpdate.format.ps1xml"
    )
}