using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using Domain.Model;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic.Interfaces
{
    public interface IGoodService
    {
        Task<List<Good>> GetAll();
        Task<Good> GetById(int id);
        Task Create(Good model);
        Task Update(Good model);
        Task Delete(int id);
    }
}
