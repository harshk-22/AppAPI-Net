using AppAPI.Data;
using AppAPI.DTOs;
using AppAPI.Entities;
using AppAPI.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
    [Authorize]

    public class UserController(IUserRepository userRepository) : BaseAPIController
    {


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUser()
        {
            var users = await userRepository.GetAllMembersAsync();
            return Ok(users);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> UserById(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if(user==null) return NotFound();
            return user ;
        }

        [HttpGet("username")]
        public async Task<ActionResult<MemberDto>> UserByUserName(string username)
        {
            var user = await userRepository.GetMemberByNameAsync(username);
            
            if (user == null) return NotFound();
            return user;
        }
    }
}
