using Buivol_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buivol_web.Controllers
{
    [Route("api/[controller]")]
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

        // GET https://localhost:4444/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }

        // DELETE https://localhost:4444/tooted/kustuta/0
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

        // POST https://localhost:4444/tooted/lisa/1/Coca/1.5/true
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPost("lisa2")]
        public List<Toode> Add2(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        // PATCH https://localhost:4444/tooted/hind-dollaritesse/1.5
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public List<Toode> UpdatePrices(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
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
