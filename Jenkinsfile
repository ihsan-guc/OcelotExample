def gv

pipeline {
     environment {
        COMPOSE_FILE = "docker-compose.yml"
    }
    agent any 
    stages {
         
        stage("tooling version") {
            steps {
                sh ''' 
                    docker --version
                    docker-compose version
                '''
            }
        } 
        stage("init") {
            steps {
                 echo "Testting"
                sh "docker context use default"
                sh "docker context use default"
            }
        }
        stage("build") {
            steps {
                echo "Testting"
            }
        } 
        stage("deploy") {
            steps {
                echo "Testting"
            }
        }
    }   
}
