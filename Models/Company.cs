using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssociateTracker.Models
{
	public class Company
	{
		[Key]
		public int Id { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
    }
}

