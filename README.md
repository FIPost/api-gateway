![ipost-logo](https://github.com/FIPost/docs/blob/master/assets/logo-name.png?raw=true)
# API Gateway
<h3 align="middle">
  <a href="https://github.com/FIPost/docs">Documentation</a>
  <a>•</a>
  <a href="https://github.com/FIPost/docs/blob/master/CONTRIBUTING.md">Contributing</a>
  <a>•</a>
  <a href="https://github.com/FIPost/docs/blob/master/CONTACT.md">Contact</a>
</h3>

API Gateway for communication between the frontend and backend. Abstracts calls into user-friendly endpoints and adds a secure entrypoint layer on top of the individual microservices.

## Getting Started
```zsh
docker-compose up --build
```

#### Error: Docker Network Missing
If you get the following error:
Network `ipost-network` declared as external, but could not be found. Run the following:
```zsh
docker network create ipost-network
```
