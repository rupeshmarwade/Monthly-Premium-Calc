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
Or
Use visual studio to open solution Tal.sln and build solution (Build solution will trigger nuget package restore)

### starting application

.net core app
use command promt to use dot net commands
Use dotnet run command prmpt to start .net core app
Assumption: As this project doesn' have any secret data and neither server stores any data hence it is open to all. 
It has in memeory databse which has few occupation and provider

Please use visual studio and set webapi as startup project and run it from visual studio
(You can run this project from cmd prompt but then it will start on another port that I have not configured in angular)

angular app
use command promt to start ng serve command which will launch angular ui. This angular project I have hard coded at present to connect to api on certain port.


Assumption
1. Not added submit button as on dropdown premium needs to be caluculated.


Architecture
1. This project is developed using mix of few deisgn pattern. Repository pattern and clean layered architecturr. (do not share domain entitities with views) all database access is in Infrastructure. It has all it's project decoupled from each other and can be replaced with better technology.
2. Resource names are given as per noun with appropriate meaning to consumers
3. General flow
  a. Fluent validation validates request
  b. if it is good request it is send to web application service for processing
  c. depending on domain then request gets converted to required domain entity
  d. It is then send to that domaon specific application core for processing
  e. web application receive response in domain which it translet to dto and send back to user
  f. there are different level of logging and web request intercept can possibly happene to short circuit request in case of issues/exceptions
  
 Angular
1. Loggingservice to log details/info/errors/warns  depening upong environment
2. generalize centric httpclient service to easily implment httpclient
3. Shared module
4. Has not implemented lazy loading for this small app
