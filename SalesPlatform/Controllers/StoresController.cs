﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{storeid}/products")]
        public async Task<ActionResult<ICollection<Product>>> GetProductsByStore(Guid storeid)
        {
            var store = await _context.Stores
                .Where(s => s.id == storeid)
                .Select(s => new
                {
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

        // GET: api/Stores/{storeId}/orders
        [HttpGet("{storeid}/orders")]
        [Authorize]
        public async Task<ActionResult<ICollection<GetOrders>>> GetOrdersByStoreId(Guid storeid)
        {
            ICollection<GetOrders> orders = await _context.Order
                .Where(o => o.storeId == storeid)
                .Select(o => new GetOrders(){
                    id = o.id,
                    createdAt = o.createdAt,
                    fullName = $"{o.customer.firstName} {o.customer.lastName}",
                    status = o.status,
                    email = o.customer.email,
                    totalPrice = o.orderItems.Sum(item => item.quantity * item.product.price),
                })
                .ToListAsync<GetOrders>();

            return Ok(orders);
        }
        
        // GET: api/Stores/{storeid}/order/{orderid}
        [HttpGet("{storeid}/order/{orderid}")]
        [Authorize]
        public async Task<ActionResult<Order>> GetSpecificOrderByStoreId(Guid storeid, Guid orderid)
        {
            try
            {
                GetOrder? order = await _context.Order
                    .Where(o => o.storeId == storeid)
                    .Where(o => o.id == orderid)
                    .Select(o => new GetOrder()
                    {
                        id = o.id,
                        customerEmail = o.customer.email,
                        customerFullName = $"{o.customer.firstName} {o.customer.lastName}",
                        customerPhoneNumber = "+4512345678",
                        shippingDetails = o.customer.shippingDetails.GetSimpleShippingDetails(),
                        createdAt = o.createdAt,
                        totalPrice = o.orderItems.Sum(item => item.quantity * item.product.price),
                        items = o.orderItems.Select(oi => new ItemDetails()
                        {
                            name = oi.product.name, quantity = oi.quantity, price = oi.product.price
                        }),
                        tax = o.orderItems.Sum(item => item.quantity * item.product.price) * 0.15m,
                        paymentInformation = "**** **** **** 0123",
                        shippingFee = 5,
                    })
                    .FirstOrDefaultAsync();

                return Ok(order);
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Orderid: {orderid} or storeid: {storeid} is invalid");
            }
        }
        
        // GET: api/Stores/{storeid}/order/{orderid}
        /*[HttpGet("{storeid}/order/{orderid}/packing")]
        public async Task<ActionResult<OrderPacking>> GetOrderPackingDetails(Guid storeid, Guid orderid)
        {
            
        }*/
    }
}
