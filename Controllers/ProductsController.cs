using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public ProductsController(ShopDbContext context)
        {
            _context = context;
        }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string? search,
            [FromQuery] string? category,
            [FromQuery] string? sortBy)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                string lowerSearch = search.ToLower();
                query = query.Where(p => EF.Functions.ILike(p.Name, $"%{lowerSearch}%") ||
                                        EF.Functions.ILike(p.Description, $"%{lowerSearch}%"));
            }


            if (!string.IsNullOrEmpty(category))
            {
                string lowerCategory = category.ToLower();
                query = query.Where(p => EF.Functions.ILike(p.Category, lowerCategory));
            }


            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "name" => query.OrderBy(p => p.Name),
                    "price" => query.OrderBy(p => p.Price),
                    _ => query
                };
            }

            var products = await query.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }
    }
}
