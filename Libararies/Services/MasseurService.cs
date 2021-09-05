using Common.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MasseurService : IMasseurService
    {
        private readonly IRepository<Мasseur> repository;

        public MasseurService(IRepository<Мasseur> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddReservation(Мasseur masseur, Reservations reservation)
        {

            masseur.Reservations.Add(reservation);

            this.repository.Update(masseur);

            var result = await this.repository.SaveChangesAsync();

            await this.SetMassureLevel(masseur.Id);

            return result > 0;
        }

        public async Task<string> Create(string firstName, string lastName)
        {
            var masure = new Мasseur()
            {
                CreatedOn = DateTime.UtcNow,
                FirstName = firstName,
                LastName = lastName,
                Level = 1
            };

            this.repository.Add(masure);

            var result = await this.repository.SaveChangesAsync();

            if (result>0)
            {
                return masure.Id;
            }

            return "Invalid operation.";


        }

        public async Task<bool> Delete(string id)
        {
            var massure = await this.GetMassurById(id);

            this.repository.Delete(massure);

            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public ICollection<Мasseur> GetAll()
         => repository.All().ToList();

        public async Task<Мasseur> GetMassurById(string id)
         => await this.repository.GetByIdAsync(id);

        public async Task<int> SetMassureLevel(string id)
        {
            var masseur = await this.GetMassurById(id);

            if (masseur.Reservations.Count > 3 && masseur.Reservations.Count <= 6)
            {
                masseur.Level = 2;
            }
            else if (masseur.Reservations.Count > 6 && masseur.Reservations.Count <= 9)
            {
                masseur.Level = 3;
            }
            else if (masseur.Reservations.Count > 6 && masseur.Reservations.Count <= 9)
            {
                masseur.Level = 4;
            }
            else if (masseur.Reservations.Count > 6 && masseur.Reservations.Count <= 9)
            {
                masseur.Level = 5;
            }

            return masseur.Level;
        }
    }
}
