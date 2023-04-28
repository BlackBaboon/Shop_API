using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {

        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<User> GetById(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.Id == id).Result.First();

            return user;
        }
        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }    
            if(string.IsNullOrEmpty(model.Nickname))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Surname))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Phonenumber))
            {
                throw new ArgumentException();
            }

            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Nickname))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Surname))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(model.Phonenumber))
            {
                throw new ArgumentException();
            }
            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}
