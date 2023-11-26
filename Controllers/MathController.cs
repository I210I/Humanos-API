
using Api.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
namespace Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        // POST Operacion/matematica
        [HttpPost("matematica")]
        public IActionResult PostOperacionMatematica([FromBody] OperacionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return  RealizarOperacion(request.A, request.B, request.Operacion);
            
        }

        // GET Operacion/matematica
        [HttpGet("matematica")]
        public IActionResult GetOperacionMatematica([FromHeader] int a, [FromHeader] int b, [FromHeader] string operacion)
        {
            if (!new Regex(@"[\+\-\*/]").IsMatch(operacion))
            {
                return BadRequest("La operación debe ser +, -, * o /.");
            }

            return RealizarOperacion(a, b, operacion);
            
        }

        private IActionResult RealizarOperacion(int a, int b, string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return Ok(a + b);
                case "-":
                    return Ok(a - b);
                case "*":
                    return Ok(a * b);
                case "/":
                    
                    if (b == 0)
                        return BadRequest("No se puede dividir por cero.");

                    return Ok((double)a / b);
                default:
                    return BadRequest("Operacion Invalida");
            }
        }
    }
}
