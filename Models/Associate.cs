using System;
using System.ComponentModel.DataAnnotations;

namespace AssociateTracker.Models
{
	public class Associate
	{
		[Key]
		public int Id { get; set; }

		[Required]
        [Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Surname")]
		public string LastName { get; set; }

		public Placement? Placement { get; set; }
	}
}

