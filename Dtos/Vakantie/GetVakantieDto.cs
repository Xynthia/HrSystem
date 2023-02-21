namespace HRSystem.Dtos.Vakantie
{
    public class GetVakantieDto
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "Vakantie";
        public DateTime BeginDatum { get; set; } = DateTime.Now;
        public DateTime EindDatum { get; set; } = DateTime.Now;
        public DateTime AanvraagDatum { get; set; } = DateTime.Now;
        public bool Keuring { get; set; } = false;
        public int UserId { get; set; }
    }
}
