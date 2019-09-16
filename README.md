# BackendAssignment

# Link of the Project Document: https://drive.google.com/file/d/19M--wZY7i9UeJi53uoHFrKNqBnyUPGUN/view

# Link of the Demo Video: https://vimeo.com/user48138005/review/360176688/6df7360346

# Technologies
* Asp.Net Core Web Api (v 2.2) - Built with Visual Studio 2019 Community (v 16.2.0)
* Sql server for DB
* Angular 6 for client app - Latest node.js installation recommended

# How to start the API
1) Clone the project
2) Build the solution
3) Open Package Manager Console on the Visual Studio, set ClayBackendCase.API.Infrastructure as Default project on the Package Manager Console and type "update-database". Wait for the DB creation. It uses default connection on the appsetting.json.
4) It uses https://localhost:44377 as the default port. It is configurable from the launchSettings.json file. (Don't forget to update client project apiUrl from the webpack.config.json file)


# Link of the client App: https://github.com/alpersilistre/BackendAssignment-Client

# How to start the client
1) npm install on the project main folder
2) npm start
