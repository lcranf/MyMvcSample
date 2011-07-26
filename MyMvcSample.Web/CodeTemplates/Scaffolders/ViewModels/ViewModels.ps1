[T4Scaffolding.Scaffolder(Description = "Creates a set of ViewModels for a given Model")][CmdletBinding()]
param(
    
    [string]$Project,
    [string]$ModelName,
    [string]$Area,
    [string]$AreaNamespace,
    [string]$DefaultNamespace,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

Write-Host "Project: $Project"
Write-Host "Model Name: $ModelName"
Write-Host "Area: $Area"
Write-Host "Area Namespace: $AreaNamespace"


$outputPath = "ExampleOutput"  # The filename extension will be added based on the template's <#@ Output Extension="..." #> directive
$namespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value

Add-ProjectItemViaTemplate $outputPath -Template ViewModelsTemplate	-Model @{ 
    Namespace = $namespace;
    ExampleValue = "Hello, world!";
 } -SuccessMessage "Added ViewModels output at {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force