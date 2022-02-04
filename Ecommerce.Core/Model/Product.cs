using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Model
{
    public class Product : Base
    {
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public IList<Category> Categories { get; set; }

        public Product()
        {
            Categories = new List<Category>();
        }
    }
}
