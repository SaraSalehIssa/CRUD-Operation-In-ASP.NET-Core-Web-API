using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Using HashSet to get unique data only without repetition
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
