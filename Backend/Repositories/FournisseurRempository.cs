using System;
using Backend.Data;
using Backend.Models;

namespace Backend.Repositories
{
	public class FournisseurRepository : GenericRepository<Fournisseur>, IFournisseurRepository 
	{
        public FournisseurRepository(ApplicationDbContext context): base(context)
        {

        }
     
	}
}

