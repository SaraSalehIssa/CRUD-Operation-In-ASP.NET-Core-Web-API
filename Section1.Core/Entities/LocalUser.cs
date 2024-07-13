using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.Entities
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }

        // Using HashSet to get unique data only without repetition
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
