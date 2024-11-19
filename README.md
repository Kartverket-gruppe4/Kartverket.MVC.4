# Project title: Kartverket
*Date:[Insert date]*  

## Table of contents 

## Prosjektbeskrivelse 
**Crowd Sourcing for innmeldinger i kartgrunnlag** 
Hensikten med dette prosjektet er ... 
Hvilke problemer det løser ...
Hvem kan ha nytte av det ...
Gi eksempler ...? 

## Users scenarios
Se eksempel 

## Folders and file structures (Github Repository Root) 
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

