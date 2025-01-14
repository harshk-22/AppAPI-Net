using System.ComponentModel.DataAnnotations;

namespace AppAPI.DTOs
{
    public class UserDto
    {
         public required string Username { get; set; }

         public required string token { get; set; }
    }
}
