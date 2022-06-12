using GWDeals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWDeals.ViewModels
{
    public class HomeVM
    {
        public List<Deal> Deals { get; set; }
        public AppUser User { get; set; }
    }
}
