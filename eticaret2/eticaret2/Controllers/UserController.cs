using eticaret.DataAccess;
using eticaret.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        IUsersDal _usersdal;
        public UserController(IUsersDal usersdal)
        {
            this._usersdal = usersdal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _usersdal.GetList();
            return Ok(pro);
        }
        [HttpGet("{userid}")]
        public IActionResult Get(int userid)
        {
            var pro = _usersdal.GetList(g => g.user_id == userid).SingleOrDefault();
            return Ok(pro);
        }
        //[HttpGet("{email}/{password}")]
        //public IActionResult Get(string email, string password)
        //{
        //    //var pro = _usersdal.GetList(g => g.email == email && g.password == password).SingleOrDefault();
        //    //if (true)
        //    //{

        //    //}
        //    return Ok();
        //}
        //[HttpPost]
        //[Route("createaccount")]
        //public IActionResult createaccount([FromBody]Users user)
        //{
        //    try
        //    {
        //        user.datetime = DateTime.Now;
        //        _usersdal.Add(user);
        //        return new StatusCodeResult(201);
        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest();
        //    }
        //}


    }
}
