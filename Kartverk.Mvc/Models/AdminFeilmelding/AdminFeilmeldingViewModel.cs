namespace Kartverk.Mvc.Models.AdminFeilmelding 
{
   // Definerer en ViewModel for admin som skal håndtere feilmeldinger. 
   public class AdminFeilmeldingViewModel
    {
        // Konstruktør som setter en standardverdi for Status.
        public AdminFeilmeldingViewModel()
        {
            Status = "Ny"; // Angi en standardstatus ved opprettelse.
        }
       // Unik identifikator for feilmeldingen (primærnøkkel i databasen).
       public int Id { get; set; }
        
       // En tekststreng som representerer statusen på feilmeldingen (Ny, påbegynt, osv).
        public string Status { get; set; }
    }
}

 