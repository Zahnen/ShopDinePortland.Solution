# ShopDinePortland
### A REST API written in C# with ASP.NET, January 22, 2021

#### By [Zahnen Garner](https://www.github.com/zahnen)

---  

_ShopDinePortland is a REST API that allows users to access a database of shops and restaurants in Portland, Oregon. Users with the "user" role are able to process GET requests (view) all data within the API, however PUT, POST, and DELETE (create, edit, delete) functionality is enabled for "admin" users. The ShopDinePortland API was created as an independent project while studying at Epicodus. The API was written to apply concepts I learned this week which include the basics of writing a REST API with ASP.NET & C#, JWT authentication, and implementing CRUD functionality with HTTP requests._  

---  

## 🔧 Setup/Installation Instructions

Running this project locally requires:
- A code editor such as [VisualStudio Code](https://code.visualstudio.com/) 
- [ASP.NET Core](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [MySQL/MySQL Workbench](https://www.mysql.com/).
- A loose familiarity with MySQL databases & navigating through local files using your command line program such as Terminal or Gitbash (e.g., "cd Desktop").

Please ensure all of the aforementioned softwares are installed on your device or refer to the previous links to begin installation. If you have questions on the installation process, please don't hesitate to [reach out!](mailto:zahnen@gmail.com)

### 1. Clone or Download the project:

#### To Clone:
- Open your preferred command line program.
- Navigate to the location or directory you'd like the project directory to be created in. (e.g., "cd Desktop" if you'd like to clone the project to your desktop)
- Enter the command "$ git clone https://github.com/Zahnen/ShopDinePortland.Solution" in your command line.

#### To Download:
- Navigate to the [project repository](https://github.com/Zahnen/ShopDinePortland.Solution) in your browser.
- Click the green "Code" button toward the top right of the page.
- Click "Download ZIP" and extract the files.
- Open the newly-downloaded project in your preferred code editor.


### 2. Establish a MySQL database for using the project:

#### Code-First migration with EF Core (Preferred):

- Create a file at the root level of the directory named "appsettings.json" _Note: This file is included in this repository for the purposes of submitting the project as a graded assignment. If you elect to move forward with code-first migration with EF Core, you may simply replace the contents of this file rather than create a duplicate "appsettings.json" file._
- Add the following code into the appsettings.json file

```
{
  "AppSettings": {
    "Secret": "[ENTERSECRETHERE]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[ENTERDATABASENAMEHERE];uid=[ENTERUSERIDHERE];pwd=[ENTERPASSWORDHERE];"
  }
}

```
- Replace the [ENTERSECRETHERE] placeholder with a secret of your choosing. _Note: Secrets must be a minimum of 16 characters_
- Replace the [ENTERDATABASENAMEHERE], [ENTERUSERIDHERE], and [ENTERPASSWORDHERE] placeholders with your desired database name + your user information associated with your local MySQL server.
- Navigate to the directory titled "ShopDinePortland" within the root directory created when cloning the project.
- Run the command "dotnet ef database update" to establish the database in MySQL using the migrations included with this repository (suggested).
- If you choose to modify the database by altering the model logic of this project, save all changes and then run the command "dotnet ef migrations add [ENTERMIGRATIONNAMEHERE]" within the "ShopDinePortland" directory to create a new migation using EF Core. Replace [ENTERMIGRATIONNAMEHERE] with whatever you'd like to name this migration. Follow this by running the command "dotnet ef database update" to update the MySQL database with your changes. You will need to create a new migration _and_ update the MySQL database each time you modify elements of the existing database within the code.
- Verify that your newly establish database exists within your MySQL Workbench before proceeding (you may need to right click the explorer and click "Refresh All" to see the new database).


### 3. Run the project:

- Once the project is cloned and the MySQL database is established, use your preferred command line program to navigate to the directory titled "ShopDinePortland" within the root directory created when cloning the project.
- To run the server that will host the API, enter "dotnet build" in your command line while still within the "ShopDinePortland" directory. Follow this command with "dotnet run"
- Your command line will open a server (likely "http://localhost:5000/"). This is the server you will use to access the endpoints of the API in a program such as [Postman](https://www.postman.com/).

---  

# 🗺️ API Documentation/Endpoint Information
In order to explore the endpoints of this API, we suggest that you use [Postman](https://www.postman.com/). Postman will allow you to make GET, POST, PUT, and DELETE requests with the TravelrApi.

## JWT Web Token Authorization

- ShopDinePortland API uses JWT Web Tokens to authorize users based on their user roles. "User" users are able to make GET requests only, whereas "Admin" users are able to make POST, PUT, and DELETE in addition to GET requests. You will need to authorize a user in order to access any endpoints within the API.
- To receive an authorization token, you will first need to authenticate a user in either an "Admin" or "User" role. For the purposes of this API demo, user paramaters have been generated for both roles. Please refer to the below authentication instructions based on the user role you'd like to create. To explore all CRUD functionality, it is recommended that you use the "Admin" user.

### "Admin" User Creation

- Open [Postman](https://www.postman.com/).
- Create a POST request to http://localhost:5000/api/users/authenticate
- Navigate to the "Body" tab of your request and select "Raw Data" from the offered options followed by "JSON" in the dropdown to the right of your selection. Enter the following code snippet into the body field
```
{
  "Username": "admin",
  "Password": "admin"
}
```
The response will generate a bearer token. Copy this token for use when you create a new request (GET, POST, DELETE, PUT). When creating a new request following receipt of your token, navigate to the "Authorizations" tab of the request. Select "Bearer Token" as the authorization type, and paste your copied token into the "Token" field. This token will authorize all HTTP requests for Restaurants, Shops, and Users.

### "User" User Creation

- Open [Postman](https://www.postman.com/).
- Create a POST request to `http://localhost:5000/api/users/authenticate`
- Navigate to the "Body" tab of your request and select "Raw Data" from the offered options followed by "JSON" in the dropdown to the right of your selection. Enter the following code snippet into the body field
```
{
  "Username": "user",
  "Password": "user"
}
```
The response will generate a bearer token. Copy this token for use when you create a new GET request. When creating a new request following receipt of your token, navigate to the "Authorizations" tab of the request. Select "Bearer Token" as the authorization type, and paste your copied token into the "Token" field. This token will authorize your GET requests for Restaurants, Shops, and Users only. 


## Endpoints

Base URL : `http://localhost:5000`

### HTTP Request Structure

#### Restaurant Request Structure

```
GET /api/restaurants
POST /api/restaurants
GET /api/restaurants{id}
PUT /api/restaurants{id}
DELETE /api/restaurants{id}
```
#### Shop Request Structure

```
GET /api/shops
POST /api/shops
GET /api/shops{id}
PUT /api/shops{id}
DELETE /api/shops{id}
```

### Path Parameters

#### Restaurant Parameters

| Parameter | Type | Default | Required | Description |
| :------------- | :------------- | :------------- | :------------- |:------------- |
| name | string | none | false | Return matches by restaurant name |
| cuisine | string | none | false | Return matches by cuisine style (Italian, American) |
| service | string | none | false | Return matches by service style (to-go, casual dining, etc) |
| neighborhood | string | none | false | Return matches by neighborhood name |

#### Example Restaurant Query

`http://localhost:5000/api/restaurants/?cuisine=italian`

### Sample Restaurant JSON Response

```
{
  "restaurantId": 2,
  "name": "DeNicola's",
  "cuisine": "Italian",
  "service": "Casual Dining",
  "neighborhood": "Southeast"
}
```

#### Shop Parameters

| Parameter | Type | Default | Required | Description |
| :------------- | :------------- | :------------- | :------------- |:------------- |
| name | string | none | false | Return matches by shop name |
| type | string | none | false | Return matches by type of shop (clothing, antiques) |
| neighborhood | string | none | false | Return matches by neighborhood name |

#### Example Shop Query

`http://localhost:5000/api/shops/?type=antiques&neighborhood=sellwood`

### Sample Shop JSON Response

```
{
  "shopId": 4,
  "name": "Stars Mall",
  "type": "Antiques",
  "neighborhood": "Sellwood"
}
```

---  

## ❗ Known Bugs/Issues

There are no known bugs or issues at this time. If you come across any, please let me know by [emailing me](mailto:zahnen@gmail.com).

---  

## ❓ Support and Contact Details

- Zahnen Garner // zahnen@gmail.com

---  

## 💻 Technologies Used

_This application required use of the following programs/languages/libraries/documentation to create:_
- _[Microsoft Visual Studio Code](https://code.visualstudio.com/)_
- _[Git/GitHub](https://github.com/)_
- _[C#](https://docs.microsoft.com/en-us/dotnet/csharp/)_
- _[.NET Core v 2.2](https://dotnet.microsoft.com/download)_
- _[ASP.NET Identity](https://docs.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity)_
- _[EF Core](https://docs.microsoft.com/en-us/ef/core/)_
- _[MySQL/My SQL Workbench](https://www.mysql.com/)_
- _[Postman](https://www.postman.com/)_
- _[Bootstrap](https://getbootstrap.com/)_
- _[CSS](https://developer.mozilla.org/en-US/docs/Learn/CSS)_
- _[JWT Authentication Tutorial](https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api) by [Jason Watmore](https://github.com/cornflourblue)_

---  

## 📃  License

*Licensed under MIT*

Copyright (c) 2020 Zahnen Garner