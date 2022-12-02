using Modul.Models;
using Modul.Services.Abstractions;

namespace Modul
{
    public class App
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public App(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
        }

        public async Task Start()
        {
            await _productService.AddProductAsync("tea", "romashka");
            await _productService.AddProductAsync("tea", "gold");
            await _productService.AddProductAsync("tea", "green");

            await _customerService.AddCustomerAsync("Name1", "Surname", "Some-address", "Kharkiv", "ln4n25", "Ukraine", "+380...");
            await _customerService.GetCustomerAsync(1);
            await _customerService.GetCustomerAsync(2);
            await _customerService.UpdateAddressAsync(1, "MyRealAddress");
            await _customerService.GetCustomerAsync(1);

            var order1 = new Order();

            await _orderService.AddOrderAsync(1, DateTime.Now, 1, 1, 1);
            await _orderService.UpdateOrderAsync(order1.OrderID, order1.OrderNumber, order1.OrderDate, order1.CustomerID, order1.PaymentID, 2);

            Console.WriteLine("Done");
        }
    }
}