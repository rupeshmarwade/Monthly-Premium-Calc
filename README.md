##Tal monthly premium calculator Overview
This application has two different technologies used in development. .net core for backend service and Angular for front end
##Build Tal Monthly calculator
###Angular App
*Pre-Requisites
	1. Latest version of node.js
Build Steps:
	1. Use cmd prompt and change current directory to folder where angular project is copied. 
	2. Use Npm install to install all npm packages. (.\TAL\angularapp\premium-calculator>npm install)
	3. Use angular ng build command to build angular project.

### .net core api
*Pre-Requisites
	1. .net core 3.1 installed. 
Build Steps:
	1. Use cmd prompt to change directory to .net core api project.
	2. Use .net core command to build .net core app 'dotnet build'
	Or
	Use visual studio to open solution Tal.sln and build solution (Build solution will trigger nuget package restore)

### starting application
## Background service
	Assumption: As this project do not have any secret data and neither server stores any data hence it is open to all. 
	It has in memory database which has few occupations.
	Steps:
		1. Use visual studio to open Tal.sln
		2. set webapi as startup project
		3. Run it from visual studio.
(You can run this project from cmd prompt but then it will start on another port that I have not configured in angular)

## front end app
	1. Use cmd prompt and change current directory to folder where angular project is copied. (\TAL\angularapp\premium-calculator>)
	2. Use command prompt to start ng serve command which will launch angular ui. 
In this angular project I have hard coded background url to connect to api on certain port.


Assumption
1. No Authentication/Authorization

Architecture
1. This project is developed using Repository pattern and clean layered architecture.
2. Resource names are given as per noun with appropriate meaning to consumers.
3. General flow
  a. Fluent validation validates request.
  b. if it is good request it is send to web application service for processing.
  c. depending on domain then request gets converted to required domain entity.
  d. It is then send to that domain specific application core for processing.
  e. web application receive response in domain which it translates to dto and send back to user.
  f. there are different level of logging and web request intercept can possibly happen to short circuit request in case of issues/exceptions.
  
 Angular
1. Logging service to log details/info/errors/warns depending upon environment
2. generalize centric httpclient service to easily implement httpclient
3. Shared module
4. Has not implemented lazy loading for this small app
