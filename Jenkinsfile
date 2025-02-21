pipeline {
    agent any

    tools {
        dotnet 'dotnet-sdk-9.0.102'  // Burada tanımladığınız SDK sürümünü yazın
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/CerenT07/ProjectTest.git'
            }
        }

        stage('Restore Dependencies') {
            steps {
                bat 'dotnet restore Project/Project.csproj'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build Project/Project.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test Testing/Testing.csproj --configuration Release --no-build --verbosity normal --logger "xunit;LogFilePath=test-results.xml"'
                junit '**/test-results.xml'
            }
        }
    }

    post {
        always {
            cleanWs()
        }
        success {
            echo 'Pipeline başarılı oldu!'
        }
        failure {
            echo 'Pipeline başarısız oldu.'
        }
    }
}
