pipeline {
    agent { label 'azure-agent' }

    environment {
        DOCKER_REGISTRY = "index.docker.io"
        DOCKER_USERNAME = "aymar100"
        IMAGE_NAME = "frontend-app"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM',
                    branches: [[name: '*/main']],
                    userRemoteConfigs: [[
                        url: 'https://github.com/Project-TFE/Frontend.git',
                        credentialsId: '30989c36-de19-497a-b96e-17aa4b90c235'
                    ]]
                ])
            }
        }

        stage('Build & Push Docker Image') {
            steps {
                script {
                    def image = docker.build("${DOCKER_USERNAME}/${IMAGE_NAME}:latest")

                    docker.withRegistry("https://index.docker.io/v1/", 'docker-credentials') {
                        image.push()
                    }
                }
            }
        }
    }
}
