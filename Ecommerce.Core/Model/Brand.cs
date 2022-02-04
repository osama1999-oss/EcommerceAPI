using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Model
{
    public class Brand : Base
    {
        public int FranchiseAssets { get; set; }
        public string AboutUs { get; set; }
        public string Portfolio { get; set; }
        public List<Product>? Products { get; set; }
    }
}
