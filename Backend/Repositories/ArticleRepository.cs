using System;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
	public class ArticleRepository : GenericRepository<Article>, IArticleRepository
	{
		public ArticleRepository(ApplicationDbContext context) : base(context)
		{

		}
        public override IEnumerable<Article> GetAll()
        {
            return base._context.Articles.Include(x => x.Fournisseur);
        }
    }
}

