using KubWander.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KubWander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceCRUDController : ControllerBase
    {
        private double MinLatitude = 43.40;
        private double MinLongitude = 37.20;
        private double MaxLatitude = 46.60;
        private double MaxLongitude = 41.30;

        private readonly ApplicationDbContext _context;
        public PlaceCRUDController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PlaceCRUDController>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Place>>> GetAllPlaces()
        {
            return await _context.Places.ToListAsync();
        }

        // GET api/<PlaceCRUDController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "";
        }

        // POST api/<PlaceCRUDController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //Создание места
        }
        [HttpGet("near")]
        public async Task<ActionResult<IEnumerable<Place>>> GetNearPlace(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
            {
                return BadRequest("Неверные координаты");
            }

            const double range = 0.015;
            return await _context.Places
                .Where(p => Math.Abs((double)(p.Latitude - latitude)) <= range && Math.Abs((double)p.Longitude - longitude) <= range)
                .ToListAsync();
        }
        // PUT api/<PlaceCRUDController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlaceCRUDController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
