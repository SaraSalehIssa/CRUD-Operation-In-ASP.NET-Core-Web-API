using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey(nameof(LocalUser))]
        public int LocalUserId { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }


        // Using HashSet to get unique data only without repetition
        public ICollection<OrderDetails> OrderDetails { get; set; } = new HashSet<OrderDetails>();
        public LocalUser? LocalUser { get; set; }
    }
}
