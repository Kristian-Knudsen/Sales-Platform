using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;
using SalesPlatform.Requests;

namespace SalesPlatform.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }
        
        // POST: api/Orders/{storeId}
        [HttpGet("{storeId}")]
        [Authorize]
        public async Task<ActionResult<ICollection<Order>>> GetOrdersByStoreId(Guid storeId)
        {
            ICollection<Order> orders = await _context.Order.Where(o => o.storeId == storeId).ToListAsync();

            return Ok(orders);
        }
    }
}
