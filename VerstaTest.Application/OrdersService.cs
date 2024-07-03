using VerstaTest.Core.Abstractions;
using VerstaTest.Server.Model;

namespace VerstaTest.Application
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public async Task<Guid> CreateOrder(Order order)
        {
            return await _orderRepository.Create(order);
        }
    }
}
