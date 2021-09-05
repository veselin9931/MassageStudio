using Common.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MassageTypesService : IMassageTypesService
    {
        private readonly IRepository<MassageType> repository;

        public MassageTypesService(IRepository<MassageType> repository)
        {
            this.repository = repository;
        }

        public ICollection<MassageType> GetAll()
        => repository.All().ToList();

        public async Task<MassageType> GetById(string id)
        => await repository.GetByIdAsync(id);

        public MassageType GetByName(string name)
        =>  repository.All().FirstOrDefault(m => m.Name == name);
    }
}
