namespace HRSystem.Dtos.Vakantie
{
    public class AddVakantieDto
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "Vakantie";
        public DateTime BeginDatum { get; set; } = DateTime.Now;
        public DateTime EindDatum { get; set; } = DateTime.Now;
        public DateTime AanvraagDatum { get; set; } = DateTime.Now;
        public bool GoedKeuring { get; set; } = false;
    }
}
