using FranciscoMasisAgenda.DataBase;
using FranciscoMasisAgenda.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranciscoMasisAgenda.Controllers
{
    [ApiController]
    [Route("api/agendas")]
    public class AgendaController : Controller
    {
      private readonly AppDBContext _dbContext;

        public AgendaController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Metodos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetAgenda()
        {

            return await _dbContext.agendas.ToListAsync();
        }
    }
}
