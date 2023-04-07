using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;


namespace Domain.Interfaces
{
    public interface ILikedListService
    {
        Task<List<LikedList>> GetAll();
        Task<LikedList> GetByIds(int userid, int goodid);
        Task<List<LikedList>> GetByUserid(int userid);
        Task<List<LikedList>> GetByGoodid(int goodid);
        Task Create(LikedList model);
        Task Update(LikedList model);
        Task Delete(int userid,int goodid);
    }
}
