using BusinessLogic.Interfaces;
using DataAccess.Wrapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using Domain.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class GoodService : IGoodService
    {

        private IRepositoryWrapper _repositoryWrapper;
        public GoodService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Good>> GetAll()
        {
            return _repositoryWrapper.Good.FindAll().ToListAsync();
        }
        public Task<Good> GetById(int id)
        {
            var good = (_repositoryWrapper.Good
            .FindByCondition(x => x.Id == id)).First();

            return Task.FromResult(good);
        }
        public Task Create(Good model)
        {
            _repositoryWrapper.Good.Create(model);
            _repositoryWrapper.Save();

            return Task.CompletedTask;
        }
        public Task Update(Good model)
        {
            _repositoryWrapper.Good.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var good = _repositoryWrapper.Good
            .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.Good.Delete(good);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

    }
}
