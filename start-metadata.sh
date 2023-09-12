#!/bin/bash
cd AH.Microservices.Metadata/Src/Presentation/AH.Metadata.Api || exit
dapr run --app-id metadata --app-port 5001  dotnet run --resources-path ../../../../Components 


