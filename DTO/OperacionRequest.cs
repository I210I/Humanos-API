using System.ComponentModel.DataAnnotations;

namespace Api.DTO
{
    public class OperacionRequest
    {
        public int A { get; set; }
        public int B { get; set; }

        [Required]
        [RegularExpression(@"[\+\-\*/]", ErrorMessage = "La operación debe ser +, -, * o /.")]
        public string Operacion { get; set; }
    }
}
