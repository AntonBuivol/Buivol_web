using Buivol_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buivol_web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1,"Koola", 1.5, true),
            new Toode(2,"Fanta", 1.0, false),
            new Toode(3,"Sprite", 1.7, true),
            new Toode(4,"Vichy", 2.0, true),
            new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET :/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }

        // DELETE :/tooted/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }

        // POST :/tooted/lisa
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPost("lisa2")] // POST :/tooted/lisa2?id=1&nimi=Koola&hind=1.5&aktiivne=true
        public List<Toode> Add2([FromQuery] int id, [FromQuery] string nimi, [FromQuery] double hind, [FromQuery] bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPatch("hind-dollaritesse/{kurss}")] // PATCH :/tooted/hind-dollaritesse/1.5
        public List<Toode> Dollaritesse(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }

        // või foreachina:

        [HttpPatch("hind-dollaritesse2/{kurss}")] // PATCH :/tooted/hind-dollaritesse2/1.5
        public List<Toode> Dollaritesse2(double kurss)
        {
            foreach (var t in _tooted)
            {
                t.Price = t.Price * kurss;
            }

            return _tooted;
        }

        //Iseseisvad harjutused

        //delete all
        [HttpGet("kustuta-koik")]
        public List<Toode> DeleteAll()
        {
            _tooted.Clear();
            return _tooted;
        }

        //change active to false
        [HttpGet("muuta-aktiivsus-valeks")]
        public List<Toode> ChangeActiveToFalse()
        {
            foreach (var t in _tooted)
            {
                t.IsActive = false;
            }
            return _tooted;
        }

        //GET high price
        [HttpGet("korgeim-hind")]
        public ActionResult<Toode> GetToodeWithHighPrice()
        {
            var highPrice = _tooted.OrderByDescending(t => t.Price).FirstOrDefault();
            return highPrice;
        }

        // GET https://localhost:4444/tooted/toode-by-number/{index}
        [HttpGet("toode-by-number/{index}")]
        public ActionResult<Toode> GetToodeByNumber(int index)
        {
            if (index < 1 || index > _tooted.Count)
            {
                return NotFound("Toode sellega indeks ei leia.");
            }

            var toode = _tooted[index - 1];
            return toode;
        }
    }
}
