#!/usr/bin/env bash
 cd ~/RiderProjects/AgilityHealthMicroServices/AgilityHealth.Microservices || exit
 docker compose up -d
# This script is used to open all microservices in the browser

# Open the browser
explorer "https://ahmetadata.eelkhair.net/swagger/index.html"
explorer "https://ahcompany-domain1.eelkhair.net/swagger/index.html"
explorer "https://ahcompany-domain2.eelkhair.net/swagger/index.html"
explorer "https://ahuser-domain1.eelkhair.net/swagger/index.html"
explorer "https://ahuser-domain2.eelkhair.net/swagger/index.html"
