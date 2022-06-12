using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int OrderTypeId { get; set; }
        public OrderType OrderType { get; set; }
        public int DeliveryTypeId { get; set; }
        public DeliveryType Delivery { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
