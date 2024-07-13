using Microsoft.AspNetCore.Mvc;
using SalesPlatform.Infrastructure;
using SalesPlatform.Modules.Facebook;

namespace SalesPlatform.Controllers
{
    [Route("api/customerinteraction")]
    [ApiController]
    public class CustomerInteractionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerInteractionController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<OkObjectResult> getConversations()
        {
            FacebookModule module = new();

            return Ok(await module.getPageConversations());
        }
        
        [HttpGet("conversationId")]
        public async Task<OkObjectResult> getConversationMessagesById()
    }
}
