using oshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using oshop.Infrastructure.Repositories;

namespace oshop.Infrastructure.Common.Interfaces
{
    public interface IUserReposiroy
    {
        Task<IEnumerable<User>> GetAll();
        Task <ActionResult<User>> CreateUser(User user);
        Task<LoginResponse> LogIn(LoginRequest request);


    }
}
