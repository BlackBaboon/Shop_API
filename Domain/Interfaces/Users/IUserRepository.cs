﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public Task<User?> GetByEmailAndPassword(string email, string password);
    }
}
