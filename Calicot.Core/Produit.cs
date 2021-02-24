using System.ComponentModel.DataAnnotations;

namespace Calicot.Core
{
    public class Produit
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nom { get; set; }

        public string Description { get; set; }

        [Required]
        public double Prix { get; set; }

        public string Photo { get; set; }
    }
}
