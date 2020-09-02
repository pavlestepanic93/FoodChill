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
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task OnGetAsync(int id)
        {
            Food = await _context.Food.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if(ModelState.IsValid)
            {
                var FoodFromDb = await _context.Food.FirstOrDefaultAsync(f => f.Id == id);

                FoodFromDb.Name = Food.Name;
                FoodFromDb.Chef = Food.Chef;
                FoodFromDb.Country = Food.Country;

                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }

    }
}
