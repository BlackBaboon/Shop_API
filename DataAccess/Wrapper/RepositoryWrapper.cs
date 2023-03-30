using Domain.Interfaces;
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

        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UsersRepository(_repoContext);
                return _user;
            }
        }

        private IGoodsListRepository _goodslist;

        public IGoodsListRepository GoodsList
        {
            get
            {
                if (_goodslist == null)
                    _goodslist = new GoodsListRepository(_repoContext);
                return _goodslist;
            }
        }

        private ICommentRepository _comment;

        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null)
                    _comment = new CommentRepository(_repoContext);
                return _comment;
            }
        }

        public RepositoryWrapper(MyDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
