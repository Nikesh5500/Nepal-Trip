using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nepal_Trip.Model;

namespace Nepal_Trip.Pages.TripList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Trip> Trips { get; set; }
        public async Task OnGet()
        {
            Trips = await _db.Trip.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int ID)
        {
            var trip = await _db.Trip.FindAsync(ID);
            if(trip == null)
            {
                return NotFound();
            }
            _db.Trip.Remove(trip);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
