using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShipService
    {
        Task<List<Ship>> GetAll();
        Task<List<Ship>> GetById(int shipid);
        Task Create(Ship model);
        Task Update(Ship model);
        Task Delete(int shipid);
        
    }
}
