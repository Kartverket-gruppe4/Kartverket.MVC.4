- **Dokumentasjon** i Github om drift, systm arkitektur og testing scenarier og resultater, i tillegg til dokumentasjonen i selve koden.
- Legg til log in passord for admin hvis vi har det her oppe. 

# Project Title: Kartverket
*Date: 25.11.24*  

# Demonstration of the Application: 
Linke her (Den vi brukte i Deliverable 4 eller en ny som viser alle oppdateringen!!!!)

## Project Description  
This project aims to develop a 'Crowd Sourcing' solution that will assist Kartverket in updating and improving map data. The solution allows users to submit error reports related to geographic locations, such as missing or incorrect information aboud roads, hiking trails, and place names. These reports are stored securely in a MariaDB database and processed by caseworkers at Kartverket. The database structure is designed for efficient querying, and to provide valuable insights into user submissions, caseworker performance, and map usage trends.

## Key Hightlights:
- **Purpose**: To provide an easy-to-use platform where everyone regardless of their age or digital competence can easily send report errors or missiong information in Norway's map data. 
- **Problems Solved**: The solution helps Kartverket quickly identify and correct issues in the map data. This leads to more accurate, up-to-date maps that can benefit both the public and businesses that rely on geographic data.
- **Target Audience**: The general public, including people of all ages and technical background. Caseworkers ad Kartverket, providing a tool to process reports and communicate feedback. 

## Use Scenarios
### Scenario 1: Submitting Map Correction 
Users can submitt map corrections by drawing on the map using tools such as points, lines, or shapes. They must provide a description of the issue and select a category. The system automatically associates the correction with the correct municipality based on the coordinates. 
### Scenario 2: Tracking Submission Status 
After submitting a map correction, users can view the status of their submission in "Mine Feilmeldinger". They can check if it is received, started, or Completed. 
### Scenario 3: Processing Submissions by Caseworkers 
Caseworkers can view and sort user-submitted corrections on the admin dashboard by category, submission date, and status. They can update the status, which will automatically reflect on the user's submission.?????????
### Scenario 4: User-Friendly Interface and Mobile Access
The platform is a user-friendly interface for both submitters and caseworkers. Both submitters and caseworkers can access the system on mobile and desktop devices, with a responsive design. 

## Expandable Structure (Er dette bra????????) 
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

# NOE I MELLOM HER???
- I eksempelet har de Constructor med
    - Account controller
        - Registration
        - Login
        - Logout
    - Service
       - Det vi har kanskje??

## Used Technologis and Libraries
**LISTE MED ALLE PAKKER, INSTALASJONER OG AVHNEGIGHETER** ?????
SKRIV BESKRIVELSE OG SJEKK MED DE ANDRE!!!!!!!!!!!!!!!!!!
- ASP.NET Core Framework:
  - Framework used for .NET Core-based web applications.
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Relational
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extension.Http
- Microsoft.Extensions.Looging.Abstractions
- Microsoft.NET.Test.Sdk
- Microdoft.VisualStudio.Azure.Containers.Tools
- Newtonsoft.Json
- xunit
- xunit.runner.visualstudio
- NSubstitute
- Pomelo.EntityFrameworkCore
- Dapper

# Databse 
The database is connected to the application through docker using MariaDB. The database is designed to efficiently store and manage the map error submissions and user information.  

**(Skal dette være med?? er fra eksmepel)**
- Database: SQL Server
- Connecting Method: Entity Framework

**I eksempelet har de også med:**????????
- Project Configuration File Examples
- Project Dependencies 
    

# Architectural Structure: MVC Pattern

The application is build using the Model-View-Controller (MVC) pattern, which divides the system into three core components. This structure makes the application easier to manage by dividing it into seperate part, each with a clear role. This improves flexibility, simplifies updates, and keeps different functions organized.  

## Model

Represents the application  s data structure  (ER DETTE BRA?)
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

Handles the user interface (UI), displaying data to the user (ER DETTE BRA?)
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

      </pre>    


## Controller

Manages user intercations, processes HTTP requests, and updates the model or view accordingly.  (ER DETTE BRA?)
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


# DETTE ER FRA EKSEMPEL (HVA SKAL VI HA HER??) 
# Main Components and Interactions of the Application
## Identity Service
## Migration for Adding Identity Tables
## Tables Created
## How to Apply the Migration
## How to Rollback the Migration
## Database Connection
## Docker
## Swagger and Notyf Service
## Email Sending Service
## ServiceSkjemaService



# Project Folders and file structures 
The directury structure below illustrates how the application project is organized. Each folder and file serves a distinct purpose, ensuring an organized project management.  
- **Sjekk at alt er oppdatert i mappestrukturen!!!!!**
- Mapstructure for Kartverket.MVC.4
- **Fiks opp slik at det inkludere (files related to ...) for alle mappene!!**

<pre>
│   ├── ## wwwroot         
│   │   ├── **css**        
│   │   │   ├── popup.css
│   │   │   ├── site.css
│   │   ├── **Fonts** 
│   │   ├── **img**  

