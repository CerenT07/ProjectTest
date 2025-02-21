pipeline {
    agent any  // Herhangi bir ajan kullanılabilir

    stages {
        stage('Checkout') {
            steps {
                // GitHub reposundan kodu çekme
                git 'https://github.com/CerenT07/ProjectTest.git'  // Buraya kendi repo URL'nizi yazın
            }
        }

        stage('Restore Dependencies') {
            steps {
                // Ana proje bağımlılıklarını yükleme
                script {
                    bat 'dotnet restore Project/Project.csproj'  // Ana projeyi restore ediyoruz
                }
            }
        }

        stage('Build') {
            steps {
                // Ana projeyi derleme
                script {
                    bat 'dotnet build Project/Project.csproj --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                // Testleri çalıştırma
                script {
                    // Test projelerini çalıştırıyoruz
                    bat 'dotnet test Testing/Testing.csproj --configuration Release --no-build --verbosity normal --logger "xunit;LogFilePath=test-results.xml"'
                    junit '**/test-results.xml'  // Test sonuçlarını junit formatında al
                }
            }
        }
    }

    post {
        always {
            // Çalışma dizinini temizler
            cleanWs()
        }
        success {
            // Başarı durumunda yapılacak işlemler
            echo 'Pipeline başarılı oldu!'
        }
        failure {
            // Başarısız durumda yapılacak işlemler
            echo 'Pipeline başarısız oldu.'
        }
    }
}
