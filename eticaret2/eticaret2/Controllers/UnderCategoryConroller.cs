using eticaret.DataAccess;
using eticaret.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Route("api/undercategory")]
    public class UnderCategoryConroller : Controller
    {
        IUnderCategoryDal _categoruDal;
        public UnderCategoryConroller(IUnderCategoryDal categoruDal)
        {
            this._categoruDal = categoruDal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _categoruDal.GetList();
            return Ok(pro);
        }
        [HttpGet("{categoryid}")]
        public IActionResult Get(int categoryid)
        {
            var pro = _categoruDal.GetList(g => g.category_id == categoryid);
            return Ok(pro);
        }

    }
}
