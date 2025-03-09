using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using oshop.Infrastructure.Common.Interfaces;
using oshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace oshop.Infrastructure.Repositories
{
    public class UserRepositery
    {

        public class UserController : ControllerBase, IUserReposiroy
        {
            private readonly AppDbContext _context;

            public UserController(AppDbContext context)
            {
                _context = context;
            }



            public async Task<IEnumerable<User>> GetAll()
            {
                return await _context.Users.ToListAsync();
            }


            public async Task<LoginResponse> LogIn(LoginRequest request)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                if (user == null)
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }

                var token = GenerateJwtToken(user);

                return new LoginResponse
                {
                    User = user,
                    Token = token
                };
            }
           




            [HttpPost("signup")]
            public async Task<ActionResult<User>> CreateUser(User user)
            {

                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    return Conflict(new { message = "Email already in use." });
                }
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();
                var token = GenerateJwtToken(user);


                return CreatedAtAction(nameof(GetAll), new { id = user.Id }, new { user, token });
            }

            private string GenerateJwtToken(User user)
            {
                var claims = new[]
                {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // User ID as the identifier
        new Claim(ClaimTypes.Name, user.Email),  // User Email
        // You can add more claims based on your needs
    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your_32_character_long_secret_key_here"));  // Secret key to sign the token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new JwtSecurityToken(
                    issuer: "YourIssuer",  // Can be your application name or domain
                    audience: "YourAudience",  // Can be your app or audience
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),  // Set the expiration of the token
                    signingCredentials: creds
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(tokenDescriptor);
            }


        }

    }
}
