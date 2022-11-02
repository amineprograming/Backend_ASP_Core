using System;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Reception> Receptions { get; set; }

    }
}

