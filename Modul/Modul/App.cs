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
        private readonly ISupplierService _supplierService;

        public App(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService,
            ICategoryService categoryService,
            IOrderDetailsService orderDetailsService,
            IPaymentService paymentService,
            IShipperService shipperService,
            ISupplierService supplierService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
            _categoryService = categoryService;
            _orderDetailsService = orderDetailsService;
            _paymentService = paymentService;
            _shipperService = shipperService;
            _supplierService = supplierService;
        }

        public async Task Start()
        {
            var customer = await _customerService.AddCustomerAsync("Name1", "Surname", "Some-address", "Kharkiv", "ln4n25", "Ukraine", "+380...");
            await _customerService.GetCustomerAsync(customer);
            await _customerService.UpdateAddressAsync(customer, "MyRealAddress");
            await _customerService.GetCustomerAsync(customer);

            var category = await _categoryService.AddCategoryAsync("Tea", "Tea", "Tea.jpg", true);
            await _categoryService.GetCategoryAsync(category);
            await _categoryService.UpdateCategoryAsync(category, "Tea", "Tea", "Tea.jpg", false);

            var payment = await _paymentService.AddPaymentAsync("card", "some_allowed");
            await _paymentService.UpdatePaymentAsync(payment, "GooglePay", "some_allowed");
            await _paymentService.GetPaymentAsync(payment);

            var shipper = await _shipperService.AddShipperAsync("Arasaka", "+56363..");
            await _shipperService.UpdateShipperAsync(shipper, "Militech", "+56363..");
            await _shipperService.GetShipperAsync(shipper);

            var supplier = await _supplierService.AddSupplierAsync("Militech", "Allo", "Ollo", "Mili", "some-adress", "Night-City", customer);
            await _supplierService.UpdateSupplierAsync(supplier, "Arasaka", "Allo", "Ollo", "Mili", "some-adress", "Night-City", customer);
            await _supplierService.GetSupplierAsync(supplier);

            var order = await _orderService.AddOrderAsync(1, DateTime.Now, customer, payment, shipper);
            await _orderService.UpdateOrderAsync(order, 1, DateTime.UtcNow, customer, payment, shipper);
            await _orderService.GetOrderAsync(order);

            // await _orderService.GetOrderByCustomerIdAsync(customer);
            // var product = await _productService.AddProductAsync("tea", "romashka", category, supplier);

            // await _productService.AddProductAsync("tea", "gold", 1, 2);
            // await _productService.AddProductAsync("tea", "green", 1, 3);

            // await _orderDetailsService
            // var orderDetail = await _orderDetailsService.
            Console.WriteLine("Done");
        }
    }
}