using DataAccess.Model;
using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GoodsListRepository: RepositoryBase<GoodsList>, IGoodsListRepository
    {
        public GoodsListRepository(MyDbContext repositorycontext)
        : base(repositorycontext)
        {

        }
    }
}
