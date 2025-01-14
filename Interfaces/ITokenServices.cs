using AppAPI.Entities;

namespace AppAPI.Interfaces
{
    public interface ITokenServices
    {
        string CreateToken(AppUser user);
    }
}
