using VerstaTest.Server.Model;

namespace VerstaTest.Core.Abstractions
{
    public interface IOrdersService
    {
        Task<Guid> CreateOrder(Order order);
        Task<List<Order>> GetAllOrders();
    }
}