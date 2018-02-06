# monitor-upskilling
Azure Monitor-upskilling project using .netcore


github: https://github.com/grafana/azure-monitor-datasource


Using grafana docker image
docker pull grafana/grafana:latest  

Running
docker run -d --name=grafana -p 3000:3000 -e "GF_INSTALL_PLUGINS=grafana-azure-monitor-datasource" grafana/grafana:latest 

http://localhost:3000 

User:admin
pass:admin