using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetTechApi.Data;
using VetTechApi.Models;

namespace VetTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
            private readonly AppDbContext _context;

            public ConsultasController(AppDbContext context)
            {
                _context = context;
            }
        [HttpGet]
            public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultas()
            {
                return await _context.Consultas.ToListAsync();
            }

            [HttpPost]
            public async Task<ActionResult> CriarConsulta(Consulta consulta)
            {
                _context.Consultas.Add(consulta);
                await _context.SaveChangesAsync();
                return Ok("Consultas salvo com sucesso!!!");
            }
    }
}