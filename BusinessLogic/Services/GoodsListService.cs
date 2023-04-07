using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class GoodsListService: IGoodsListService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public GoodsListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<GoodsList>> GetAll()
        {
            return await _repositoryWrapper.GoodsList.FindAll();
        }
        public async Task<GoodsList> GetByIds(int userid,int goodid)
        {
            var list = _repositoryWrapper.GoodsList
            .FindByCondition(x => x.UserId == userid && x.GoodId==goodid).Result.First();

            return list;
        }

        public async Task<List<GoodsList>> GetByUserid(int userid)
        {
            var list = _repositoryWrapper.GoodsList
            .FindByCondition(x => x.UserId == userid).Result;

            return list;
        }

        public async Task<List<GoodsList>> GetByGoodid(int goodid)
        {
            var list = _repositoryWrapper.GoodsList
            .FindByCondition(x => x.GoodId == goodid).Result;

            return list;
        }
        public async Task Create(GoodsList model)
        {
            await _repositoryWrapper.GoodsList.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(GoodsList model)
        {
            await _repositoryWrapper.GoodsList.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int userid, int goodid)
        {
            var list = await _repositoryWrapper.GoodsList
            .FindByCondition(x => x.UserId == userid&&x.GoodId==goodid );

            await _repositoryWrapper.GoodsList.Delete(list.First());
            await _repositoryWrapper.Save();
        }
    }
}
