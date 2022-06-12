using GWDeals.DAL;
using GWDeals.Models;
using GWDeals.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(AppDbContext ctx, UserManager<AppUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Ordered = TempData["ordered"];
            ViewBag.Subscribed = TempData["subscribed"];
            AppUser user = null;

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            HomeVM model = new HomeVM()
            {
                Deals = await _ctx.Deals.Include(d => d.Item).ToListAsync(),
                User = user
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Order(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deal deal = await _ctx.Deals.Include(d => d.Item).FirstOrDefaultAsync(d => d.Id == id);

            if (deal == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Order order = new Order
            {
                OrderDate = DateTime.UtcNow.AddHours(4),
                AppUserId = user.Id,
                OrderTypeId = 1,
                DeliveryTypeId = 2,
                OrderStatusId = 4
            };

            _ctx.Orders.Add(order);

            OrderItem orderItem = new OrderItem
            {
                Quantity = deal.Amount,
                Total = deal.Amount * deal.DiscountedPrice,
                Order = order,
                ItemId = deal.ItemId
            };

            _ctx.OrderItems.Add(orderItem);
            await _ctx.SaveChangesAsync();
            TempData["ordered"] = true;
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Subscribe()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user.IsSubscriber)
            {
                TempData["subscribed"] = 2;
                return RedirectToAction("Index", "Home");
            }
            user.IsSubscriber = true;
            await _userManager.UpdateAsync(user);
            TempData["subscribed"] = 1;
            return RedirectToAction("Index", "Home");
        }
    }
}
