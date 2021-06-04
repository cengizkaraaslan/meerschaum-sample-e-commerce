using eticaret.Entities;
using eticaret.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eticaret.DataAccess
{
    public class EFAuthRepositoryDal : IAuthRepository
    {
        MeerschaumContext2 _context;
        public EFAuthRepositoryDal(MeerschaumContext2 context)
        {
            _context = context;

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public async Task<Users> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.email == email);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<Users> Register(Users user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public async Task<bool> UserExists(string Email)
        {
            if (await _context.Users.AnyAsync(x => x.email == Email))
            {
                return true;
            }
            return false;
        }

      
    }
}
