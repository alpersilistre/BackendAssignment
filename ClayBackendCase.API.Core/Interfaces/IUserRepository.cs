using ClayBackendCase.API.Core.Dto.Repository;
using ClayBackendCase.API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Core.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByIdWithRoleAsync(int id);
        Task<User> GetByIdWithCompanyAsync(int id);
        Task<User> GetByIdWithRelationsAsync(int id);
        Task<User> GetByName(string userName);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> CheckAdminUserExist();
        Task<CreateUserResponse> Create(User user, string password);
        bool CheckPassword(User user, string password);
    }
}
