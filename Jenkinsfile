pipeline {
    agent any

    environment {
        DOCKER_REGISTRY = "aymar100"
        IMAGE_NAME = "frontend-app"
    }

    stages {
        stage('Checkout Code') {
            steps {
                git branch: 'main',
                    credentialsId: 'effe7fbc-ffc7-4911-882d-b9e13e2adfe7',
                    url: 'https://github.com/Project-TFE/Frontend.git'
            }
        }

        stage('Build & Push Docker Image') {
            steps {
                script {
                    def image = docker.build("${DOCKER_REGISTRY}/${IMAGE_NAME}:${BUILD_NUMBER}", ".")
                    docker.withRegistry("https://${DOCKER_REGISTRY}", 'docker-credentials') {
                        image.push()
                        image.push("latest")
                    }
                }
            }
        }
    }
}
