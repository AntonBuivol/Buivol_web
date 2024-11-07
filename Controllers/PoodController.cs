using Buivol_web.Data;
using Buivol_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buivol_web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoodController : ControllerBase
    {
        private readonly DBContext _context;

        public PoodController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Kasutajad> GetKasutaja(int id)
        {
            var kasutaja = _context.Kasutajad.Find(id);
            if (kasutaja == null)
            {
                return NotFound();
            }
            return kasutaja;
        }

        [HttpPost("LisaKasutaja")]
        public List<Kasutajad> LisaKasutaja([FromBody] Kasutajad kasutajad)
        {
            _context.Kasutajad.Add(kasutajad);
            _context.SaveChanges();
            return _context.Kasutajad.ToList();
        }

        [HttpPost("LisaToode")]
        public ActionResult<List<Toode>> LisaToode([FromBody] Toode toode)
        {
            _context.Tooded.Add(toode);
            _context.SaveChanges();

            var kasutaja = _context.Kasutajad.Include(k => k.Kasutajanimi).SingleOrDefault(k => k.Id == toode.Id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            return Ok(kasutaja);
        }

        [HttpPut]
        public ActionResult<List<Kasutajad>> PutKasutaja(int id, [FromBody] Kasutajad updatedkasutaja)
        {
            var kasutaja = _context.Kasutajad.Find(id);
            if (kasutaja == null)
            {
                return NotFound();
            }
            kasutaja.Kasutajanimi = updatedkasutaja.Kasutajanimi;
            kasutaja.Parool = updatedkasutaja.Parool;
            kasutaja.Nimi = updatedkasutaja.Nimi;
            kasutaja.Perenimi = updatedkasutaja.Perenimi;
            _context.Kasutajad.Update(kasutaja);
            _context.SaveChanges();
            
            return Ok(_context);
        }
    }
}
