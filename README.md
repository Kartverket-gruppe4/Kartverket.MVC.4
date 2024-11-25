# Admin Access Credentials:
## username: admin@mail.com
## password: admin123

# Project Title: Kartverket
*Date: 25.11.24*  

# Demonstration of the Application: 
https://youtu.be/ivGk9-J2QOk

## Project Description  
This project aims to develop a 'Crowd Sourcing' solution that will assist Kartverket in updating and improving map data. The solution allows users to submit error reports related to geographic locations, such as missing or incorrect information about roads, hiking trails, and place names. These reports are stored securely in a MariaDB database and processed by caseworkers at Kartverket. The database structure is designed for efficient querying, and to provide valuable insights into user submissions, caseworker performance, and map data.

## Key Hightlights:
- **Purpose**: To provide an easy-to-use platform where everyone regardless of their age or digital competence can easily send report errors or missing information in Norway's map data. 
- **Problems Solved**: This solution simplifies error reporting for ordinary users by removing the mandatory category selection at the start of the process, reducing the effort and knowledge required to submit a report. The system also keeps users informed by allowing them to view the status of their reports and stay involved throughout the process.The solution helps Kartverket quickly identify and correct issues in the map data. This leads to more accurate, up-to-date maps that can benefit both the public and businesses that rely on geographic data.
- **Target Audience**: The general public, including people of all ages and technical background. Caseworkers at Kartverket, providing a tool to process reports and communicate feedback. 

## Use Scenarios
### Scenario 1: Submitting Map Correction 
Users can submitt map corrections by drawing on the map using tools such as points, lines, or shapes. They must provide a description of the issue and select a category. The system automatically associates the correction with the correct municipality based on the coordinates. 
### Scenario 2: Tracking Submission Status 
After submitting a map correction, users can view the status of their submission in "Mine Feilmeldinger". They can check if it is received, started, or completed. 
### Scenario 3: Processing Submissions by Caseworkers 
Caseworkers can view and sort user-submitted corrections on the admin dashboard by category, submission date, and status. They can update the status, which will automatically reflect on the user's submission.
### Scenario 4: User-Friendly Interface and Mobile Access
The platform is a user-friendly interface for both submitters and caseworkers. Both submitters and caseworkers can access the system on mobile and desktop devices, with a responsive design. 

## Expandable Structure
The project is designed with the potential to grow and evolve to meet future needs, and being open source allows for customization to suit specific requirements. 

Katrtverket. (2024).*Prosjektoppgave Kartverket.pdf*. https://uia.instructure.com/courses/16039/pages/group-project-guidelines

# Technical Requirements and Fulfillment 
To ensure the project's success, the following technologies and tools are implemented and fulfilled:
- GitHub
- ASP.NET Core
- C#
- HTML
- JavaScript
- CSS
- NuGet Package Manager
- Docker
- SQL Server Management
- Mariadb
- Rider/Visual Studio
- Leaflet

## Programming Language and Version 
**Programming language:** C#

**Version:** .NET 8.0

## Account Controller
The AccountController in our application manages user authentication and registration. It uses ASP.NET Core Identity to provide secure access to the application, with functionality for logging in, registering new accounts, and logging out.

## Used Libraries and Technologies
- ASP.NET Core Framework:
  - Framework for building scalable .NET Core-based web applications.
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
  - Library for integrating ASP.NET Core Identity with Entity Framework Core.
- Microsoft.EntityFrameworkCore
  - ORM library for working with databases in .NET applications using strongly typed models.
- Microsoft.EntityFrameworkCore.Design
  Tools for design-time support in Entity Framework Core, such as migrations.
- Microsoft.EntityFrameworkCore.Relational
  - Provides relational database functionality for Entity Framework Core.
- Microsoft.EntityFrameworkCore.Tools
  - Command-line tools for managing Entity Framework Core, including migrations and scaffolding.
- Microsoft.Extension.Http
  - Extensions for working with HTTP clients in .NET Core applications.
- Microsoft.Extensions.Looging.Abstractions
  - Provides interfaces for logging across various .NET Core components.
