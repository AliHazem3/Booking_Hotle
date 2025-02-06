using BookingHotel_APi.Data;
using BookingHotel_APi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotel_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Rooms.Include(x => x.Booking).OrderBy(x => x.RoomType).ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }




        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Result = _context.Rooms.Include(x => x.Booking).FirstOrDefault(x => x.Id == id);
                return Ok(Result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Room model)
        {
            try
            {
                if (model != null)
                {
                    _context.Rooms.Add(model);
                    _context.SaveChanges();
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Room model)
        {
            try
            {
                var Result = _context.Rooms.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    Result.BookingId = model.BookingId;
                    Result.RoomType = model.RoomType;
                    Result.Price = model.Price;
                    Result.Price = model.Price;
                    Result.Discount = model.Discount;
                    Result.NumberOfAdults = model.NumberOfAdults;
                    Result.NumberOfChildren = model.NumberOfChildren;
                    

                    _context.Rooms.Update(Result);
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


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _context.Rooms.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    _context.Rooms.Remove(Result);
                    _context.SaveChanges();
                    return Ok();
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
