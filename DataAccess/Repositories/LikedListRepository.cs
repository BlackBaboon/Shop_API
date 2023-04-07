using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using DataAccess.Model;
using Domain.Interfaces;

namespace DataAccess.Repositories
{

    public class LikedListRepository : RepositoryBase<LikedList>, ILikedListRepository
    {
        public LikedListRepository(MyDbContext repositorycontext)
        : base(repositorycontext)
        {

        }
    }
}
