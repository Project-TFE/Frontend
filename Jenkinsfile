pipeline {
    agent any

    environment {
        DOCKER_REGISTRY = "aymar100"
        IMAGE_NAME = "frontend-app"
    }

    stages {
        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        stage('Build & Push Docker Image') {
            steps {
                script {
                    def image = docker.build("${DOCKER_REGISTRY}/${IMAGE_NAME}:${BUILD_NUMBER}", "./Frontend")
                    docker.withRegistry("https://${DOCKER_REGISTRY}", 'docker-credentials') {
                        image.push()
                        image.push("latest")
                    }
                }
            }
        }
    }
}
