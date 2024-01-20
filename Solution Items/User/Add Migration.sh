#!/usr/bin/env bash

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealth.Microservices/AH.Microservices.User/Src/Presentation/AH.User.Api/

dotnet ef migrations add "Initial-Migration" --startup-project "AH.User.Api.csproj" --project "../../Infrastructure/AH.User.Persistence/AH.User.Persistence.csproj"
