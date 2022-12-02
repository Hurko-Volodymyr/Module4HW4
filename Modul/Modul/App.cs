using Modul.Models;
using Modul.Services.Abstractions;

namespace Modul
{
    public class App
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IPaymentService _paymentService;
        private readonly IShipperService _shipperService;
        private readonly ISupplierService _suppliersService;

        public App(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService,
            ICategoryService categoryService,
            IOrderDetailsService orderDetailsService,
            IPaymentService paymentService,
            IShipperService shipperService,
            ISupplierService suppliersService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
            _categoryService = categoryService;
            _orderDetailsService = orderDetailsService;
            _paymentService = paymentService;
            _shipperService = shipperService;
            _suppliersService = suppliersService;
        }

        public async Task Start()
        {
            await _customerService.AddCustomerAsync("Name1", "Surname", "Some-address", "Kharkiv", "ln4n25", "Ukraine", "+380...");
            await _customerService.GetCustomerAsync(1);
            await _customerService.GetCustomerAsync(2);
            await _customerService.UpdateAddressAsync(1, "MyRealAddress");
            await _customerService.GetCustomerAsync(1);

            await _categoryService.AddCategoryAsync("Tea", "Tea", "Tea.jpg", "active");
            await _categoryService.GetCategoryAsync(1);
            await _categoryService.UpdateCategoryAsync(1, "Tea", "Tea", "Tea.jpg", "non-active");
            await _categoryService.DeleteCategoryAsync(1);

            await _paymentService.AddPaymentAsync("card", "some_allowed");
            await _paymentService.UpdatePaymentAsync(1, "card", "some_allowed");
            await _paymentService.GetPaymentAsync(1);
            await _paymentService.DeletePaymentAsync(1);

            await _shipperService.AddShipperAsync("Arasaka", "+56363..");
            await _shipperService.UpdateShipperAsync(1, "Militech", "+56363..");
            await _shipperService.GetShipperAsync(1);
            await _shipperService.DeleteShipperAsync(1);

            // await _productService.AddProductAsync("tea", "romashka", 1, 1);
            // await _productService.AddProductAsync("tea", "gold", 1, 2);
            // await _productService.AddProductAsync("tea", "green", 1, 3);
            var order1 = new Order();

            // await _orderDetailsService
            // await _orderService.AddOrderAsync(1, DateTime.Now, 1, 1, 1);
            // await _orderService.UpdateOrderAsync(order1.OrderID, order1.OrderNumber, order1.OrderDate, order1.CustomerID, order1.PaymentID, 2);
            Console.WriteLine("Done");
        }
    }
}