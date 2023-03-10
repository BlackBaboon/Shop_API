using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MyDbContext _repoContext;

        private IGoodsRepository _good;

        public IGoodsRepository Good
        {
            get
            {
                if (_good == null)
                    _good = new GoodsRepository(_repoContext);
                return _good;
            }
        }

        public RepositoryWrapper(MyDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
