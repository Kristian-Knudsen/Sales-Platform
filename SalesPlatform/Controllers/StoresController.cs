using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models; 
using SalesPlatform.Requests;

namespace SalesPlatform.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        // GET: api/Stores/<userid>
        [HttpGet("{userid}")]
        public async Task<ActionResult<Store>> GetStore(Guid userid)
        {
            var user = await _context.Users.FindAsync(userid);

            if (user == null)
            {
                return BadRequest("Invalid user id supplied. Please try again");
            }

            return Ok(user.store);
        }

        [HttpGet("{storeid}/products")]
        public async Task<ActionResult<ICollection<Product>>> GetProductsByStore(Guid storeid)
        {
            var store = await _context.Stores
                .Where(s => s.id == storeid)
                .Select(s => new {
                    Products = s.products.Select(p => new
                    {
                        Id = p.id,
                        /*Name = pd4ab6864-f221-490d-973e-56a8a8da68ef,*/
                        Description = p.description,
                        Price = p.price,
                        IsDraft = p.isDraft,
                        Stock = p.stock,
                        CreatedAt = p.createdAt
                    })
                })
                .FirstOrDefaultAsync();

            if (store == null)
            {
                return BadRequest("Invalid store id supplied. Please try again");
            }

            if (store.Products.Count() == 0)
            {
                return NotFound("This store has no products");
            }

            return Ok(store.Products);
        }
        
        // POST: api/Stores/{storeId}/orders
        [HttpGet("{storeid}/orders")]
        [Authorize]
        public async Task<ActionResult<ICollection<Order>>> GetOrdersByStoreId(Guid storeid)
        {
            ICollection<Order> orders = await _context.Order.Where(o => o.storeId == storeid).ToListAsync();

            return Ok(orders);
        }

        // POST: api/Stores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(CreateStore inputStore)
        {
            try
            {
                var user = await _context.Users.FindAsync(inputStore.userId);
                if (user == null)
                {
                    return BadRequest("Invalid userid supplied! Please try again");
                }

                Store store = new Store
                {
                    name = inputStore.name,
                    employees = new List<User> { user },
                    products = new List<Product>()
                };

                _context.Stores.Add(store);
                await _context.SaveChangesAsync();

                return Ok(store);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool StoreExists(Guid id)
        {
            return _context.Stores.Any(e => e.id == id);
        }
    }
}
