using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.Models
{
	public class DetailsReception
	{
        public int Id { get; set; }
        public int Qte { get; set; }
        public double PrixHt { get; set; }
        public double TVA { get; set; }

        [ForeignKey(nameof(Article))]
        public int ArticleId { get; set; }

        public Article? Article { get; set; }
    }
}

