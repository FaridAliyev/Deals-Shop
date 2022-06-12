using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public int NormalPrice { get; set; }
        public int DiscountedPrice { get; set; }
        public int Amount { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
