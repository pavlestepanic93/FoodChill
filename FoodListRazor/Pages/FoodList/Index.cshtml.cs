using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodListRazor.Pages.FoodList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Food> Foods { get; set; }

        public async Task OnGetAsync()
        {
            Foods = await _context.Food.ToListAsync();
        }
    }
}
