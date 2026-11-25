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
    public class RoomReservationsController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RoomReservationsController(AppDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var items = db.RoomReservations.OrderByDescending(r => r.Id).ToList();
                return Ok(mapper.Map<List<RoomReservationDto>>(items));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = db.RoomReservations.FirstOrDefault(r => r.Id == id);
                if (item == null) return NotFound($"Reservation {id} not found.");
                return Ok(mapper.Map<RoomReservationDto>(item));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoomReservationDto dto)
        {
            try
            {
                var item = mapper.Map<RoomReservation>(dto);
                item.Id = 0;
                item.CreatedAt = DateTime.UtcNow;
                db.RoomReservations.Add(item);
                db.SaveChanges();
                return Ok(mapper.Map<RoomReservationDto>(item));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RoomReservationDto dto)
        {
            try
            {
                var existing = db.RoomReservations.FirstOrDefault(r => r.Id == id);
                if (existing == null) return NotFound($"Reservation {id} not found.");

                var createdAt = existing.CreatedAt;
                mapper.Map(dto, existing);
                existing.Id = id;
                existing.CreatedAt = createdAt;
                db.SaveChanges();
                return Ok(mapper.Map<RoomReservationDto>(existing));
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = db.RoomReservations.FirstOrDefault(r => r.Id == id);
                if (item == null) return NotFound($"Reservation {id} not found.");
                db.RoomReservations.Remove(item);
                db.SaveChanges();
                return Ok($"Reservation {id} deleted.");
            }
            catch (Exception err) { return StatusCode(500, err.Message); }
        }

    }
}
