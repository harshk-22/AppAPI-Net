using AppAPI.Data;
using AppAPI.DTOs;
using AppAPI.Entities;
using AppAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AppAPI.Controllers
{
    
    public class AccountController(DataContext context,ITokenServices tokenServices) : BaseAPIController
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            return Ok();
            //using var hmac = new HMACSHA512();

            //if (await UserExist(registerDto.Username))
            //{
            //    return BadRequest("User already exist");
            //}
            //var user = new AppUser
            //{
            //    UserName = registerDto.Username.ToLower(),
            //    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            //    PasswordSalt=hmac.Key
            //};
            //context.Users.Add(user);
            //await context.SaveChangesAsync();
            //return new UserDto
            //{
            // Username =user.UserName,
            // token=tokenServices.CreateToken(user)
            //};
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user=await context.Users.FirstOrDefaultAsync(
              x=>x.UserName== loginDto.Username.ToLower()
                );

            if (user == null) { return Unauthorized("Invalid Username"); }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return new UserDto
            {
                Username = user.UserName,
                token = tokenServices.CreateToken(user)
            };
        }


        private async Task<bool> UserExist(string username)
        {
            return await context.Users.AnyAsync(x=>x.UserName.ToLower()== username.ToLower());
        }
    }

   
}
