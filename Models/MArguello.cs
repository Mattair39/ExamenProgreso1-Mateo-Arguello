using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ExamenProgreso1.Models
{
    public class MArguello
    {
        [Key]
        public int Id { get; set; }

        public DateTime fechaNacimiento { get; set; }

        [AllowNull]

        public decimal peso { get; set; }

        [Required]
        public Boolean esEcuatoriano { get; set; }

        [ForeignKey("CarreraId")]

        [AllowNull]
        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }
       


    }
}