│   ├── ## API Models      
│   │   ├── Apisettings.cs
│   │   ├── KommuneInfo.cs

│   ├── ## Controllers      
│   │   ├── **Account**
│   │   │   ├── (files related to user accounts processes)
│   │   ├── **AdminFeilmelding**
│   │   │   ├── (files related to admin)
│   │   ├── **Feilmelding**
│   │   │   ├── (files related to 
│   │   ├── **HjelpKontakt**
│   │   │   ├── (files related to 
│   │   ├── **Home**
│   │   │   ├── (files related to 
│   │   ├── **MinSide**
│   │   │   ├── (files related to 
│   │   ├── MapCorrectionsController.cs

│   ├── ## Migrations  
│   │   ├── (files related to 

│   ├── ## Models  
│   │   ├── **Account**
│   │   │   ├── (files related to 
│   │   ├── **AdminFeilmelding**
│   │   │   ├── (files related to 
│   │   ├── **Feilmelding**
│   │   │   ├── (files related to 
│   │   ├── **HjelpKontakt**
│   │   │   ├── (files related to 
│   │   ├── **Home**
│   │   │   ├── (files related to 
│   │   ├── **MinSide**
│   │   │   ├── (files related to 
│   │   ├── ApplicationDbContext.cs
│   │   ├── ErrorViewModel.cs
│   │   ├── KommuneInfoViewModel.cs
│   │   ├── MapCorrectionModel.cs

│   ├── ## Services   
│   │   ├── (files related to 

│   ├── ## Views 
│   │   ├── **Account**
│   │   │   ├── (files related to 
│   │   ├── **AdminFeilmelding**
│   │   │   ├── (files related to 
│   │   ├── **Feilmelding**
│   │   │   ├── (files related to 
│   │   ├── **HjelpKontakt**
│   │   │   ├── (files related to 
│   │   ├── **Home**
│   │   │   ├── (files related to 
│   │   ├── **MinSide**  
│   │   │   ├── (files related to 
│   │   ├── **Shared** 
│   │   │   ├── Layout.cshtml
│   │   │   ├── Error.cshtml
│   │   ├── ViewImports.cshtml         

│   ├── ## Shared  
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   ├── Error.cshtml

│   ├── .editorconfig

│   ├── appsettings.json

│   ├── DockerFile

│   ├── libman.json      

│   ├── Program.cs
</pre>

# Dependencies and Installation 
## Used Dependencies and Libraries 
Below is a list of all the depencencies and packages used to run this project. 
- Inkluder liste
- Inkluder bilde av detet (Se eksempel)

# Installation Giude ?????????
To get start with this project, make sure to install all the required dependencies. Then, follow the instructions below:   
## 1. Clone the repository**  
  Clone the project to your local machine by running the folloing command in   your terminal: 
   git clone https://github.com/Kartverket-gruppe4/Kartverket.MVC.4.git
## 2. Install Depencencies:???
   dotnet restor 
## 3. Install Entity Framework Tool:????
   dotnet tool install --global dotnet-ef
## 4. Create Migrations:????
   dotnet ef migrations add InitialCreate 
## 5. Update Database:
   dotnet ef database update
## 6. Run the project:
   dotnet run 

**VET IKKE OM DETTE ER RETT ELLER OM DET ER FLERE STEG!!!**
- Configuration File
- Descriptions

# NOE I MELLOM HER??????? (FRA EKSEMPEK) 
# Security and Authorization
- Authentication and Authorization Mechanisms
- User Registration (Register)
- Login
- Role-Based Control (Roles Controller)
- CSRF Protection
- XSS Protection
- Error Tracking and Logging**

**UTKAST** 
## Security and Authorization (Skriv mer om hva vi har brukt)  
- **CSRF Protection:** Ensures users' actions are secure during form submissions.
- **XSS Mitigation:** Input fields are sanitized to prevent script injections.
- **Authentication & Authorization:** Role-based access (e.g., caseworkers vs. public users). User registration and login functionality linked to the database.

# Functionalities in the Application
**User Registration & Authentication
Dashboard Operations**


# Testing 
## Unit Test 
Unit test are implemented using ... 
**RESULTAT???**
## Other Test 

# Contributors !!!!!
### - Andrea Vågen (LINK TIL GITHUB)
### - Anna Martine Østmoen (LINK TIL GITHUB)
### - Eline Widvey (https://github.com/ElineWi)
### - Olivia Fledsberg Petterøe (LINK TIL GITHUB)
### - Thea Svele Corneliussen (LINK TIL GITHUB)
### - Vilde Christensen (LINK TIL GITHUB)

- **DATO FRA VI BEGYNTE TIL VI SLUTTET** 
- **Bilde av contributors fra github (Se eksempel)!!!!**
- **DOKUMENTASJON AV COMMITS (Se eksemepel)**
- **TRAFFIC (SE EKSEMPEL)**
