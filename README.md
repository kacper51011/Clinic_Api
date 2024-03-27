# Clinic_Api

This repository contains the necessary files and instructions to run api using Docker Compose.

## Prerequisites

Before you begin, ensure that you have the following installed on your system:

- Docker: [Install Docker](https://docs.docker.com/get-docker/)
- Docker Compose: [Install Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started

1. **Clone this repository to your local machine:**

    ```bash
    git clone https://github.com/kacper51011/Clinic_Api.git
    ```
Then navigate to repository folder


2. **Start the application using Docker Compose:**

    ```bash
    docker-compose up
    ```

3. **Access the application in your web browser:**

    Once the containers are up and running, you can access the application by navigating to `http://localhost:8000` or `https://localhost:8001` in your web browser.

## Stopping the Application

To stop the application and remove the containers, run:

```bash
docker-compose down
