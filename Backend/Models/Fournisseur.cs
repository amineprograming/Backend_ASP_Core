using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("fournisseur")]
	public class Fournisseur
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom is required")]
        public string? Nom { get; set; }
    }
}

