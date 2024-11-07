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

        [HttpGet("pood")]
        public List<Pood> GetPood()
        {
            return _context.Pood.ToList();
        }
    }
}
