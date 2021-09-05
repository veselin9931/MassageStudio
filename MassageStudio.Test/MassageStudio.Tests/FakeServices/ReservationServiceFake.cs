using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Tests.FakeServices
{
    public class ReservationServiceFake : IReservationService
    {
        private readonly List<Reservations> reservations;

        private readonly IMassageTypesService massageTypesService;

        private readonly IMasseurService masseurService;

        private readonly ICustumerService custumerService;

        public ReservationServiceFake()
        {
            this.custumerService = new CustumerServiceFake();
            this.masseurService = new MasseurServiceFake();
            this.massageTypesService = new MassageTypeServiceFake();

            this.reservations = new List<Reservations>()
            {
              new Reservations()
              {
                 Id = "1",
                 CustomerId = "1",
                 Customer = new Customer() { Id = "1", FirstName = "Gosho", LastName ="Peshev", Phone = "0885477370"},
                 TypeId = "1",
                 Type = new MassageType() {Id = "1", Name = "Relax", Price = 20M},
                 MasseurId = "1",
                 Мasseur = new Мasseur() {Id = "1", FirstName = "Tosho", LastName = "Tonev", Level = 1},
                 Date = DateTime.UtcNow.AddHours(1)
              },
              new Reservations()
              {
                 Id = "2",
                 CustomerId = "2",
                 Customer = new Customer() { Id = "2", FirstName = "Radko", LastName ="Radev", Phone = "0885477370"},
                 TypeId = "2",
                 Type = new MassageType() {Id = "2", Name = "Comfort", Price = 20M},
                 MasseurId = "2",
                 Мasseur = new Мasseur() {Id = "2", FirstName = "Pesho", LastName = "Goshev", Level = 2},
                 Date = DateTime.UtcNow.AddHours(2)
              }
            };
        }

        public async Task<string> Create(string masseurId, string custumerId, string typeId, DateTime time)
        {
            var reservation = new Reservations()
            {
                CustomerId = custumerId,
                Customer = await this.custumerService.GetCustomerById(custumerId),

                MasseurId = masseurId,
                Мasseur = await this.masseurService.GetMassurById(masseurId),

                TypeId = typeId,
                Type = await this.massageTypesService.GetById(typeId),
            };

            reservations.Add(reservation);

            return reservation.Id;
        }

        public async Task<bool> Delete(string id)
        {
            var reservation = await this.GetById(id);

            return this.reservations.Remove(reservation);
        }

        public ICollection<Reservations> GetAll()
        {
            return reservations;
        }

        public ICollection<Reservations> GetAllByCustumerId(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reservations> GetAllByMassaurId(string id)
        {
            throw new NotImplementedException();
        }

        public Reservations GetByDate(DateTime date)
        {
            return this.reservations
                 .FirstOrDefault(r => r.Date.ToLongDateString() == date.ToLongTimeString());
        }

        public async Task<Reservations> GetById(string id)
        {
            return this.reservations
                  .FirstOrDefault(a => a.Id == id);
        }
    }
}
