﻿using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<int> AddCustomerAsync(string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<Customer?> GetCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<bool> UpdateAddressAsync(int id, string address);
        Task<bool> DeleteCustomerAsync(int id);
    }
}