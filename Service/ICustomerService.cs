using Dotnet8.Model;

namespace Dotnet8.Service
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers(bool? isActive);
        Task<Customer?> GetCustomersByID(int id);
        Task<Customer?> AddCustomer(AddUpdateCustomer obj);
        Task<Customer?> UpdateCustomer(int id, AddUpdateCustomer obj);
        Task<bool> DeleteCustomersByID(int id);
    }
}
