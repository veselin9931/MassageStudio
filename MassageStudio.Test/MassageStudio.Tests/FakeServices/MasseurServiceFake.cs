using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Tests.FakeServices
{
    public class MasseurServiceFake : IMasseurService
    {
        private readonly List<Мasseur> masseures;

        public MasseurServiceFake()
        {
            this.masseures = new List<Мasseur>()
            {
              new Мasseur()
              {
                  Id = "1",
                  FirstName = "Marin",
                  LastName = "Marinov",
                  Level = 1,
                  CreatedOn = DateTime.UtcNow
              }
            };
        }

        public Task<bool> AddReservation(Мasseur masseur, Reservations reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Create(string firstName, string lastName)
        {
            var messeur = new Мasseur() { FirstName = firstName, LastName = lastName, Level = 1, CreatedOn = DateTime.UtcNow };

            this.masseures.Add(messeur);

            return messeur.Id;
        }

        public async Task<bool> Delete(string id)
        {
            var messeur = await this.GetMassurById(id);

            var r = this.masseures.Remove(messeur);

            return r;
        }

        public ICollection<Мasseur> GetAll()
        {
            return masseures;
        }

        public async Task<Мasseur> GetMassurById(string id)
        {
            return this.masseures.FirstOrDefault(m => m.Id == id);
        }

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
