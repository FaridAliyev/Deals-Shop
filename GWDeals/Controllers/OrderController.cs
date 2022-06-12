using GWDeals.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _ctx;
        public OrderController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Total = _ctx.OrderItems.Sum(o => o.Total);
            return View(
                _ctx.Orders.Include(o=>o.AppUser)
                .Include(o => o.OrderType)
                .Include(o => o.OrderStatus)
                .Include(o => o.Delivery)
                .Include(o => o.OrderItems).ThenInclude(oi=>oi.Item)
                );
        }
    }
}
