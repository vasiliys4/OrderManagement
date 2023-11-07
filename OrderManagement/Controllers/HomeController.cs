using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using System.Diagnostics;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public HomeController(ILogger<HomeController> logger, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var item = await _orderRepository.CreateAsync(order);
            if (item == null)
            {

            }
            return Redirect("CreateOrder");
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateOrderItem(int id)
        //{
        //    var existingOrderItem = from p in await _orderRepository.GetOrdersAsync() join c in _orderItemRepository.GetAllAsync() on p.OrderId equals c.OrderId select new { Number = p.Number ,  Date = p.Date, Name = c.Name, Quantity = c.Quantity, Unit = c.Unit};
        //    return View(existingOrderItem);
        //}
    }
}