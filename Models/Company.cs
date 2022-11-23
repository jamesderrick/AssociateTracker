using System;
using System.ComponentModel.DataAnnotations;

namespace AssociateTracker.Models
{
	public class Company
	{
		[Key]
		public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

		public bool IsActive { get; set; }

	}
}

