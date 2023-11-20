using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shop
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string ContantEmail { get; set; }
        public string ContactPhone { get; set; }

        public ICollection<ProductSuppliers> ProductSuppliers { get; set; }
    }
}
