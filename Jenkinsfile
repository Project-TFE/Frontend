pipeline {
    agent { label 'azure-agent' }

    environment {
        DOCKER_REGISTRY = "index.docker.io"
        DOCKER_USERNAME = "aymar100"
        IMAGE_NAME = "frontend-app"
        SONAR_PROJECT_KEY = 'frontend-app'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout([
                    $class: 'GitSCM',
                    branches: [[name: '*/main']],
                    userRemoteConfigs: [[
                        url: 'https://github.com/Project-TFE/Frontend.git',
                        credentialsId: '30989c36-de19-497a-b96e-17aa4b90c235'
                    ]]
                ])
            }
        }

        stage('SonarQube Analysis') {
            steps {
                dir('Ehealth/AnimalsMvc') {
                    withSonarQubeEnv('SonarQube') {
                        sh """
                            dotnet restore
                            dotnet tool install --global dotnet-sonarscanner
                            export PATH=\"$PATH:/root/.dotnet/tools\"
                            dotnet sonarscanner begin /k:${SONAR_PROJECT_KEY} /d:sonar.host.url=${SONAR_HOST_URL} /d:sonar.login=${SONAR_AUTH_TOKEN}
                            dotnet build
                            dotnet sonarscanner end /d:sonar.login=${SONAR_AUTH_TOKEN}
                        """
                    }
                }
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
