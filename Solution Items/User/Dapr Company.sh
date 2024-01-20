#!/usr/bin/env bash

# Run dapr for the metadata project 

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealthMicroServices/AgilityHealth.Microservices/AH.Microservices.Company/Src/Presentation/AH.Company.Api/

dapr run --app-id ah-company --app-port 5002 --dapr-http-port 50002 --resources-path ../../../../Components dotnet run