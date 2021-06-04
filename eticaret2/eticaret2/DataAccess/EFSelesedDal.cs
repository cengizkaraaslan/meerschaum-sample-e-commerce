using eticaret.Entities;
using eticaret.Models;
using System.Collections.Generic;
using System.Linq;

namespace eticaret.DataAccess
{
    public class EFSelesedDal : EFEntityRepositoryBase<Salesed, MeerschaumContext>, ISalesedDal
    {
        public void deleteproduct(int salesp_id)
        {
            using (MeerschaumContext ds = new MeerschaumContext())
            {
                var aa = (from f in ds.Sales_Product where f.salesp_id == salesp_id select f).SingleOrDefault();
                ds.Sales_Product.Remove(aa);
                ds.SaveChanges();
            }
        }
 

        public List<SalesedOrderModel> orders(int Userid)
        {
            using (MeerschaumContext ds = new MeerschaumContext())
            {
                var a = (from f in ds.Salesed
                         join s in ds.Sales_Product on f.sales_id equals s.salesed_id
                         join pro in ds.Products on s.product_id equals pro.Product_ID
                         where f.user_id == Userid
                         select new SalesedOrderModel { image = pro.Image, product_id =  pro.Product_ID, sales_id = f.sales_id, orderbydate = f.orderbydate, title = pro.Title, traking_no = f.traking_no, price= pro.Price, salesp_id=s.salesp_id }
                         ).ToList();
                return a;
            }
        }
        public void Salesed(Salesed2 salesed)
        {
            using (MeerschaumContext ds = new MeerschaumContext())
            {
                var sales = new Entities.Salesed();
                sales.adress1 = salesed.adress1;
                sales.adress2 = salesed.adress2;
                sales.city = salesed.city;
                sales.email = salesed.email;
                sales.name = salesed.name;
                sales.state = salesed.state;
                sales.orderbydate = System.DateTime.Now;
                sales.surname = salesed.surname;
                sales.telephone = salesed.telephone;
                sales.zip = salesed.zip;
                sales.traking_no = "Waiting to be shipped";
                sales.user_id = salesed.user_id;
                ds.Salesed.Add(sales);
                ds.SaveChanges();

                foreach (var item in salesed.pro)
                {
                    ds.Sales_Product.Add(new Sales_Product { product_id = item.Product_ID, salesed_id = sales.sales_id });
                }
                ds.SaveChanges();
            }
        }
    }
}
