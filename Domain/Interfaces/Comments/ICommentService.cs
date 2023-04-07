using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAll();
        Task<Comment> GetByIds(int userid,int goodid);
        Task<List<Comment>> GetByUserid(int goodid);
        Task<List<Comment>> GetByGoodid(int userid);
        Task Create(Comment model);
        Task Update(Comment model);
        Task Delete(int userid,int goodid);
    }
}
