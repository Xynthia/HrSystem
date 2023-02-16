namespace HRSystem.Dtos.Declaratie
{
    public class UpdateDeclaratieDto
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "naam";
        public DateTime AanvraagDatum { get; set; } = DateTime.Now;
        public string Omschrijving { get; set; } = "omschrijving";
        public string Documenten { get; set; } = "docs";
        public int Bedrag { get; set; } = 0;
        public int Btw { get; set; } = 21;

        public DeclaratieCategorie Categorie { get; set; }
    }
}
