using System.ComponentModel.DataAnnotations;

namespace Kartverk.Mvc.ModelValidators
{


    // Definerer en tilpasset valideringsattributt som sjekker om et tall er et primtall.
    public class PrimenumberValidator : ValidationAttribute
    {
        // Overstyrer IsValid-metoden som utfører validering.
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Prøver å konvertere verdien til et heltall. 
            var inputNumber = (int?)value;
            
            // Hvis verdien er null, så valideringen er vellykket. 
            if (inputNumber == null)
                return ValidationResult.Success;
           
            // Sjekker om tallet er et primtall. 
            if (IsPrime(inputNumber.Value))
                return ValidationResult.Success; // Returnerer suksess hvis det er et primtall. 

            // Hvis ikke et primtall, returneres en feilmelding. 
            return new ValidationResult(GetErrorMessage(inputNumber.Value));
        }
        
        // Metode som sjekker om et tall er et primtall. 
        private static bool IsPrime(int number)
        {
            // Hvis tallet er mindre enn eller lik 1, er det ikke et primtall
            if (number <= 1) return false;

            // 2 er et primtall
            if (number == 2) return true;

            // Alle andre partall er ikke primtall
            if (number % 2 == 0) return false;

            // // Beregner grensen for divisjonsjekk, kun opp til kvadratroten av tallet.
            var boundary = (int)Math.Floor(Math.Sqrt(number));

            // Itererer gjennom oddetall fra 3 til grensen for å sjekke om tallet kan deles med noen av dem.
            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false; // Tallet er ikke et primtall hvis det kan deles med i.

            // Hvi ingen faktorer ble funnet, er tallet et primtall. 
            return true;
        }
        
        // Metode for å lage feilmeldingen hvis tallet ikke er et primtall.
        private static string GetErrorMessage(int number) => $"{number} er ikke et primtall"; // Returnerer feilmeldingen som sier at tallet ikke er et primtall. 
    }
}
