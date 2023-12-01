
rootPath="/c/Users/elkha/RiderProjects/AgilityHealthMicroServices/"
myArray=(
"${rootPath}AgilityHealth.Microservices/Shared/AH.Shared.Domain/"
"${rootPath}AgilityHealth.Microservices/Shared/AH.Shared.Application/"
"${rootPath}AgilityHealth.Microservices/Shared/AH.Shared.Infrastructure/"
"${rootPath}AgilityHealth.Microservices/Shared/AH.Shared.Persistence/"
"${rootPath}AgilityHealth.Microservices/Shared/AH.Shared.API/"
"${rootPath}AgilityHealth.Microservices/AH.Microservices.Metadata/Src/Shared/AH.Metadata.Shared.V1/"
"${rootPath}AgilityHealth.Microservices/AH.Microservices.Company/Src/Shared/AH.Company.Shared.V1/"
"${rootPath}AgilityHealth.Microservices/AH.Microservices.User/Src/Shared/AH.User.Shared.V1/"
)
# shellcheck disable=SC2068
for search_dir in ${myArray[@]}; 
do
  # shellcheck disable=SC2164
  echo "$search_dir"
    # shellcheck disable=SC2164
    cd "$search_dir"
  rm -r nuget
  mkdir nuget
  dotnet pack --output nuget
  for entry in "$search_dir"nuget/*
  do
    echo "$entry"
    dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json "$entry" -k MySecretApi
    rm -r nuget
  done
done

dotnet nuget push -s https://nuget.eelkhair.net/v3/index.json ${rootPath}AgilityHealth.Microservices/FrontEnd/AH.Web/nuget/Telerik.UI.for.Blazor.5.0.1.nupkg -k MySecretApi
