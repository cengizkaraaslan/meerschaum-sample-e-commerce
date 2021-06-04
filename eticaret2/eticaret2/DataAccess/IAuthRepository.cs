using eticaret.Entities;
using eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticaret.DataAccess;

namespace eticaret.DataAccess
{
    public interface IAuthRepository 
    {
        Task<Users> Register(Users user, string password);
        Task<Users> Login(string email, string password);
        Task<bool> UserExists(string Email);
    }
}
