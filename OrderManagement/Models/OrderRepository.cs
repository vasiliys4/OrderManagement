using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;

namespace OrderManagement.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDB _context;
        public OrderRepository(ApplicationDB context) 
        {
            _context = context;
        }
        public async Task<Order> CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (order == null)
            {
                return;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrederAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            return order;
        }
        public async Task<IQueryable> TryGetByOrderItemIdAsync(int userId)
        {
            var order = _context.Orders.Join(_context.Items, // второй набор
             o => o.OrderId, // свойство-селектор объекта из первого набора
             i => i.OrderId, // свойство-селектор объекта из второго набора
             (o, i) => new { Name = i.Name, Number = o.Number, Date = o.Date }); // результат
            return order;
        }
    }
}
