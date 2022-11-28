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
            await _productService.AddProductAsync(1, "tea", "romashka");
            Console.WriteLine("Done");
        }
    }
}