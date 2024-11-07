using Buivol_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buivol_web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KasutajadController : ControllerBase
    {
        private static List<Kasutajad> _kasutajad = new()
        {
            new Kasutajad(1,"Ivachik", "prl1", "Ivan", "Ivanov"),
            new Kasutajad(2,"Petrovich", "prl2", "Petr", "Petrov")
        };

        [HttpGet]
        public List<Kasutajad> Get()
        {
            return _kasutajad;
        }

        [HttpDelete("kustuta/{index}")]
        public List<Kasutajad> Delete(int index)
        {
            _kasutajad.RemoveAt(index);
            return _kasutajad;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _kasutajad.RemoveAt(index);
            return "Kustutatud!";
        }
        [HttpPost("lisa")]
        public List<Kasutajad> Add([FromBody] Kasutajad kasutaja)
        {
            _kasutajad.Add(kasutaja);
            return _kasutajad;
        }

        [HttpPost("lisa2")]
        public List<Kasutajad> Add2(int id, string kasutajanimi, string salasona, string eesnimi, string perekonnanimi)
        {
            Kasutajad kasutaja = new Kasutajad(id, kasutajanimi, salasona, eesnimi, perekonnanimi);
            _kasutajad.Add(kasutaja);
            return _kasutajad;
        }

        [HttpGet("näita/{id}")] // GET /kasutajad/näita/id
        public ActionResult<Kasutajad> Naita(int id)
        {
            var kasutaja = _kasutajad.Find(t => t.Id == id);
            return kasutaja != null ? kasutaja : NotFound();
        }

        // PUT https://localhost:port/kasutajad/uuenda/{id}
        [HttpPut("uuenda/{id}")]
        public ActionResult<Kasutajad> Update(int id, [FromBody] Kasutajad uuendatudkasutaja)
        {
            var Kasutaja = _kasutajad.Find(t => t.Id == id);
            if (Kasutaja == null)
            {
                return NotFound();
            }

            Kasutaja.Kasutajanimi = uuendatudkasutaja.Kasutajanimi;
            Kasutaja.Parool = uuendatudkasutaja.Parool;
            Kasutaja.Nimi = uuendatudkasutaja.Nimi;
            Kasutaja.Perenimi = uuendatudkasutaja.Perenimi;

            return Kasutaja;
        }
    }
}
