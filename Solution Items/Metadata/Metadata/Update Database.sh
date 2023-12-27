#!/usr/bin/env bash

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealth.Microservices/AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/

#dotnet ef database update --startup-project "AH.Metadata.Api.csproj" --project "../../Infrastructure/AH.Metadata.Persistence/AH.Metadata.Persistence.csproj" --connection "Data Source=(local);Initial Catalog=AH.Metadata;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
dotnet ef database update --startup-project "AH.Metadata.Api.csproj" --project "../../Infrastructure/AH.Metadata.Persistence/AH.Metadata.Persistence.csproj" --connection "Server=192.168.1.160;Database=AH.Metadata;user id=sa;password=Pass321$;TrustServerCertificate=True;MultipleActiveResultSets=True"
