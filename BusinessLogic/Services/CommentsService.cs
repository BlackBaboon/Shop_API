using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class  CommentService : ICommentService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public  CommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _repositoryWrapper.Comment.FindAll();
        }
        public async Task<Comment> GetByIds(int userid, int goodid)
        {
            var comment = _repositoryWrapper.Comment
            .FindByCondition(x => x.UserId == userid && x.GoodId == goodid).Result.First();

            return comment;
        }

        public async Task<List<Comment>> GetByUserid(int userid)
        {
            var comment = _repositoryWrapper.Comment
            .FindByCondition(x => x.UserId == userid).Result;

            return comment;
        }

        public async Task<List<Comment>> GetByGoodid(int goodid)
        {
            var comment = _repositoryWrapper.Comment
            .FindByCondition(x => x.GoodId == goodid).Result;

            return comment;
        }
        public async Task Create(Comment model)
        {
            await _repositoryWrapper.Comment.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Comment model)
        {
            await _repositoryWrapper.Comment.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int userid,int goodid)
        {
            var comment = await _repositoryWrapper.Comment
            .FindByCondition(x => x.UserId == userid && x.GoodId==goodid);

            await _repositoryWrapper.Comment.Delete(comment.First());
            await _repositoryWrapper.Save();
        }
    }
}
