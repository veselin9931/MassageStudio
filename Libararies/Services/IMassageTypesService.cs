using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMassageTypesService
    {
        ICollection<MassageType> GetAll();

        Task<MassageType> GetById(string id);

        MassageType GetByName(string name);
    }
}
