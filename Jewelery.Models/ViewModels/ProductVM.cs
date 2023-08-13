using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.Models.VM
{
    public class ProductVM
    {
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SelectMaterials { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SelectStones { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SelectWearingTypes { get; set; }
    }
}
