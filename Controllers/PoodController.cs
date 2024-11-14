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

        [HttpGet("kasutaja")]
        public List<Kasutajad> GetKasutajad()
        {
            return _context.Kasutajad.ToList();
        }

        [HttpGet("kasutaja/{id}")]
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

        [HttpDelete("kustutaKasutaja/{id}")]
        public List<Kasutajad> DeleteKasutaja(int id)
        {
            var kasutaja = _context.Kasutajad.Find(id);
            _context.Kasutajad.Remove(kasutaja);
            return _context.Kasutajad.ToList();
        }

        [HttpGet("toode")]
        public List<Toode> GetTooded()
        {
            return _context.Tooded.ToList();
        }

        [HttpGet("toode/{id}")]
        public ActionResult<Toode> GetToode(int id)
        {
            var toode = _context.Tooded.Find(id);
            if (toode == null)
            {
                return NotFound();
            }
            return toode;
        }

        [HttpPost("LisaToode")]
        public List<Toode> LisaToode([FromBody] Toode toode)
        {
            _context.Tooded.Add(toode);
            _context.SaveChanges();
            return _context.Tooded.ToList();
        }

        [HttpDelete("kustutaToode/{id}")]
        public List<Toode> DeleteToode(int id)
        {
            var toode = _context.Tooded.Find(id);
            _context.Tooded.Remove(toode);
            return _context.Tooded.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult GetPood(int id)
        {
            var kasutajaJaToode = _context.Pood
                .Where(p => p.KasutajaId == id)
                .Select(p => new
                {
                    UserId = p.Kasutajad.Id,
                    Kasutajanimi = p.Kasutajad.Kasutajanimi,
                    Nimi = p.Kasutajad.Nimi,
                    Perenimi = p.Kasutajad.Perenimi,
                    Tooded = p.Kasutajad.Poods.Select(po => new
                    {
                        ToodeId = po.Toode.Id,
                        Name = po.Toode.Name,
                        Price = po.Toode.Price,
                        IsActive = po.Toode.IsActive
                    })
                })
                .FirstOrDefault();

            if (kasutajaJaToode == null)
            {
                return NotFound();
            }

            return Ok(kasutajaJaToode);
        }

        [HttpPost("Lisa/{userId}")]
        public ActionResult LisaPood(int userId,[FromBody] int productId)
        {
            var kasutaja = _context.Kasutajad.Find(userId);
            var toode = _context.Tooded.Find(productId);

            if (kasutaja == null || toode == null)
            {
                return NotFound();
            }

            var pood = new Pood
            {
                KasutajaId = userId,
                ToodeId = productId,
                Kasutajad = kasutaja,
                Toode = toode
            };

            _context.Pood.Add(pood);
            _context.SaveChanges();

            return Ok("Toode lisa");
        }

        [HttpDelete("kustuta/{productId}")]
        public async Task<IActionResult> DeleteToodeFromKasutaja(int productId)
        {
            var toode = await _context.Tooded
                .FirstOrDefaultAsync(t => t.Id == productId);
            _context.Tooded.Remove(toode);
            await _context.SaveChangesAsync();

            return Ok("Toode kustuta");
        }
    }
}
