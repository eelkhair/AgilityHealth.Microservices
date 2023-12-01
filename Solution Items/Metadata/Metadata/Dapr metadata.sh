﻿#!/usr/bin/env bash

# Run dapr for the metadata project 

# shellcheck disable=SC2164
cd ~/RiderProjects/AgilityHealthMicroServices/AgilityHealth.Microservices/AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api/

dapr run --app-id ah-metadata --app-port 5001 --dapr-http-port 3500 --resources-path ../../../../Components dotnet run