
rootPath="/home/eelkhair/RiderProjects/"
myArray=(

"${rootPath}AgilityHealth.Microservices/AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/"
"${rootPath}AgilityHealth.Microservices/AH.Microservices.Company/Src/Shared/AH.Company.Shared.V1/"
"${rootPath}AgilityHealth.Microservices/AH.Microservices.User/Src/Shared/AH.User.Shared.V1/"
"${rootPath}AgilityHealth.Microservices/Integrations/Src/AH.Integration.Auth0.ServiceAgent/"
"${rootPath}AgilityHealth.Microservices/Integrations/Src/AH.Integration.Auth0.ServiceAgent.SDK/"
"${rootPath}AgilityHealth.Microservices/HealthChecks/AH.Microservices.HealthChecks/"
)
# shellcheck disable=SC2068
for search_dir in ${myArray[@]}; 
do
  # shellcheck disable=SC2164
  echo "$search_dir"
    # shellcheck disable=SC2164
    cd "$search_dir"
  mkdir nuget
  dotnet pack --output nuget
  for entry in "$search_dir"nuget/*
  do
    echo "$entry"
    dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json "$entry" 
        
        rm -r nuget
  done
done

dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.UI.for.Blazor.5.0.1.nupkg
dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.Recurrence.0.2.1.nupkg
dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.DataSource.3.0.0.nupkg
dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.Documents.SpreadsheetStreaming.2023.3.1106.nupkg
dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.Pivot.DataProviders.Xmla.0.1.0.nupkg
dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.Pivot.Core.0.1.0.nupkg
dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.Zip.2023.3.1106.nupkg

