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


# If you have specified a model type
$foundModelType = Get-ProjectType $ModelName -Project $Project -BlockUi
if (!$foundModelType) 
{
   Write-Error "Model Name not found in project: $ModelName .  Please specify a ModelName!!!"  
   return
}

$baseModelFileName = "Base" + $ModelName + "Model"
$outputPath = Join-Path $viewModelOutputPath $baseModelFileName

Write-Host "Building $baseModelFileName"

# Create BaseEntityModel 
Add-ProjectItemViaTemplate $outputPath -Template "Model.Template" -Model @{        
        ModelType = [MarshalByRefObject]$foundModelType; 
        PrimaryKey = [string]$primaryKey; 
        DefaultNamespace = $defaultNamespace; 
        AreaNamespace = $AreaNamespace;
        ModelTypeNamespace = $modelTypeNamespace;
        ModelTypePluralized = [string]$modelTypePluralized;    
        RelatedEntities = $relatedEntities;
        ClassName = $baseModelFileName;
        IsBaseClass = $True;
        IsEditable = $True;
        IncludePrimaryKey = $True;
        SkipAllProperties = $False;
    } -SuccessMessage "Added Model {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

$createModelFileName = $ModelName + "CreateModel"
$outputPath = Join-Path $viewModelOutputPath $createModelFileName
$namespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
$defaultNamespace = $ViewModelNamespace + "." + $ModelPluralized
 
Write-Host "Building $createModelFileName"
 
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
        BaseClassName = $baseModelFileName;
        IsBaseClass = $False;
        IsEditable = $False;        
        IncludePrimaryKey = $False;
        SkipAllProperties = $True;
    } -SuccessMessage "Added Model {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

$editModelFileName = $ModelName + "EditModel"
$outputPath = Join-Path $viewModelOutputPath $editModelFileName

Write-Host "Building $editModelFileName"

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
        BaseClassName = $baseModelFileName;
        IsBaseClass = $False;
        IsEditable = $True;
        IncludePrimaryKey = $True;
        SkipAllProperties = $False;
    } -SuccessMessage "Added Model {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force   