- Microsoft.NET.Test.Sdk
  - Testing SDK for .NET projects, supporting unit and integration tests.
- Microdoft.VisualStudio.Azure.Containers.Tools
  - Tools for developing, debugging, and deploying containerized applications with Azure.
- Newtonsoft.Json
  - Library for working with JSON data in .NET applications.
- xunit
  - Unit testing framework for .NET, supporting modern testing practices.
- xunit.runner.visualstudio
  - Visual Studio integration for running and reporting xUnit tests.
- NSubstitute
  - Library for creating test doubles (mocks and stubs) in .NET tests.
- Pomelo.EntityFrameworkCore
  - MySQL database provider for Entity Framework Core.
- Dapper
  - Lightweight ORM for .NET, focusing on fast and simple database access.

# Database 
The database is connected to the application through docker using MariaDB. The database is designed to efficiently store and manage the map error submissions and user information.  
- Database: SQL Server
- Connecting Method: Entity Framework
   

# Architectural Structure

The application is build using the Model-View-Controller (MVC) pattern, which divides the system into three core components. This structure makes the application easier to manage by dividing it into seperate part, each with a clear role. This improves flexibility, simplifies updates, and keeps different functions organized.  

## Model

Defines the structure and behavior of the data, manages its state, and interacts with the database or external data sources to retrieve and store information.
 <pre> 
     
 ## Models 
 
│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **MinSide**
│   │   ├── ApplicationDbContext.cs
│   │   ├── ErrorViewModel.cs
│   │   ├── KommuneInfoViewModel.cs
│   │   ├── MapCorrectionModel.cs    

</pre>

## View

Responsible for the presentation layer of the application (UI). It displays data provided by the model to the user, ensuring an intuitive and accessible interface for users.
 <pre>
 ## Views 

│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **MinSide**  
│   │   ├── **Shared** 
│   │   ├── ViewImports.cshtml   
│   │   ├── ViewStart.cshtml        

      </pre>    


## Controller

Serves as the intermediary between the model and the view. Manages user intercations, processes HTTP requests, and updates the model or view accordingly.
 <pre>
## Controllers
    
│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **MinSide**
│   │   ├── MapCorrectionsController.cs

</pre>

# Project Folders and file structures 
The directory structure below illustrates how the application project is organized. Each folder and file serves a distinct purpose, ensuring an organized project management.  

<pre>
Mapstructure for Kartverket.MVC.4
  
│   ├── ## wwwroot         
│   │   ├── **css** 
│   │   │   ├── Logginn.css
│   │   │   ├── popup.css
│   │   │   ├── Register.css
│   │   │   ├── site.css
    │   │   │   ├── table-style.css
│   │   ├── **Fonts** 
│   │   ├── **img**  

│   ├── ## API Models      
│   │   ├── Apisettings.cs
│   │   ├── KommuneInfo.cs

