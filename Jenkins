node{

    stage 'clean'
    deleteDir()
    
    stage 'checkout'
    checkout scm
    
    stage 'docker: build'
    bat label: '', script: 'docker build -t doctor-portal-jenkins .'
    
    stage 'docker: remove old container'
    bat label: '', script: 'docker container rm -f docker-app'
    
    
    stage 'docker: spin up new container'
    bat label: '', script: 'docker run -d --rm --name=docker-app  -p 1235:80 doctor-portal-jenkins'
    
}