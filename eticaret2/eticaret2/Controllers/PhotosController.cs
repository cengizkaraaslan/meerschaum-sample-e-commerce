using eticaret.DataAccess;
using eticaret.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Route("api/photos")]
    public class PhotosController : Controller
    {

        IPhotosDal _photoDal;
        public PhotosController(IPhotosDal _photoDal)
        {
            this._photoDal = _photoDal;
        }



        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _photoDal.GetList();
            return Ok(pro);
        }
        [HttpGet("{ProductId}")]
        public IActionResult Get(int ProductId)
        {
            try
            {
                var pro = _photoDal.GetList(f => f.Product_ID == ProductId).ToList();
                if (pro == null)
                {
                    return NotFound($"There is no with id  = {ProductId}");
                }
                return Ok(pro);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        public IActionResult Post(Photo photo)
        {
            _photoDal.Add(photo);
            return new StatusCodeResult(201);
        }
        [HttpPut]
        public IActionResult Put(Photo photo)
        {
            try
            {
                _photoDal.Update(photo);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {


            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(Photo photo)
        {
            try
            {
                _photoDal.Delete(new Photo { Photo_ID = photo.Product_ID });
                return Ok();
            }
            catch (Exception)
            {


            }
            return BadRequest();
        }

    }
}
