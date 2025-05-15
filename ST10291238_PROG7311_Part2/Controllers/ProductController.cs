using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ST10291238_PROG7311_Part2.Models;
using ST10291238_PROG7311_Part2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ST10291238_PROG7311_Part2.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(AppDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Email == user.Email);
            var products = _context.Products.Where(p => p.FarmerId == farmer.FarmerId);
            return View(await products.ToListAsync());
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.FarmerId == int.Parse(user.Id));

            model.FarmerId = farmer.FarmerId;
            _context.Products.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyProducts");
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Filter(string category, DateTime? from, DateTime? to)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            if (from.HasValue)
                query = query.Where(p => p.ProductionDate >= from.Value);

            if (to.HasValue)
                query = query.Where(p => p.ProductionDate <= to.Value);

            return View("AllProducts", await query.ToListAsync());
        }
    }

}
