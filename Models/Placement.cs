using System;
using System.ComponentModel.DataAnnotations;
using AssociateTracker.Models;

namespace AssociateTracker.Models
{
	public class Placement
	{
		[Key]
		public int Id { get; set; }

		public Company Company { get; set; }

		public Associate Associate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}

