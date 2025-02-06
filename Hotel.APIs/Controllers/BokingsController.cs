using BookingHotel_APi.Data;
using BookingHotel_APi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingHotel_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BokingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BokingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var Resutl = _context.Bookings.OrderBy(x => x.CustomerName).ToList();
                return Ok(Resutl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_context.Bookings.FirstOrDefault(x => x.Id == id));

            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody] Booking model)
        {
            try
            {
                _context.Bookings.Add(model);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Booking model)
        {
            try
            {
                var Result = _context.Bookings.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    Result.CustomerName = model.CustomerName;
                    Result.NationalId = model.NationalId;
                    Result.PhoneNumber = model.PhoneNumber;
                    Result.HotelBranch = model.HotelBranch;
                    Result.CheckInDate = model.CheckInDate;
                    Result.CheckOutDate = model.CheckOutDate;
                    Result.NumberOFRooms = model.NumberOFRooms;
                    Result.HasBookedBefore = model.HasBookedBefore;
                    _context.Update(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _context.Bookings.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    _context.Bookings.Remove(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}