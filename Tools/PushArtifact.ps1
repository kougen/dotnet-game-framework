param(
    <#
    .PARAMETER WorkDir
    Example: Release, Debug, ...
    #>
    [string]$Configuration = "Debug",
    <#
    .PARAMETER WorkDir
    The file which contains the names for the nuspec files
    #>
    [string]$WorkDir = ".",
    <#
    .PARAMETER Version
    Example: "1.0.0-pre0002" or "1.0.1" or "1.0.0-a0002" or "1.0.0-a0002"
    #>
    [Parameter(Mandatory = $true)]
    [string]$Version
)

$version = $Version
$versionDir = "v$version"
$nugetExePath = "$WorkDir\nuget.exe"

$projects = Get-Content $WorkDir\.projects


foreach ($project in $projects) {
    New-Item -ItemType Directory -Path $WorkDir\tmp
    Copy-Item -Path $WorkDir\Projects\$project.nuspec -Destination $WorkDir\tmp\
    ((Get-Content -path $WorkDir\tmp\$project.nuspec -Raw) -replace '{CONFIGURATION}', $Configuration) | Set-Content -Path $WorkDir\tmp\$project.nuspec
    & $nugetExePath pack $WorkDir\tmp\$project.nuspec -version $version -OutputDirectory $WorkDir\Packages\$versionDir\
}

Remove-Item -Path $WorkDir\tmp\ -Recurse


