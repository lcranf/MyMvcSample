[T4Scaffolding.Scaffolder(Description = "Creates a set of ViewModels for a given Model")][CmdletBinding()]
param(
    
    [string]$Project,
    [string]$ModelFullName,
    [string]$ModelName,
    [string]$ModelPluralized,
    [string]$Area,
    [string]$AreaNamespace,
    [string]$DefaultNamespace,
    [string]$ModelNamespace,
    [string]$ViewModelNamespace,
    [string]$ViewModelOutputPath,
    [string]$PrimaryKey,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

Write-Host "Project: $Project"
Write-Host "Model Full Name: $ModelFullName"
Write-Host "Model Name: $ModelName"
Write-Host "Area: $Area"
Write-Host "Area Namespace: $AreaNamespace"
Write-Host "View Model Ouput Path: $ViewModelOutputPath"
Write-Host "Primary Key: $PrimaryKey"
Write-Host "Model Namespace: $ModelNamespace"
Write-Host "Default Namespace: $DefaultNamespace"
Write-Host "View Model Namespace: $ViewModelNamespace"
Write-Host "Model Pluralized: $ModelPluralized"

# If you have specified a model type
$foundModelType = Get-ProjectType $ModelName -Project $Project -BlockUi
if (!$foundModelType) 
{
   Write-Error "Model Name not found in project: $ModelName .  Please specify a ModelName!!!"  
   return
}

$createModelFileName = $ModelName + "CreateModel"
$outputPath = Join-Path $viewModelOutputPath $createModelFileName
$namespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
$defaultNamespace = $ViewModelNamespace + "." + $ModelPluralized
 
# Create EntityCreateModel 
Add-ProjectItemViaTemplate $outputPath -Template "Model.Template" -Model @{        
        ModelType = [MarshalByRefObject]$foundModelType; 
        PrimaryKey = [string]$primaryKey; 
        DefaultNamespace = $defaultNamespace; 
        AreaNamespace = $AreaNamespace;
        ModelTypeNamespace = $modelTypeNamespace;
        ModelTypePluralized = [string]$modelTypePluralized;    
        RelatedEntities = $relatedEntities;   
        ClassName = $createModelFileName;
        IncludePrimaryKey = $False;
        SkipAllProperties = $True;
    } -SuccessMessage "Added Create Model {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

$editModelFileName = $ModelName + "EditModel"
$outputPath = Join-Path $viewModelOutputPath $editModelFileName

# Create EntityEditModel 
Add-ProjectItemViaTemplate $outputPath -Template "Model.Template" -Model @{        
        ModelType = [MarshalByRefObject]$foundModelType; 
        PrimaryKey = [string]$primaryKey; 
        DefaultNamespace = $defaultNamespace; 
        AreaNamespace = $AreaNamespace;
        ModelTypeNamespace = $modelTypeNamespace;
        ModelTypePluralized = [string]$modelTypePluralized;    
        RelatedEntities = $relatedEntities;
        ClassName = $editModelFileName;
        IncludePrimaryKey = $True;
        SkipAllProperties = $False;
    } -SuccessMessage "Added Edit Model {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force