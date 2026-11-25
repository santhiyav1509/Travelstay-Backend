using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travelstay.Controllers.Applications.DTO;
using Travelstay.Domain.Entity;
using Travelstay.Infrastructure;

namespace Travelstay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourBookingsController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TourBookingsController(AppDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var items = db.TourBookings.OrderByDescending(t => t.Id).ToList();
                return Ok(mapper.Map<List<TourBookingDto>>(items));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = db.TourBookings.FirstOrDefault(t => t.Id == id);
                if (item == null) return NotFound($"Booking {id} not found.");
                return Ok(mapper.Map<TourBookingDto>(item));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpPost]
        public IActionResult Create([FromBody] TourBookingDto dto)
        {
            try
            {
                var item = mapper.Map<TourBooking>(dto);
                item.Id = 0;
                item.CreatedAt = DateTime.UtcNow;
                db.TourBookings.Add(item);
                db.SaveChanges();
                return Ok(mapper.Map<TourBookingDto>(item));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TourBookingDto dto)
        {
            try
            {
                var existing = db.TourBookings.FirstOrDefault(t => t.Id == id);
                if (existing == null) return NotFound($"Booking {id} not found.");

                var createdAt = existing.CreatedAt;
                mapper.Map(dto, existing);
                existing.Id = id;
                existing.CreatedAt = createdAt;
                db.SaveChanges();
                return Ok(mapper.Map<TourBookingDto>(existing));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = db.TourBookings.FirstOrDefault(t => t.Id == id);
                if (item == null) return NotFound($"Booking {id} not found.");
                db.TourBookings.Remove(item);
                db.SaveChanges();
                return Ok($"Booking {id} deleted.");
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }
    }
}
