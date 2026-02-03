# Cloud-Native Serverless Resume Application

![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)
![.Net](https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Cosmos DB](https://img.shields.io/badge/Cosmos%20DB-4285F4?style=for-the-badge&logo=azurecosmosdb&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white)

## 🚀 Project Overview

This project demonstrates a full-stack, cloud-native application deployed on **Microsoft Azure**. The goal was to engineer a serverless solution that decouples the frontend from the backend to maximize scalability and optimize costs.

It features a globally distributed static frontend and a robust **.NET 8.0 serverless API**, fully automated via a CI/CD pipeline.

### 🔗 Live Demo
https://brave-water-089a7670f.1.azurestaticapps.net/

---

## 🏗️ Architecture

The solution leverages Azure's serverless ecosystem to handle varying loads without manual infrastructure management.

```mermaid
graph TD;
    User[Client / Browser] -->|HTTPS Request| CDN[Azure Static Web Apps];
    CDN -->|API Calls /api/| Function[Azure Functions .NET 8];
    Function -->|Read/Write JSON| DB[(Azure Cosmos DB)];
    
    subgraph CI_CD_Pipeline [DevOps Automation]
    Git[GitHub Repository] -->|Push to Main| Action[GitHub Actions];
    Action -->|Build & Deploy| CDN;
    end
    
