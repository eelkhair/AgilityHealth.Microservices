#!/bin/bash
cd AH.Microservices.Company/Src/Presentation/AH.Company.Api || exit
dapr run --app-id company --app-port 5001  dotnet run --resources-path ../../../../Components 


