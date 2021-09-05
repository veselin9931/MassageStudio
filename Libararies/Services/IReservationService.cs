using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReservationService
    {
        Task<string> Create(string masseurId, string custumerId, string typeId, DateTime time);

        Task<Reservations> GetById(string id);

        ICollection<Reservations> GetAll();

        ICollection<Reservations> GetAllByCustumerId(string id);

        ICollection<Reservations> GetAllByMassaurId(string id);

        Reservations GetByDate(DateTime date);

        Task<bool> Delete(string id);
    }
}
