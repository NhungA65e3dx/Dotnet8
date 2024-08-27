using Dotnet8.Entity;
using Dotnet8.Model;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly OurHeroDbContext _db;
        public CustomerService(OurHeroDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customer>> GetAllCustomers(bool? isActive)
        {
            if (isActive == null) { return await _db.Customers.ToListAsync(); }

            return await _db.Customers.Where(obj => obj.isActive == isActive).ToListAsync();
        }

        public async Task<Customer?> GetCustomersByID(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(hero => hero.Id == id);
        }

        public async Task<Customer?> AddCustomer(AddUpdateCustomer obj)
        {
            var addCustomer = new Customer()
            {
                Phone = obj.Phone,
                UserName = obj.UserName,
                Email = obj.Email,
                Password = obj.Password,
                Role = obj.Role,
                isActive = obj.isActive,
            };

            _db.Customers.Add(addCustomer);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addCustomer : null;
        }

        public async Task<Customer?> UpdateCustomer(int id, AddUpdateCustomer obj)
        {
            var Customer = await _db.Customers.FirstOrDefaultAsync(index => index.Id == id);
            if (Customer != null)
            {
                Customer.Phone = obj.Phone;
                Customer.UserName = obj.UserName;
                Customer.Email = obj.Email;
                Customer.Password = obj.Password;
                Customer.Role = obj.Role;
                Customer.isActive = obj.isActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? Customer : null;
            }
            return null;
        }

        public async Task<bool> DeleteCustomersByID(int id)
        {
            var Customers = await _db.Customers.FirstOrDefaultAsync(index => index.Id == id);
            if (Customers != null)
            {
                _db.Customers.Remove(Customers);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
