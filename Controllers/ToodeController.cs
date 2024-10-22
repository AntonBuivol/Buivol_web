using Buivol_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buivol_web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }

        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = _toode.Price + 1;
            return _toode;
        }

        //Iseseisvad harjutused

        // GET: toode/true->false-false->true
        [HttpGet("muuta-active")]
        public Toode TrueFalse()
        {
            if (_toode.IsActive)
            {
                _toode.IsActive = false;
            }
            else
            {
                _toode.IsActive = true;
            }
            return _toode;
        }

        // GET: toode/muuta-nimi
        [HttpGet("muuta-nimi")]
        public Toode MuutaNimi(string Name)
        {
            _toode.Name = Name;
            return _toode;
        }

        // GET: toode/muuta-hinda
        [HttpGet("muuta-hinda")]
        public Toode MuutaHinda()
        {
            _toode.Price *= _toode.Price;
            return _toode;
        }
    }
}