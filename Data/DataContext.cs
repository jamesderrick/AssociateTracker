using System;
using System.ComponentModel;
using AssociateTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AssociateTracker.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Associate> Associates { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
    
}

