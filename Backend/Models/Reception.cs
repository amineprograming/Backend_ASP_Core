using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("reception")]
	public class Reception
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime dateReception { get; set; }

        public double HT { get; set; }

        public double TVA { get; set; }

        public double TTC { get; set; }

        public virtual ICollection<DetailsReception> details { get; set; }

        public Reception()
        {
            this.details = new HashSet<DetailsReception>();
        }
    }
}

