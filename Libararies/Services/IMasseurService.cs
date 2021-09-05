using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMasseurService
    {
        Task<string> Create(string firstName, string lastName);

        Task<Мasseur> GetMassurById(string id);

        ICollection<Мasseur> GetAll();

        Task<bool> Delete(string id);

        Task<int> SetMassureLevel(string id);

        Task<bool> AddReservation(Мasseur masseur, Reservations reservation);
    }
}
