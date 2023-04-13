﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<List<Good>> GetAll()
        {
            return await _repositoryWrapper.Good.FindAll();
        }
        public async Task<Good> GetById(int id)
        {
            var good = _repositoryWrapper.Good
            .FindByCondition(x => x.Id == id).Result.First();

            return good;
        }
        public async Task Create(Good model)
        {
            await _repositoryWrapper.Good.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Good model)
        {
            await _repositoryWrapper.Good.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var good = await _repositoryWrapper.Good
            .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Good.Delete(good.First());
            await _repositoryWrapper.Save();
        }
    }
}