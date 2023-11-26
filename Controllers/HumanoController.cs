using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Humano.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Humano.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanoController : ControllerBase
    {

        private readonly _DbContext _context;

        public HumanoController(_DbContext context)
        {
            _context = context;
        }
        // Lista estática para simular almacenamiento de datos
        private static readonly List<Humanos> Humanos = new List<Humanos>
        {
            new Humanos { Id = 1, Nombre = "Juan", Sexo = "Masculino", Edad = 30, Altura = 1.75, Peso = 70 },
            new Humanos { Id = 2, Nombre = "Ana", Sexo = "Femenino", Edad = 25, Altura = 1.60, Peso = 55 },
            new Humanos { Id = 3, Nombre = "Carlos", Sexo = "Masculino", Edad = 40, Altura = 1.80, Peso = 80 },
            new Humanos { Id = 4, Nombre = "Luisa", Sexo = "Femenino", Edad = 28, Altura = 1.68, Peso = 60 },
            new Humanos { Id = 5, Nombre = "Miguel", Sexo = "Masculino", Edad = 35, Altura = 1.75, Peso = 75 },
            new Humanos { Id = 6, Nombre = "Sofía", Sexo = "Femenino", Edad = 22, Altura = 1.65, Peso = 58 },
            new Humanos { Id = 7, Nombre = "David", Sexo = "Masculino", Edad = 45, Altura = 1.78, Peso = 85 },
            new Humanos { Id = 8, Nombre = "María", Sexo = "Femenino", Edad = 33, Altura = 1.70, Peso = 65 },


        };
        // GET: /Humano/Mock
        [HttpGet("mock")]
        public IActionResult GetMock()
        {
            return Ok(Humanos);
        }

        [HttpGet]
        public async Task<IActionResult> GetFromDatabase()
        {
            var humanos = await _context.Humanos.ToListAsync();
            return Ok(humanos);
        }

        // POST: /Humano
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Humanos humano)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _context.Humanos.Add(humano);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = humano.Id }, humano);
        }

        // GET: /Humano/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var humano = await _context.Humanos.FindAsync(id);
            if (humano == null)
                return NotFound();

            return Ok(humano);
        }

        // PUT /Humano/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Humanos humano)
        {
            if (id != humano.Id)
            {
                return BadRequest();
            }

            _context.Entry(humano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Humanos.Any(h => h.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



    }
}
