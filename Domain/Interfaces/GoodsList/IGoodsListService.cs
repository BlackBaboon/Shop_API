using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGoodsListService
    {
        Task<List<GoodsList>> GetAll();
        Task<GoodsList> GetByIds(int userid, int goodid);
        Task<List<GoodsList>> GetByUserid(int userid);
        Task<List<GoodsList>> GetByGoodid(int goodid);
        Task Create(GoodsList model);
        Task Update(GoodsList model);
        Task Delete(int userid,int goodid);
    }
}
