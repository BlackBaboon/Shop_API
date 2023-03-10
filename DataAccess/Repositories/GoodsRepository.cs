using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using Domain.Model;

using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GoodsRepository: RepositoryBase<Good>, IGoodsRepository
    {
        public GoodsRepository(MyDbContext repositorycontext) 
            : base(repositorycontext)
        { 
        }
    }
}
