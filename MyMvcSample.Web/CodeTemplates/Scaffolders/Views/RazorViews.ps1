[T4Scaffolding.Scaffolder(Description = "Adds ASP.NET MVC views for Create/Read/Update/Delete/Index scenarios")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, Position = 0)][string]$Controller,
	[string]$ModelType,
	[string]$Area,
	[alias("MasterPage")]$Layout,	# If not set, we'll use the default layout
 	[alias("ContentPlaceholderIDs")][string[]]$SectionNames,
	[alias("PrimaryContentPlaceholderID")][string]$PrimarySectionName,
	[switch]$ReferenceScriptLibraries = $false,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[string]$ViewScaffolder = "View",
    [switch]$CreateViewModels = $false,
	[switch]$Force = $false
)

Write-Host "RazorViews CreateViewModels = $CreateViewModels"
Write-Host "RazorViews ViewScaffolder = $ViewScaffolder"

@("Create", "Edit", "Delete", "Details", "Index", "_CreateOrEdit") | %{
	Scaffold $ViewScaffolder -Controller $Controller -ViewName $_ -ModelType $ModelType -Template $_ -Area $Area -Layout $Layout -SectionNames $SectionNames -PrimarySectionName $PrimarySectionName -ReferenceScriptLibraries:$ReferenceScriptLibraries -Project $Project -CodeLanguage $CodeLanguage -OverrideTemplateFolders $TemplateFolders -Force:$Force -BlockUi
}