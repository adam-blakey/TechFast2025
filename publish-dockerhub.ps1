# PowerShell script to publish .NET projects and build/push Docker images with kebab-case tags

# https://www.powershellgallery.com/packages/Psst/0.2.2/Content/ConvertToKebabCase.ps1
function ConvertTo-KebabCase {
    param (
        [string]$Name
    )

    if ($Name -eq $null) {
        return $null
    }

    $parts = @()
    $part = ""
    for ($i = 0; $i -lt $Name.Length; $i++) {
        if ([char]::IsUpper($Name[$i]) -and $part.Length -gt 0) {
            $parts += $part.ToLower()
            $part = ""
        } 

        $part += $Name[$i]
    }
    if ($part.Length) {
        $parts += $part.ToLower();
    }

    [string]::Join("-", $parts);
}

# Get all subdirectories
Get-ChildItem -Directory | ForEach-Object {
    $dir = $_.FullName
    $folderName = $_.Name
    $tag = ConvertTo-KebabCase $folderName

    Write-Host "`n--- Processing $folderName (tag: $tag) ---`n"

    Push-Location $dir

    try {
        docker build -t "amblakey/blazor:${tag}" .
        docker push "amblakey/blazor:${tag}"
    } catch {
        Write-Host "Error processing ${folderName}: $_" -ForegroundColor Red
    }

    Pop-Location
}
