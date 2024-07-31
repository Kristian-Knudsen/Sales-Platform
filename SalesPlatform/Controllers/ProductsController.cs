using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;
using SalesPlatform.Requests;

namespace SalesPlatform.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // should be removed when dashboard gets reworked
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProduct inputProduct)
        {
            try
            {
                var store = await _context.Stores.FindAsync(inputProduct.storeId);
                if (store == null)
                {
                    return BadRequest("Invalid store id supplied! Please try again");
                }

                Product product = new()
                {
                    name = inputProduct.name,
                    description = inputProduct.description,
                    price = inputProduct.price,
                    isDraft = inputProduct.isDraft,
                    stock = inputProduct.stock,
                    store = store,
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Ok(product.id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product.id);
        }
    }
}
