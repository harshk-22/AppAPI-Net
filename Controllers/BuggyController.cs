using AppAPI.Data;
using AppAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppAPI.Controllers
{
    public class BuggyController(DataContext context):BaseAPIController
    {
        [Authorize]
        [HttpGet ("auth")]
        public ActionResult<string> GetAuth()
        {
            return "text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
           // var thing = context.Users.Find(-1)?? throw new exce;
            return NotFound();
        }
        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {

            var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing happened");
            return thing;



        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was a Bad request");
        }
        [HttpGet("nahi")]
        public ActionResult<AppUser> GetNotFound1()
        {
            var thing = context.Users.Find(-1);
            return thing;
        }
    }
}
