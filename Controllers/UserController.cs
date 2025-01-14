using AppAPI.Data;
using AppAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{

    
    public class UserController(DataContext context) : BaseAPIController
    {


        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> UserById(int id)
        {
            var user = await context.Users.FindAsync(id);
            if(user==null) return NotFound();
            return user ;
        }
    }
}
