using Ecommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public Guid BrandId { get; set; }

    }
}
