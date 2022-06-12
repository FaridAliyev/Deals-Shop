using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public ICollection<Deal> Deals { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
