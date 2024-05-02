using System.ComponentModel.DataAnnotations;

namespace ExamenProgreso1.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string nombre_Carrera { get; set; }

        public string campus {  get; set; }

        [Required]
        public int numero_semestres { get; set; }


    }
}
