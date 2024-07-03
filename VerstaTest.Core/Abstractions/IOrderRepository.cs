using VerstaTest.Server.Model;

namespace VerstaTest.Core.Abstractions
{
    public interface IOrderRepository
    {
        Task<Guid> Create(Order order);
        Task<List<Order>> GetOrders();
        Task<Guid> Update(Guid id, string recipientCity, string recipientAddress, string addresserCity, string addresserAddress, float cargoWeight, DateTime receiveDate);
    }
}