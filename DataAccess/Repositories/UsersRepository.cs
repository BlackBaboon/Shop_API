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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyDbContext repositorycontext)
            : base(repositorycontext)
        {
        }
        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            var result = await base.FindByCondition(x=>x.Email == email && x.Password == password);
            if(result == null || result.Count == 0)
            {
                return null;
            }

            return result[0];
        }
    }
}
