using Application.DTO;
using Domain.User;

namespace Application.InterfaceServices
{
    public interface IOrderServices
    {
        void CreateOrder(UserEntity user, Dictionary<int, int> gameIds, decimal price);
        Task<List<OrderPurchaseDto>> GetOrderPurchases(string userId);
    }
}