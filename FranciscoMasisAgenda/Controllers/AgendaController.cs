using FranciscoMasisAgenda.DataBase;
using FranciscoMasisAgenda.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranciscoMasisAgenda.Controllers
{
    [ApiController]
    [Route("api/agenda")]
    public class AgendaController : Controller
    {
      private readonly AppDBContext _Context;

        public AgendaController(AppDBContext dbContext)
        {
            _Context = dbContext;
        }

        //Metodos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetAgendas()
        {
            return await _Context.Agendas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostAgenda([FromBody] Agenda agenda)
        {
            try
            {
                if (agenda == null)
                {
                    return BadRequest("El objeto contacto no puede ser nulo.");
                }

                _Context.Agendas.Add(agenda);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAgendas), new { id = agenda.IdContacto }, agenda);
            }
            catch (Exception ex)
            {
                // Log del error para depuración
                Console.WriteLine($"Error al guardar el contacto: {ex.Message}");
                return StatusCode(500, "Error interno del servidor al guardar el contacto.");
            }
        }



    }
}
