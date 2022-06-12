using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Models
{
    public class DeliveryType
    {
        public int Id { get; set; }
        public string DType { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
