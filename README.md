- Dokumentasjon i Github om drift, systm arkitektur og testing scenarier og resultater, i tillegg til dokumentasjonen i selve koden.
- Legg til link av oppgaven fra Kartverket
- Legg til log in passord for admin hvis vi har det  

# Project Title: Kartverket
*Date: 25.11.24*  

# Demonstration of the Application: 
Linke her (Den vi brukte i Deliverable 4 eller en ny som viser alle oppdateringen!!!!)

## Project Description  
This project aims to develop a 'Crowd Sourcing' solution that will assist Kartverket in updating and improving map data. The solution allows users to submit error reports related to geographic locations, such as missing or incorrect information aboud roads, hiking trails, and place names. These reports are stored securely in a MariaDB database and processed by caseworkers at Kartverket. The database structure is designed for efficient querying, and to provide valuable insights into user submissions, caseworker performance, and map usage trends.

## Key Hightlights:
- **Purpose**: To provide an easy-to-use platform where everyone regardless of their age or digital competence can easily send report errors or missiong information in Norway's map data. 
- **Problems Solved**: The solution helps Kartverket quickly identify and correct issues in the map data. This leads to more accurate, up-to-date maps that can benefit both the public and businesses that rely on geographic data.
- **Target Audience**: The general public, including people of all ages and technical background. Specially people who want to contribute to improving Norway's map data.  

## Use Scenarios
### Scenario 1: Submitting Map Correction 
Users can submitt map corrections by drawing on the map using tools such as points, lines, or shapes. They must provide a description of the issue and select a category. The system automatically associates the correction with the correct municipality based on the coordinates. 
### Scenario 2: Tracking Submission Status 
After submitting a map correction, users can view the status of their submission in "Mine Feilmeldinger". They can check if it is received, started, or Completed. 
### Scenario 3: Processing Submissions by Caseworkers 
Caseworkers can view and sort user-submitted corrections on the admin dashboard by category, submission date, and status. They can update the status, which will automatically reflect on the user's submission.?????????
### Scenario 4: User-Friendly Interface and Mobile Access
The platform is a user-friendly interface for both submitters and caseworkers. Both submitters and caseworkers can access the system on mobile and desktop devices, with a responsive design. 

## Security and Authorization 
?????

# Technical Requirements and Expectations
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

## Programming Language and Version 
**Programming language:** C# (skal jeg skrive alle her, eller bare hoved?)

**Version:** .NET 8.0????

## Developable and Expandable Structure (annen overskrift????) 
Skiv at den kan bli viderutviklet ...
Inkluder link til oppgaven se eksempel vi fikk 

# NOE I MELLOM HER???????
- 
- 
- 

## Used Technologis and Libraries 
**LISTE MED ALLE PAKKER, INSTALASJONER OG AVHNEGIGHETER** 
- ASP.NET Core Framework:
  - Framework used for .NET Core-based web applications.
    

# Architectural Structure: MVC Pattern

The application is build using the Model-View-Controller (MVC) pattern, which divides the system into three core components. This structure makes the application easier to manage by dividing it into seperate part, each with a clear role. This improves flexibility, simplifies updates, and keeps different functions organized.  

## Model

FORKLARING I FORHOLD TIL VÅR  ... 
 <pre> 
 ## Models 
 
│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **AdminInnboks**
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

FORKLARING I FORHOLD TIL VÅR  ... 
 <pre>
 ## Views 

│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **AdminInnboks**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **Innboks**
│   │   ├── **MinSide**  
│   │   ├── **Shared** 
│   │   ├── ViewImports.cshtml        

      </pre>    


## Controller

FORKLARING I FORHOLD TIL VÅR ... 
 <pre>
## Controllers

│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **AdminInnboks**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **Innboks**
│   │   ├── **MinSide**
│   │   ├── MapCorrectionsController.cs

</pre>


# NOE I MELLOM HER???????
- 
- 
- 


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
│   │   ├── **AdminFeilmelding**
│   │   ├── **AdminInnboks**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **Innboks**
│   │   ├── **MinSide**
│   │   ├── MapCorrectionsController.cs

│   ├── ## Migrations                      

│   ├── ## Models  
│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **AdminInnboks**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **MinSide**
│   │   ├── ApplicationDbContext.cs
│   │   ├── ErrorViewModel.cs
│   │   ├── KommuneInfoViewModel.cs
│   │   ├── MapCorrectionModel.cs

│   ├── ## Services         

│   ├── ## Views 
│   │   ├── **Account**
│   │   ├── **AdminFeilmelding**
│   │   ├── **AdminInnboks**
│   │   ├── **Feilmelding**
│   │   ├── **HjelpKontakt**
│   │   ├── **Home**
│   │   ├── **Innboks**
│   │   ├── **MinSide**  
│   │   ├── **Shared** 
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

# Used Dependencies and Libraries 
Below is a list of all the depencencies and packages used to run this project. 
- Inkluder liste
- Inkluder bilde av detet (Se eksempel) 


# Installation Giude
To get start with this project, make sure to install all the required dependencies. Then, follow the instructions below:   
## 1. Clone the repository**  
   Clone the project to your local machine by running the folloing command in your terminal: 
   git clone https://github.com/Kartverket-gruppe4/Kartverket.MVC.4.git
## 2. Install Depencencies:????
   ....
## 3. Install Entity Framework Tool:????
   ...
## 4. Create Migrations:????
   ...
## 5. Update Database:
   dotnet ef database update
## 6. Run the project:
   dotnet run 

**VET IKKE OM DETTE ER RETT ELLER OM DET ER FLERE STEG!!!**

# NOE I MELLOM HER???????
- 
- 
- 


# Contributors 
### - Andrea Vågen (LINK TIL GITHUB)
### - Anna Martine Østmoen (LINK TIL GITHUB)
### - Eline Widvey (LINK TIL GITHUB)
### - Olivia Fledsberg Petterøe (LINK TIL GITHUB)
### - Thea Svele Corneliussen (LINK TIL GITHUB)
### - Vilde Christensen (LINK TIL GITHUB)

- **DATO FRA VI BEGYNTE TIL VI SLUTTET** 
- **Bilde av contributors fra github (Se eksempel)!!!!**
- **DOKUMENTASJON AV COMMITS (Se eksemepel)**
- **TRAFFIC (SE EKSEMPEL)**










