#!/usr/bin/env bash

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealthMicroServices/AgilityHealth.Microservices/AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/

dotnet ef migrations add "Initial Migration" --startup-project "AH.Metadata.Api.csproj" --project "../../Infrastructure/AH.Metadata.Persistence/AH.Metadata.Persistence.csproj"
