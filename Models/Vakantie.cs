using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    public class Vakantie
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; } = "Vakantie";
        public DateTime BeginDatum { get; set; } = DateTime.Now;
        public DateTime EindDatum { get; set; } = DateTime.Now;
        public DateTime AanvraagDatum { get; set; } = DateTime.Now;
        public bool Keuring { get; set; } = false;

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
