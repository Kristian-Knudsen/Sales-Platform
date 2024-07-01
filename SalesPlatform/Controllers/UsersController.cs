using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesPlatform.Infrastructure;
using SalesPlatform.Models;
using SalesPlatform.Requests;
using SalesPlatform.Utils;

namespace SalesPlatform.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpUser(SignInUpUser newUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == newUser.email);
            if (user != null)
            {
                // Email is already used
                return BadRequest("Email is already in use");
            }

            // Create user
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.password);

            var toInsertUser = new User { email = newUser.email, password = hashedPassword, store = null };
            _context.Users.Add(toInsertUser);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInUser(SignInUpUser userDetails)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == userDetails.email);
            if (user == null) { return BadRequest("Email or password incorrect - please try again"); };

            if (BCrypt.Net.BCrypt.Verify(userDetails.password, user.password))
            {
                return Ok(new { 
                    user.id, 
                    user.storeId, 
                    jwt = new Jwt().GenerateJWTToken(new JwtUser { id = user.id, email = user.email }) 
                });
            }

            return BadRequest("Email or password incorrect - please try again");
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
