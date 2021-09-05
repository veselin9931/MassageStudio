using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustumerService
    {
        Task<string> Create(string firstName, string lastName, string phone);

        Task<Customer> GetCustomerById(string id);

        ICollection<Customer> GetAll();

        Task<bool> Delete(string id);

        Task<bool> AddReservation(Customer customer, Reservations reservation);
    }
}
