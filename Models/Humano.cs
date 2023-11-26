using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Humano.Models
{
    public class Humanos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength (100, MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required]
        [RegularExpression("(Masculino|Femenino|Otro)", ErrorMessage = "Sexo no válido")]
        public string Sexo { get; set; }

        [Required]
        [Range(1,110)]
        public int Edad { get; set; }

        [Required]
        [Range(0.5, 2.5)]
        public double Altura { get; set; }

        [Required]
        [Range(30,150)]
        public double Peso { get; set; }
    }
}
