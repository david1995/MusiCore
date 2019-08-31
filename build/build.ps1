param (
    [string]$configuration = "Debug"
)

& dotnet build -c $configuration -bl ../MusiCore.sln