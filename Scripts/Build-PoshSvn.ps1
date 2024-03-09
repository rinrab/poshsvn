param (
    [string]$Configuration = "Release"
)

$Output = "$PSScriptRoot\..\bin\poshsvn"
$ProjectPath = "$PSScriptRoot\..\PoshSvn\PoshSvn.csproj"

Remove-Item $Output -Recurse -Force -ErrorAction Ignore

dotnet.exe build $ProjectPath --output $Output --configuration $Configuration -v=normal

if ($null -eq (Get-Module -ListAvailable -Name platyPS)) {
    Install-Module -Name platyPS -Force
}

New-ExternalHelp -Path $PSScriptRoot\..\docs -OutputPath $Output\en-US -Force

Compress-Archive -Path $Output\* -DestinationPath "$Output.zip" -Force -CompressionLevel Optimal