// Models/Bruger.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudieJobsFinderMyDatabase.Models
{
    [Table("Bruger")]
    public partial class Bruger
    {
        [Key]
        [Column("BrugerID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrugerId { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Brugernavn { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Adgangskode { get; set; }
    }
}