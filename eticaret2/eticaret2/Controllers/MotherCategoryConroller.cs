using eticaret.DataAccess;
using eticaret.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Route("api/mothercategory")]
    public class MotherCategoryConroller : Controller
    {

        IMotherCategoryDal _categoruDal;
        public MotherCategoryConroller(IMotherCategoryDal categoruDal)
        {
            this._categoruDal = categoruDal;
        }



        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _categoruDal.GetList();
            return Ok(pro);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pro = _categoruDal.GetList(g=> g.mothercategory_id==id);
            return Ok(pro);
        }

    }
}
