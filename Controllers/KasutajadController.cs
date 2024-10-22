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
            new Kasutajad(2,"Petrovich", "prl2", "Petr", "Petrov"),
            new Kasutajad(3,"Pirat", "prl3", "Jonny", "Depp"),
            new Kasutajad(4,"Markul", "prl4", "Mark", "Ivanov"),
            new Kasutajad(5,"Sportsmen", "prl5", "Mike", "Tyson")
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

        [HttpPost("lisa/{id}/{kasutajanimi}/{salasona}/{eesnimi}/{perekonnanimi}")]
        public List<Kasutajad> Add(int id, string kasutajanimi, string salasona, string eesnimi, string perekonnanimi)
        {
            Kasutajad kasutaja = new Kasutajad(id, kasutajanimi, salasona, eesnimi, perekonnanimi);
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
    }
}
