using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamenProgreso1.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Carrera")]
        public string nombre_Carrera { get; set; }

        [StringLength(30)]
        public string campus {  get; set; }

        [Required]
        public int numero_semestres { get; set; }


    }
}
