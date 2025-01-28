using AppAPI.DTOs;
using AppAPI.Entities;

namespace AppAPI.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetAllUsersAsync();

        Task<AppUser?> GetByIdAsync(int id);

        Task<AppUser?> GetByNameAsync(string username);

        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
       
        Task<MemberDto?> GetMemberByNameAsync(string username);
    }
}
