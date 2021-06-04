using eticaret.DataAccess;
using eticaret.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Produces("application/json")]
    [Route("api/salesed")]
    public class SalesedConroller : Controller
    {

        ISalesedDal _salesedDal;
        public SalesedConroller(ISalesedDal salesedDal)
        {
            this._salesedDal = salesedDal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _salesedDal.GetList();
            return Ok(pro);
        }
        [HttpGet("{userid}")]
        public IActionResult Get(int userid)
        {
            var pro = _salesedDal.orders(userid);
            return Ok(pro);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult add([FromBody]Salesed2 salesed)
        {
            try
            {
                _salesedDal.Salesed(salesed);

                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpDelete("{salesp_id}")]
        public IActionResult delete(int salesp_id)
        {
            try
            {
                //_salesedDal.deleteproduct(salesp_id);
                return Ok();
            }
            catch (Exception)
            {


            }
            return NotFound();
            //return BadRequest();
        }
    }
}
