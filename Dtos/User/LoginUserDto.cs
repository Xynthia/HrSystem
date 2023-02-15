namespace HRSystem.Dtos.User
{
    public class LoginUserDto
    {
        public int Id { get; set; }
        public string GebruikersNaam { get; set; } = "gebruikersnaam";
        public string Wachtwoord { get; set; } = "test";
        public string Email { get; set; } = "email";


    }
}
