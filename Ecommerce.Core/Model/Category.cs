using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Model
{
    public class Category : Base
    {
        public int InternalSubCategory { get; set; }
        public string Brief { get; set; }
        public List<Product>? Products { get; set; }
    }
}
