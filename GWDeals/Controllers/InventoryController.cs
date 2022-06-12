using GWDeals.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.Controllers
{
    public class InventoryController : Controller
    {
        private readonly AppDbContext _ctx;
        public InventoryController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View(_ctx.Items);
        }
    }
}
