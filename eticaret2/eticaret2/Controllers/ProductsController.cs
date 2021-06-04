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
    [Route("api/products")]
    public class ProductsController : Controller
    {

        IProductDal _productDal;
        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }



        [HttpGet("")]
        public IActionResult Get()
        {
            var pro = _productDal.GetList();

            return Ok(pro);
        }
        [HttpGet("{ProductId}")]
        public IActionResult Get(int ProductId)
        {
            try
            {
                var pro = _productDal.getProductWithDetail(ProductId);
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
        [HttpGet("{minprice}/{maxprice}/{undercategoryid}/{orderby}/{page}")]
        public IActionResult Get(int minprice, int maxprice, int undercategoryid, int orderby, int page)
        {
            try
            {
                int pagesize = 18;
                var pro = _productDal.GetList(f => ((f.Price <= maxprice && f.Price >= minprice) || (maxprice == 0 && minprice == 0)) && ((f.undercategory_id == undercategoryid) || (undercategoryid == 0))).Skip((page - 1) * pagesize).Take(pagesize);
                switch (orderby)
                {
                    case 2:
                        pro = pro.OrderBy(g => g.Title).ToList();
                        break;
                    default:
                        pro = pro.OrderBy(g => g.Price).ToList();
                        break;
                }

                return Ok(pro);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        public IActionResult Post(Products product)
        {
            _productDal.Add(product);
            return new StatusCodeResult(201);
        }
        [HttpPut]
        public IActionResult Put(Products product)
        {
            try
            {
                _productDal.Update(product);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {


            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(Products product)
        {
            try
            {
                _productDal.Delete(new Products { Product_ID = product.Product_ID });
                return Ok();
            }
            catch (Exception)
            {


            }
            return BadRequest();
        }


        [HttpGet("LatestProduct")]
        public IActionResult LatestProduct()
        {
            try
            {
                List<Products> ekle = new List<Products>();

                var pro = _productDal.GetList().OrderByDescending(g => g.Product_ID).Take(5);
                foreach (var item in pro)
                {
                    Products ekl = new Products();
                    ekl.Category_ID = item.Category_ID;
                    ekl.Image = item.Image;
                    ekl.Info = item.Info;
                    ekl.Link = item.Link;
                    ekl.Price = item.Price;
                    ekl.Product_ID = item.Product_ID;
                    ekl.raiting = item.raiting;
                    ekl.Satus_ID = item.Satus_ID;
                    ekl.Title = item.Title;

                    if (ekl.Title.Length > 19)
                    {
                        ekl.Title = item.Title.Substring(0, 19);

                    }

                    ekle.Add(ekl);
                }
                return Ok(ekle);
            }
            catch (Exception b)
            {

                return BadRequest();
            }

        }
        [HttpGet("Topseller")]
        public IActionResult Topseller()
        {
            try
            {
                List<Products> ekle = new List<Products>();

                var pro = _productDal.GetList().OrderByDescending(g => g.Product_ID).Take(5);
                foreach (var item in pro)
                {
                    Products ekl = new Products();
                    ekl.Category_ID = item.Category_ID;
                    ekl.Image = item.Image;
                    ekl.Info = item.Info;
                    ekl.Link = item.Link;
                    ekl.Price = item.Price;
                    ekl.Product_ID = item.Product_ID;
                    ekl.Satus_ID = item.Satus_ID;
                    ekl.Title = item.Title;

                    if (ekl.Title.Length > 19)
                    {
                        ekl.Title = item.Title.Substring(0, 19);

                    }

                    ekle.Add(ekl);
                }
                return Ok(ekle);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("RecentlyViewed")]
        public IActionResult RecentlyViewed()
        {
            try
            {
                List<Products> ekle = new List<Products>();

                var pro = _productDal.GetList().OrderByDescending(g => g.Product_ID).Take(5);
                foreach (var item in pro)
                {
                    Products ekl = new Products();
                    ekl.Category_ID = item.Category_ID;
                    ekl.Image = item.Image;
                    ekl.Info = item.Info;
                    ekl.Link = item.Link;
                    ekl.Price = item.Price;
                    ekl.Product_ID = item.Product_ID;
                    ekl.Satus_ID = item.Satus_ID;
                    ekl.Title = item.Title;

                    if (ekl.Title.Length > 19)
                    {
                        ekl.Title = item.Title.Substring(0, 19);

                    }

                    ekle.Add(ekl);
                }
                return Ok(ekle);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("TopNew")]
        public IActionResult TopNew()
        {
            try
            {
                List<Products> ekle = new List<Products>();

                var pro = _productDal.GetList().OrderByDescending(g => g.Product_ID).Skip(5).Take(5);
                foreach (var item in pro)
                {
                    Products ekl = new Products();
                    ekl.Category_ID = item.Category_ID;
                    ekl.Image = item.Image;
                    ekl.Info = item.Info;
                    ekl.Link = item.Link;
                    ekl.Price = item.Price;
                    ekl.Product_ID = item.Product_ID;
                    ekl.Satus_ID = item.Satus_ID;
                    ekl.Title = item.Title;

                    if (ekl.Title.Length > 19)
                    {
                        ekl.Title = item.Title.Substring(0, 19);

                    }

                    ekle.Add(ekl);
                }
                return Ok(ekle);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("count/{undercategory_id}")]
        public IActionResult count(int undercategory_id)
        {
            var pro = _productDal.GetList(g => g.undercategory_id == undercategory_id).Count();
            decimal pagecount = (Convert.ToDecimal(pro) / Convert.ToDecimal(18));
            var a = Math.Ceiling(pagecount);
            return Ok(a);
        }

    }
}
