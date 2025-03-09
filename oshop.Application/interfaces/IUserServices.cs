using oshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oshop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using oshop.Infrastructure.Repositories;


namespace oshop.Application.common.interfaces
{
     public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<ActionResult<User>> AddUser(User user);
        Task <LoginResponse> LogInUser(LoginRequest user);
    }
}
