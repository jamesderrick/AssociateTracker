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

		public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

