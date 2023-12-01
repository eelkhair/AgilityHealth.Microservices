#!/usr/bin/env bash

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealthMicroServices/AgilityHealth.Microservices/AH.Microservices.Company/Src/Presentation/AH.Company.Api/

dotnet ef database update --startup-project "AH.Company.Api.csproj" --project "../../Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj" --connection "Server=192.168.1.160;Database=localhost5002;user id=sa;password=Pass321$;TrustServerCertificate=True;MultipleActiveResultSets=True"
dotnet ef database update --startup-project "AH.Company.Api.csproj" --project "../../Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj" --connection "Server=192.168.1.160;Database=localhost5003;user id=sa;password=Pass321$;TrustServerCertificate=True;MultipleActiveResultSets=True"

#dotnet ef database update --startup-project "AH.Company.Api.csproj" --project "../../Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj" --connection "Data Source=(local);Initial Catalog=localhost5002;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
#dotnet ef database update --startup-project "AH.Company.Api.csproj" --project "../../Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj" --connection "Data Source=(local);Initial Catalog=localhost5003;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
