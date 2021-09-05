using Common.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservations> repository;
        private readonly IMasseurService masseurService;
        private readonly ICustumerService custumerService;
        private readonly IMassageTypesService massageTypesService;

        public ReservationService(IRepository<Reservations> repository,
            IMasseurService masseurService, 
            ICustumerService custumerService,
            IMassageTypesService massageTypesService)
        {
            this.repository = repository;
            this.masseurService = masseurService;
            this.custumerService = custumerService;
            this.massageTypesService = massageTypesService;
        }

        public async Task<string> Create(string masseurId, string custumerId, string typeId, DateTime time)
        {
            Reservations reservation;
            var masseur = await this.masseurService.GetMassurById(masseurId);
            var custumer = await this.custumerService.GetCustomerById(custumerId);
            var type = await this.massageTypesService.GetById(typeId);

            if (masseur != null && custumer != null && type != null)
            {
                reservation = new Reservations()
                {
                    Customer = custumer,
                    CustomerId = custumer.Id,
                    Мasseur = masseur,
                    MasseurId = masseur.Id,
                    Type = type,
                    TypeId = type.Id,
                    Date = time,
                    CreatedOn = DateTime.UtcNow,
                };

                this.repository.Add(reservation);

                var result = await this.repository.SaveChangesAsync();

                if (result > 0)
                {
                    var isAdeedInM = await this.masseurService.AddReservation(masseur, reservation);
                    var isAdeedInC = await this.custumerService.AddReservation(custumer, reservation);

                    if (isAdeedInC && isAdeedInM)
                    {
                       return reservation.Id;
                    }
                }
            }

            return "Invalid operation";
        }

        public async Task<bool> Delete(string id)
        {
            var reservation = await this.GetById(id);

            this.repository.Delete(reservation);

            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public ICollection<Reservations> GetAll()
         => this.repository.All().ToList();

        public ICollection<Reservations> GetAllByCustumerId(string id)
        => this.repository.All().Where(a => a.CustomerId == id).ToList();

        public ICollection<Reservations> GetAllByMassaurId(string id)
        => this.repository.All().Where(a => a.MasseurId == id).ToList();

        public Reservations GetByDate(DateTime date)
         =>  this.repository.All()
                 .FirstOrDefault(r => r.Date.ToLongDateString() == date.ToLongTimeString());

        public async Task<Reservations> GetById(string id)
         => await this.repository.GetByIdAsync(id);
    }
}