│   ├── ## Controllers      
│   │   ├── **Account**
│   │   │   ├── (files related to user account processes such as registration, log in and log out)
│   │   ├── **AdminFeilmelding**
│   │   │   ├── (files related to admin-error-handling and managment)
│   │   ├── **Feilmelding**
│   │   │   ├── (files related to error-handling-process such as saving error submissions, overview and delete them)
│   │   ├── **HjelpKontakt**
│   │   │   ├── (files related to help and contact functionalities)
│   │   ├── **Home**
│   │   │   ├── (files related to homepage)
│   │   ├── **MinSide**
│   │   │   ├── (files related to the user's personal dashboard, including error submissions and log-out)
│   │   ├── MapCorrectionsController.cs

│   ├── ## Migrations  
│   │   ├── (files related to database-migrations)

│   ├── ## Models  
│   │   ├── **Account**
│   │   │   ├── (files related to user account data, such as registration, login and user identity)
│   │   ├── **AdminFeilmelding**
│   │   │   ├── (files related to admin-error-models)
│   │   ├── **Feilmelding**
│   │   │   ├── (files related to general error-models including map-data and user-data)
│   │   ├── **HjelpKontakt**
│   │   │   ├── (files related to help and contact models)
│   │   ├── **Home**
│   │   │   ├── (files related to homepage datamodels, including properties)
│   │   ├── **MinSide**
│   │   │   ├── (files related to user-specific models such as view-models for handling data on "Min Side")
│   │   ├── ApplicationDbContext.cs
│   │   ├── ErrorViewModel.cs
│   │   ├── KommuneInfoViewModel.cs
│   │   ├── MapCorrectionModel.cs

│   ├── ## Services   
│   │   ├── (files related to application services including FeilmeldingService for error reports and KommuneinfoService for municipality data)

│   ├── ## Views 
│   │   ├── **Account**
│   │   │   ├── (files related to user authentication, including login and registration form, validation, and user account management)
│   │   ├── **AdminFeilmelding**
│   │   │   ├── (files related to admin-interface for managing and filtering error reports, including viewing and updating status)
│   │   ├── **Feilmelding**
│   │   │   ├── (files related to handling error reports in the application)
│   │   ├── **HjelpKontakt**
│   │   │   ├── (files related to help and contact functionalities)
│   │   ├── **Home**
│   │   │   ├── (files related to viewing the homepage)
│   │   ├── **MinSide**  
│   │   │   ├── (files related to viewing the "Min Side"-page including the user's profile information, options to report issues, and logout)
│   │   ├── **Shared** 
│   │   │   ├── _Layout.cshtml
    │   │   ├── _ValidationScriptsPartial.cshtml
│   │   │   ├── _Error.cshtml
│   │   ├── _ViewImports.cshtml    
│   │   ├── _ViewStart.cshtml    

│   ├── .editorconfig

│   ├── appsettings.json

│   ├── DockerFile

│   ├── libman.json      

│   ├── Program.cs
</pre>


# Installation Guide
Follow the instructions below:   
## 1. Clone the repository**  
  Clone the project to your local machine by running the folloing command in your terminal: 
  git clone https://github.com/Kartverket-gruppe4/Kartverket.MVC.4.git
## 2. Update Database
   dotnet ef database update
## 3. Run the project:
   dotnet run 
## 4. Start with Docker:
  You can run the project with the appropriate docker-compose file:
  
  **Windows:** docker-compose -f docker-compose.yml -f docker-compose.override.windows.yml up
  
  **Mac:** docker-compose -f docker-compose.yml -f docker-compose.override.mac.yml up

# Security and Authorization  
**CSRF Protection**
- To prevent CSRF attacks, we use ASP.NET Core’s built-in support, including CSRF tokens ([ValidateAntiForgeryToken]) for all forms and POST requests, validated on the server.

**XSS Protection**
- Input Validation: User input is validated using annotations like [RegularExpression], [Required], and [EmailAddress] to ensure only allowed characters are accepted.
- HTML Encoding: ASP.NET Core automatically encodes data shown in views to prevent malicious scripts from executing.
- Example: Email addresses are validated using regex and [EmailAddress], rejecting any attempts to inject scripts.

**Authentication and Authorization**
- Authentication: We use ASP.NET Core Identity for user registration and login, with securely hashed passwords.
- Authorization: Role-based access distinguishes between regular users (who can submit reports) and administrators (who can manage and process reports). Currently, there is only one admin role with no functionality for assigning caseworker roles, but this can be expanded in the future.

**HTTPS**
- HTTPS is required for all connections, ensuring encrypted data transfer between the client and server.

# Unit Test 
Unit tests were implemented using NSubstitute, xUnit, and Moq. These tools allowed us to isolate components and validate their functionality under different scenarios. The figure below illustrates the results from the unit tests executed for the application. 

<img width="602" alt="Skjermbilde 2024-11-25 kl  13 04 52" src="https://github.com/user-attachments/assets/4c9924d2-f73b-4629-b102-e60a2384b90f">

# Contributors
### - Andrea Vågen (https://github.com/andreavaagen)
### - Anna Martine Østmoen (https://github.com/annaoestmoen)
### - Eline Widvey (https://github.com/ElineWi)
### - Olivia Fledsberg Petterøe (https://github.com/Oliviapetteroe)
### - Thea Svele Corneliussen (https://github.com/SveleThea)
### - Vilde Christensen (https://github.com/Vildech)
