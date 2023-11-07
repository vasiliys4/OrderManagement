namespace OrderManagement.Models
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> Add(OrderItem item);
        Task<OrderItem> Update(OrderItem item);
        Task Delete(OrderItem item);
        Task<IEnumerable<OrderItem>> GetAllAsync();
    }
}
