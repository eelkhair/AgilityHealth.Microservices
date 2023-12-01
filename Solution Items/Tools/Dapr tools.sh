#!/usr/bin/env bash
explorer "http://localhost:8080"
explorer  "http://zipkin.eelkhair.net"
explorer  "https://kibana.eelkhair.net"
explorer  "https://rabbitmq.eelkhair.net"
explorer  "https://redis.eelkhair.net"

cd ~/RiderProjects/AgilityHealthMicroServices/AgilityHealth.Microservices || exit
dapr dashboard
