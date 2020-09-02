using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodListRazor.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Food.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var foodFomDb = await _context.Food.FirstOrDefaultAsync(u => u.Id == id);
            if(foodFomDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _context.Food.Remove(foodFomDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
