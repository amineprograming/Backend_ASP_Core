using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("article")]
	public class Article
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string? Designation { get; set; }

        [ForeignKey(nameof(Fournisseur))]
        public int FournisseurId { get; set; }

        public Fournisseur? Fournisseur { get; set; }

    }
}

