using Domain.User;

namespace Application.InterfaceServices
{
    public interface IAdminService
    {
        Task<List<UserEntity>> GetAllAdminAsync();
    }
}