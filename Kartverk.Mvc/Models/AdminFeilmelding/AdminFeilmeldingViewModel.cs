namespace Kartverk.Mvc.Models.AdminFeilmelding 
{
   // Modell for admin som håndtereer feilmeldinger. 
   public class AdminFeilmeldingViewModel
    {
        // Konstruktør som setter en standardverdi for Status.
        public AdminFeilmeldingViewModel()
        {
            Status = "Ny";
        }
  
        // Unik ID for feilmeldingen.
        public int Id { get; set; }

        // Status for feilmeldingen.
        public string Status { get; set; }
    }
}

 