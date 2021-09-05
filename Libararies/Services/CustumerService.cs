using Common.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustumerService : ICustumerService
    {
        private readonly IRepository<Customer> repository;

        public CustumerService(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddReservation(Customer custumer, Reservations reservation)
        {
            custumer.Reservations.Add(reservation);

            this.repository.Update(custumer);

            var result = await this.repository.SaveChangesAsync();

            return result > 0;

        }

        public async Task<string> Create(string firstName, string lastName, string phone)
        {
            var custumer = new Customer() { FirstName = firstName, LastName = lastName, Phone = phone };

            this.repository.Add(custumer);

            var result = await this.repository.SaveChangesAsync();

            if (result > 0)
            {
                return custumer.Id;
            }

            return "Invalid operation";
        }

        public async Task<bool> Delete(string id)
        {
            var custumer = await this.GetCustomerById(id);

            this.repository.Delete(custumer);

            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public ICollection<Customer> GetAll()
         => repository.All().ToList();


        public async Task<Customer> GetCustomerById(string id)
         => await repository.GetByIdAsync(id);
    }
}
