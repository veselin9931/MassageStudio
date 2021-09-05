using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Tests.FakeServices
{
    public class CustumerServiceFake : ICustumerService
    {
        private readonly List<Customer> customers;

        public CustumerServiceFake()
        {
            this.customers = new List<Customer>()
            {
              new Customer
              {
                 Id = "1",
                 FirstName = "Gosho",
                 LastName = "Peshev",
                 Phone = "0885477370",
                 CreatedOn = DateTime.UtcNow,
              },
              new Customer
              {
                 Id ="2",
                 FirstName = "Gosho2",
                 LastName = "Peshev2",
                 Phone = "0885477370",
                 CreatedOn = DateTime.UtcNow,
              }
            };
        }

        public Task<bool> AddReservation(Customer customer, Reservations reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Create(string firstName, string lastName, string phone)
        {
            var custumer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                CreatedOn = DateTime.Now
            };

            if (custumer != null)
            {
               this.customers.Add(custumer);
            }

            var newCustumer = await this.GetCustomerById(custumer.Id);

            return newCustumer.Id;
            
        }

        public async Task<bool> Delete(string id)
        {
            var customer = await this.GetCustomerById(id);

            var result = this.customers.Remove(customer);

            return result;
        }

        public ICollection<Customer> GetAll()
        {
            return this.customers;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return this.customers.FirstOrDefault(customers => customers.Id == id);
        }
    }
}
