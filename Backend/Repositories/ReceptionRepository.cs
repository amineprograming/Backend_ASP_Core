using System;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
	public class ReceptionRepository : GenericRepository<Reception>, IReceptionRepository
	{
		public ReceptionRepository(ApplicationDbContext context) : base(context)
		{
		}

        public override IEnumerable<Reception> GetAll()
        {
            return base._context.Receptions.Include(x => x.details);
        }


    }
}

