namespace HRSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string GebruikersNaam { get; set; } = "gebruikersnaam";
        public string VoorNaam { get; set; } = "voornaam";
        public string AchterNaam { get; set; } = "achternaam";
        public string Wachtwoord { get; set; } = "test";
        public string Email { get; set; } = "email";

        public Team Team { get; set; } 
        public Rol Rol { get; set; }
        public Vakantie Vakantie { get; set; }
        public Declaratie Declaratie { get; set; }
    }
}
