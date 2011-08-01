[T4Scaffolding.Scaffolder(Description = "Create Crud Services for the specified Entity")][CmdletBinding()]
param(        
    [string]$Project,
    [string]$ModelName,
    [string]$ServiceProject,
    [string]$RepositoryNamespace,
    [string]$EntityNamespace,
    [string]$OutputPath,
    [string]$DefaultNamespace,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
    [switch]$NoIoc = $false,
	[switch]$Force = $false
)


# If you have specified a model type
$foundModelType = Get-ProjectType $ModelName -Project $Project -BlockUi
if (!$foundModelType) 
{
   Write-Error "Model Name not found in project: $ModelName .  Please specify a ModelName!!!"  
   return
}

# If ServiceProject is omitted, then fallback to the default project provided by the NuGet Manager
if(!$ServiceProject)
{
   $ServiceProject = $Project
}

$serviceInterface = "I" + $ModelName + "Service"
$serviceImplementation = $ModelName + "Service"
$interfaceOutputPath = Join-Path $OutputPath $serviceInterface

Add-ProjectItemViaTemplate $interfaceOutputPath -Template IService -Model @{
     Namespace = $DefaultNamespace;
     ModelType = [MarshalByRefObject]$foundModelType; 
     PrimaryKey = [string]$primaryKey; 
     DefaultNamespace = $defaultNamespace; 
     AreaNamespace = $areaNamespace;      
     RepositoriesNamespace = $RepositoryNamespace;
     ModelTypeNamespace = $modelTypeNamespace;
     NoIoc = $NoIoc.IsPresent;
  } -SuccessMessage "Added Service output at {0}" `
	-TemplateFolders $TemplateFolders -Project $ServiceProject -CodeLanguage $CodeLanguage -Force:$Force

$implementationOutputPath = Join-Path $OutputPath $serviceImplementation

Add-ProjectItemViaTemplate $implementationOutputPath -Template Service -Model @{
     Namespace = $namespace;
     ModelType = [MarshalByRefObject]$foundModelType; 
     PrimaryKey = [string]$primaryKey; 
     DefaultNamespace = $defaultNamespace; 
     AreaNamespace = $areaNamespace;      
     RepositoriesNamespace = $RepositoryNamespace;
     ModelTypeNamespace = $modelTypeNamespace;
     NoIoc = $NoIoc.IsPresent;
  } -SuccessMessage "Added Service output at {0}" `
	-TemplateFolders $TemplateFolders -Project $ServiceProject -CodeLanguage $CodeLanguage -Force:$Force