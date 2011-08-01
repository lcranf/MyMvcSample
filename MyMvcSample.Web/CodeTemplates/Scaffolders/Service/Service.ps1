[T4Scaffolding.Scaffolder(Description = "Create Crud Services for the specified Entity")][CmdletBinding()]
param(        
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelName,
    [string]$Project,    
    [string]$ServiceProject,
    [string]$RepositoryNamespace,
    [string]$EntityNamespace,
    [string]$OutputPath = "Services",
    [string]$DefaultNamespace,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
    [switch]$NoIoc = $false,
	[switch]$Force = $false
)

Write-Host "EntityNamespace: $EntityNamespace"
Write-Host "RepositoryNamespace: $RepositoryNamespace"

# If you have specified a model type
$foundModelType = Get-ProjectType $ModelName -Project $Project -BlockUi
if (!$foundModelType) 
{
   Write-Error "Model Name not found in project: $ModelName .  Please specify a ModelName!!!"  
   return
}

$namespace = $DefaultNamespace

# If ServiceProject is omitted, then fallback to the default project provided by the NuGet Manager
if(!$ServiceProject) {
   $ServiceProject = $Project
} else {
  #find namespace of service project
  $namespace = $ServiceProject + "." + $OutputPath  
}

$serviceInterface = "I" + $ModelName + "Service"
$interfaceOutputPath = Join-Path $OutputPath $serviceInterface

Add-ProjectItemViaTemplate $interfaceOutputPath -Template IService -Model @{
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

$serviceImplementation = $ModelName + "Service"
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