using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("PlacementId")]
        public Placement? Placement { get; set; }
	}
}

