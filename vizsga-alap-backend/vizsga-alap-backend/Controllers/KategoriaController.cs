using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using vizsga_alap_backend.Models;

namespace vizsga_alap_backend.Controllers
{
    [Route("kategoria")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        VizsgaContext _context;

        public KategoriaController(VizsgaContext context)
        {
            _context = context;
        }

        [EnableCors]
        [HttpGet]

        public async Task<ActionResult<List<Kategorium>>> Get()
        {
            var kategoriak = await _context.Kategoria.ToListAsync();
            if (kategoriak.IsNullOrEmpty())
                return BadRequest("Nincs kategoria");
            return Ok(kategoriak);
        }
    }
}
