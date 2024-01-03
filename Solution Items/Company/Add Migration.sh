#!/usr/bin/env bash

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealth.Microservices/AH.Microservices.Company/Src/Presentation/AH.Company.Api/

dotnet ef migrations add "Initial-Migration" --startup-project "AH.Company.Api.csproj" --project "../../Infrastructure/AH.Company.Persistence/AH.Company.Persistence.csproj"
