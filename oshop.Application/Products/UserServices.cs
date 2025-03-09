using Microsoft.AspNetCore.Mvc;
using oshop.Application.common.interfaces;
using oshop.Infrastructure.Common.Interfaces;
using oshop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oshop.Application.Products
{
    public class UserServices : IUserServices
    {
        private readonly IUserReposiroy _userReposiroy;

        public UserServices(IUserReposiroy userReposiroy)
        {
            _userReposiroy = userReposiroy;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _userReposiroy.GetAll();
        }

        public async Task<ActionResult<User>> AddUser(User user)
        {
            return await _userReposiroy.CreateUser(user);
        }

        public async Task<LoginResponse> LogInUser(LoginRequest user)
        {
            return (LoginResponse)await _userReposiroy.LogIn(user);
        }
    }
}
