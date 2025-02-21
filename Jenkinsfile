pipeline {
    agent any  // Herhangi bir ajan kullanılabilir, ancak belirli bir ajan seçebilirsiniz.

    tools {
        // .NET SDK'yı buradaki sürüm numarasını belirterek kullanıyoruz.
        dotnet 'dotnet-sdk-9.0.102'  // SDK'nın doğru sürüm numarasını buraya yazın.
    }

    stages {
        stage('Checkout') {
            steps {
                // GitHub reposundan kodu çekme
                git 'https://github.com/CerenT07/ProjectTest.git'  // Buraya kendi repo URL'nizi yazın
            }
        }

        stage('Set up .NET Core') {
            steps {
                script {
                    // .NET Core SDK'yı yüklemek için gerekli PowerShell komutlarını çalıştırıyoruz
                    bat 'powershell -Command "Invoke-WebRequest https://dotnet.microsoft.com/download/dotnet-core/scripts/v1/dotnet-install.ps1 -OutFile dotnet-install.ps1"'
                    bat 'powershell -Command "Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser -Force"'  // ExecutionPolicy ayarlarını yapıyoruz
                    bat 'powershell -Command ".\\dotnet-install.ps1 -Channel 9.0.102"'  // Sabit sürüm numarası ile kurulum
                    bat 'dotnet --version' // Yüklenen .NET sürümünü doğrulamak için
                }
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
