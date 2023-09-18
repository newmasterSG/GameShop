using Application.InterfaceServices;
using Domain.Interfaces;
using Domain.User;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(IUnitOfWork unitOfWork,
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<UserEntity>> GetAllAdminAsync()
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");

            return adminUsers.ToList();
        }
    }
}
