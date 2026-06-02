using HotelListing.Api.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel{Id = 1, Name = "Hotel 1", Address = "AFF", Rating = "2"},
            new Hotel{Id = 2, Name = "Hotel 2", Address = "DIG", Rating = "6"}
        };

        // GET: api/<HotelsController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels);
        }

        // GET api/<HotelsController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        // POST api/<HotelsController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if (hotels.Any(x => x.Id == newHotel.Id)) return BadRequest("Hotel already exists");
            hotels.Add(newHotel);

            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
        }

        // PUT api/<HotelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel exHotel)
        {
            var existingHotel = hotels.FirstOrDefault(x => x.Id == exHotel.Id);
            if (existingHotel == null) return BadRequest("Hotel not found");

            existingHotel.Name = exHotel.Name;
            existingHotel.Address = exHotel.Address;
            existingHotel.Rating = exHotel.Rating;

            return NoContent();
        }

        // DELETE api/<HotelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingHotel = hotels.FirstOrDefault(x => x.Id == id);
            if (existingHotel == null) return BadRequest("Hotel not found");

            hotels.Remove(existingHotel);

            return NoContent();
        }
    }
}
