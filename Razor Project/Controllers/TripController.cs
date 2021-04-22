using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nepal_Trip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nepal_Trip.Controllers
{
    [Route("api/Trip")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TripController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Trip.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var tripFromDb = await _db.Trip.FirstOrDefaultAsync(u=>u.ID == id);
            if(tripFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _db.Trip.Remove(tripFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
