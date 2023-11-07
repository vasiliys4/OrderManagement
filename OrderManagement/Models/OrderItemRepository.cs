using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;

namespace OrderManagement.Models
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDB _context;
        public OrderItemRepository(ApplicationDB dB) 
        {
            _context = dB;
        }
        public async Task<OrderItem> Add(OrderItem item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(OrderItem item)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> Update(OrderItem item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
