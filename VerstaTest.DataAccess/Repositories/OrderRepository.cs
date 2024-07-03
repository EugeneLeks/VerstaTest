using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerstaTest.Core.Abstractions;
using VerstaTest.DataAccess.Entities;
using VerstaTest.Server.Model;

namespace VerstaTest.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VerstaTestDbContext _context;
        public OrderRepository(VerstaTestDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrders()
        {
            var orderEntities = await _context.Orders.
                ToListAsync();

            var orders = orderEntities
                .Select(o => Order.Create(o.Id, o.RecipientCity, o.RecipientAddress, o.AddresserCity, o.AddresserAddress, o.CargoWeight, o.ReceiveDate))
                .ToList();
            return orders;
        }
        public async Task<Guid> Create(Order order)
        {
            var orderEntity = new OrderEntity
            {
                Id = order.Id,
                RecipientAddress = order.RecipientAddress,
                RecipientCity = order.RecipientCity,
                AddresserAddress = order.AddresserAddress,
                AddresserCity = order.AddresserCity,
                CargoWeight = order.CargoWeight,
                ReceiveDate = order.ReceiveDate,
            };
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
            return orderEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string recipientCity, string recipientAddress, string addresserCity, string addresserAddress, float cargoWeight, DateTime receiveDate)
        {
            await _context.Orders
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(o => o.RecipientCity, o => recipientCity)
                    .SetProperty(o => o.RecipientAddress, o => recipientAddress)
                    .SetProperty(o => o.AddresserCity, o => addresserCity)
                    .SetProperty(o => o.AddresserAddress, o => addresserAddress)
                    .SetProperty(o => o.CargoWeight, o => cargoWeight)
                    .SetProperty(o => o.ReceiveDate, o => receiveDate));
            return id;
        }
    }
}
