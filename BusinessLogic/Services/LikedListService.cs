using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Model;

namespace BusinessLogic.Services
{
    public class LikedListService : ILikedListService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public LikedListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<LikedList>> GetAll()
        {
            return await _repositoryWrapper.LikedList.FindAll();
        }
        public async Task<LikedList> GetByIds(int userid, int goodid)
        {
            var list = _repositoryWrapper.LikedList
            .FindByCondition(x => x.UserId == userid && x.GoodId == goodid).Result.First();

            return list;
        }

        public async Task<List<LikedList>> GetByUserid(int userid)
        {
            var list = _repositoryWrapper.LikedList
            .FindByCondition(x => x.UserId == userid).Result;

            return list;
        }

        public async Task<List<LikedList>> GetByGoodid(int goodid)
        {
            var list = _repositoryWrapper.LikedList
            .FindByCondition(x => x.GoodId == goodid).Result;

            return list;
        }
        public async Task Create(LikedList model)
        {
            if(model== null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.LikedList.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(LikedList model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            await _repositoryWrapper.LikedList.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int userid, int goodid)
        {
            var user = await _repositoryWrapper.LikedList
            .FindByCondition(x => x.UserId == userid && x.GoodId==goodid);

            await _repositoryWrapper.LikedList.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}
