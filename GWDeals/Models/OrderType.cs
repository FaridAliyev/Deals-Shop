using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Models
{
    public class OrderType
    {
        public int Id { get; set; }
        public string OType { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
