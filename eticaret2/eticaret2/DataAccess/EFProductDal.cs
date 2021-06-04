using eticaret.DataAccess;
using eticaret.Entities;
using eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.DataAccess
{
    public class EFProductDal : EFEntityRepositoryBase<Products, MeerschaumContext>, IProductDal
    {
        public ProductModel getProductWithDetail(int product_id)
        {
            using (MeerschaumContext ds = new MeerschaumContext())
            {
                return (from f in ds.Products
                        join c in ds.Category on f.Category_ID equals c.Category_ID
                        where f.Product_ID == product_id
                        select new Models.ProductModel
                        {
                            Category_ID = f.Category_ID,
                            Category_Name = c.Category_Name,
                            Product_ID = f.Product_ID,
                            Image = f.Image,
                            Info = f.Info,
                            Link = f.Link,
                            Raiting = f.raiting,
                            Price = f.Price,
                            Satus_ID = f.Satus_ID,
                            Title = f.Title
                        }).SingleOrDefault();
            }

        }


    }
}
