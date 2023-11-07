using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Models
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrederAsync(int id);
        Task<Order> UpdateAsync(Order order);
        Task<Order> CreateAsync(Order order);        
        Task DeleteAsync(int id);
    }
}
