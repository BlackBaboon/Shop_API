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
            var comment = await _repositoryWrapper.Comment
            .FindByCondition(x => x.UserId == userid && x.GoodId == goodid);

            return comment.First();
        }

        public async Task<List<Comment>> GetByUserid(int userid)
        {
            var comment = await _repositoryWrapper.Comment
            .FindByCondition(x => x.UserId == userid);

            return comment;
        }

        public async Task<List<Comment>> GetByGoodid(int goodid)
        {
            var comment = await _repositoryWrapper.Comment
            .FindByCondition(x => x.GoodId == goodid);

            return comment;
        }
        public async Task Create(Comment model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if(String.IsNullOrEmpty(model.Comment_))
            {
                throw new ArgumentException();
            }
            if (model.Rate < 0 || model.Rate > 5)
            {
                throw new ArgumentException();
            }
            await _repositoryWrapper.Comment.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Comment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (String.IsNullOrEmpty(model.Comment_))
            {
                throw new ArgumentException();
            }
            if (model.Rate < 0 || model.Rate > 5)
            {
                throw new ArgumentException();
            }
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
