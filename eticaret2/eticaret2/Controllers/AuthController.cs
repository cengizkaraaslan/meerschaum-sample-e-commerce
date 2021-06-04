using eticaret.DataAccess;
using eticaret.Entities;
using eticaret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;
        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        //[HttpPost]
        //[Route("register")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegister UserRegister)
        {
            if (await _authRepository.UserExists(UserRegister.email))
            {
                ModelState.AddModelError("UserName", "Username already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new Users
            {
                email = UserRegister.email,
                adress1 = UserRegister.adress1,
                adress2 = UserRegister.adress2,
                city = UserRegister.city,
                company = UserRegister.company,
                country = UserRegister.country,
                datetime = DateTime.Now,
                fax = UserRegister.fax,
                name = UserRegister.name,
                postcode = UserRegister.postcode,
                regionstate = UserRegister.regionstate,
                surname = UserRegister.surname,
                telephone = UserRegister.telephone
            };

            var createdUser = await _authRepository.Register(userToCreate, UserRegister.password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserForLogin UserForLogin)
        {
            var user = await _authRepository.Login(UserForLogin.email, UserForLogin.password);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
                    new Claim(ClaimTypes.Name, user.email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }
    }
}
