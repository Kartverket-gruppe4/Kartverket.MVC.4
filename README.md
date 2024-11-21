- Dokumentasjon i Github om drift, systm arkitektur og testing scenarier og resultater, i tillegg til dokumentasjonen i selve koden.
  
# Demonstration of the Application: 
Linke her (Den vi brukte i Deliverable 4 eller en ny som viser alle oppdateringen!!!!)

## Folders and file structures (Github Repository Root) 
Sjekk at alt er oppdatert i mappestrukturen!!!!!
Mapstructure for Kartverket.MVC.4

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

# Project Title: Kartverket
*Date: 25.11.24*  

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

## Scalability and Extensibility
?????

## Installation 

### Prerequisites
Before you start, make sure you have the following installed on your local machine:

- GitHub
- ASP.NET Core
- C#
- HTML
- JavaScript
- NuGet Package Manager
- SQL Server Management
- Docker
- Mariadb?
- Rider or Visual Studio?
- ??

## Developable and Expandable Structure
Inkluder link til oppgaven se eksempel vi fikk 

### Steps to install 
1. **Clone the repository**  
   Clone the repo to your local machine.
   ```bash
   https://github.com/Kartverket-gruppe4/Kartverket.MVC.4.git


# Architectural Structure / MVC Architectural Pattern

This code block follows the MVC (Model-View-Controller) architectural pattern. This pattern separates the application into three main components, providing a modular and easily maintainable structure.

## * Model

Includes data models such as the AppDbContext class and Identity-related classes (ApplicationUser, IdentityRole, etc.). Database operations and user authorization processes are handled in this layer.
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

## * View

Includes elements related to the user interface, such as Razor pages in the Views folder and static files (CSS, JavaScript, etc.) in the wwww root folder.
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


## * Controller

Controller classes like AccountController receive HTTP requests, initiate processes, and redirect to the appropriate view to display results.
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

