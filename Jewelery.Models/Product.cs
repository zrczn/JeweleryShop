using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jewelery.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int MaterialsId { get; set; }
        [ValidateNever]
        [ForeignKey("MaterialsId")]
        public Material Materials { get; set; }

        public int StonesId { get; set; }
        [ValidateNever]
        [ForeignKey("StonesId")]
        public Stone Stones { get; set; }

        public int TypeId { get; set; }
        [ValidateNever]
        [ForeignKey("TypeId")]
        public WearingType Type { get; set; }

        [Required]
        public string Size { get; set; }
        [Required]
        public string ImageURl { get; set; }
    }
}
