$YOUR_MANAGED_FILES_PATH = 'C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\Lethal Company_Data\Managed\'

try
{
    Write-Output '#: New-Item -Path $(Join-Path $PSScriptRoot "Managed") -ItemType SymbolicLink -Value "$YOUR_MANAGED_FILES_PATH"'.Replace('$YOUR_MANAGED_FILES_PATH', $YOUR_MANAGED_FILES_PATH)
    New-Item -Path $(Join-Path $PSScriptRoot "Managed") -ItemType SymbolicLink -Value $YOUR_MANAGED_FILES_PATH
}
catch
{
    Write-Error "Failed to create symlink to $YOUR_MANAGED_FILES_PATH, Make sure you're running the script as admin."
    throw;
}

