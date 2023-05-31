using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using vizsga_alap_backend.Models;

namespace vizsga_alap_backend.Controllers
{
    [Route("teszt")]
    [ApiController]
    public class TesztController : ControllerBase
    {
        VizsgaContext _context;

        public TesztController(VizsgaContext context)
        {
            _context = context;
        }

        [EnableCors]
        [HttpGet]

        public async Task<ActionResult<List<Teszt>>> Get()
        {
            var tesztek = await _context.Teszts.Include(x => x.Kategoria).ToListAsync();
            if (tesztek.IsNullOrEmpty())
                return BadRequest("Nincs teszt");
            return Ok(tesztek);
        }
    }
}
