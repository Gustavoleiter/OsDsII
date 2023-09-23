using OsDsII.api.Models;

namespace OsDsII.api.Services.Interaces
{
    public interface ICustomersService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync(Customer customer);

        public Task<Customer> UpdateCustomerAsync(int id, Customer customer);

        public Task DeleteCustomerAsync(int id, Customer customer);
    }
}