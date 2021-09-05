using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Tests.FakeServices
{
    public class MassageTypeServiceFake : IMassageTypesService
    {
        private readonly List<MassageType> massageTypes;

        public MassageTypeServiceFake()
        {
            this.massageTypes = new List<MassageType>()
            { 
                new MassageType {Id= "1", Name = "Relax", Price = 20 },
                new MassageType {Id= "2", Name = "Normal", Price = 30 },
                new MassageType {Id= "3", Name = "Comfort", Price = 40 },
            };
        }

        public ICollection<MassageType> GetAll()
        {
            return massageTypes;
        }

        public async Task<MassageType> GetById(string id)
        {
            return massageTypes.FirstOrDefault(p => p.Id == id);
        }

        public MassageType GetByName(string name)
        {
            return massageTypes.FirstOrDefault(p => p.Name == name);
        }
    }
}
