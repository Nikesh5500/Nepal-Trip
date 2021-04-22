using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nepal_Trip.Model
{
    public class Trip
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Country Name is Required")]
        public string CountryName { get; set; }
        [Required(ErrorMessage = "Start Date is Required")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "End Date is Required")]
        public string EndDate { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
    }
}
