using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nepal_Trip.Model;

namespace Nepal_Trip.Pages.TripList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Trip Trip { get; set; }

        
        public async Task OnGet(int ID)
        {
            Trip = await _db.Trip.FindAsync(ID);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var TripFromDb = await _db.Trip.FindAsync(Trip.ID);
                TripFromDb.Name = Trip.Name;
                TripFromDb.CountryName = Trip.CountryName;
                TripFromDb.StartDate = Trip.StartDate;
                TripFromDb.EndDate = Trip.EndDate;
                TripFromDb.Description = Trip.Description;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }
    }
}
