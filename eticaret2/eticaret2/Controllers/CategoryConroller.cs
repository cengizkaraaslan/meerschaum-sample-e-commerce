using eticaret.DataAccess;
using eticaret.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Route("api/category")]
    public class CategoryConroller : Controller
    {

        ICategoryDal _categoruDal;
        public CategoryConroller(ICategoryDal categoruDal)
        {
            this._categoruDal = categoruDal;
        }



        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _categoruDal.GetList();
            return Ok(pro);
        }
        //[HttpGet("")]
        //public IActionResult Get()
        //{
        //    var pro = _categoruDal.allcategory();
        //    return Ok(pro);
        //}
        [HttpGet("{mothercategory_id}")]
        public IActionResult Get(int mothercategory_id)
        {
            var pro = _categoruDal.allcategory().Where(g => g.mothercategory_id == mothercategory_id);
            return Ok(pro);
        }

    }
}
