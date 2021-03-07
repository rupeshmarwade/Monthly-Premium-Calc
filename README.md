##Tal monthly premium calculator Overview

## This application have two different technologies used in development. .net core for backend service and Angular for front end

##Building Tal Monthly calculator

###Angular App

####Pre-Requisites
Latest version of node.js
Use cmd prompt and change current directory to folder where angular project is copied. Use Npm install to install all npm packages.
use angular ng build command to build angular project

### .net core api
.net core 3.1 installed 
use command prompt to change directory to .net core api project
use .net core command to build .net core app 'dotnet build'

### starting application

.net core app
use command promt to use dot net commands
Use dotnet run command prmpt to start .net core app
Assumption: As this project doesn' have any secret data and neither server stores any data henceit's open to all
It has in memeory databse which has few occupation and provider


angular app
use command promt to start ng serve command which will launch angular ui



Architectures used:

>net core
Clean architesture along with repository pattern.
Infrastructre
CoreApplication
Web


Angular
Loggingservice to log details/info/errors/warns  depening upong environment
generalize centric httpclient service to easily implment httpclient
all componenets have their own services
