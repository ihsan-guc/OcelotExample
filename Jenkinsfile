def gv

pipeline {
     environment {
        COMPOSE_FILE = "docker-compose.yml"
    }
    agent any 
    stages {
        stage("init") {
            steps {
                sh "docker-compose -f ${env.COMPOSE_FILE} build"
                echo "Testting"
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
