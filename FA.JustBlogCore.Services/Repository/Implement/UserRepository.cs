using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using FA.JustBlogCore.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Implement
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppSettings _appSettings;

        public UserRepository(DbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
        }

        public bool IsUserExists(string username)
        {
            username = username.Trim().ToLower();
            return this.Find(n => n.Username.ToLower() == username).Count() != 0;
        }

        public override void Add(User entity)
        {
            entity.Password = entity.Password.EncodePassword();
            base.Add(entity);
        }

        public override void Update(User entity)
        {
            entity.Password = entity.Password.EncodePassword();
            base.Add(entity);
        }

        public bool IsCorrectCredential(string username, string password)
        {
            var user = this.Find(username);

            if (user != null && password.EncodePassword() == user.Password)
            {
                return true;
            }

            return false;
        }

        public User Find(string username)
        {
            username = username.Trim().ToLower();
            return this.Find(n => n.Username.ToLower() == username).SingleOrDefault();
        }

        public User Authenticate(string username, string password)
        {
            var user = this.Find(username);

            if (user != null && password.EncodePassword() == user.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = Encoding.ASCII.GetBytes(this._appSettings.Secrets);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Roles.ToString())
                    }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }

            return null;
        }
    }
}