using FA.JustBlogCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool IsUserExists(string username);

        bool IsCorrectCredential(string username, string password);

        User Find(string username);

        User Authenticate(string username, string password);
    }
}