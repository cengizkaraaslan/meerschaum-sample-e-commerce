using eticaret.DataAccess;
using eticaret.Entities;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eticaret.Agility
{
    public class meerschaummarket
    {
        public int page = 1;
        public string details { get; set; }
        public meerschaummarket()
        {

            pagechange();

        }
        private async void pagechange()
        {
            int cateid = 0;
            var cate = aglitycategory.categorylist();
            while (true)
            {
                try
                {

                    int count = await Get(cate[cateid].url);
                    if (count > 0)
                    {
                        page++;
                    }
                    else
                    {
                        if (cate.Count - 1 == cateid)
                        {

                            break;

                        }
                        else
                        {
                            page = 0;
                        }
                    }
                }
                catch (Exception)
                {
                    if (cate.Count - 1 == cateid)
                    {

                        break;

                    }
                    else
                    {
                        page = 0;
                        cateid++;
                    }
                }
            }





        }
        public async Task<int> Get(string categoryurl)
        {
            //var client = _httpClientFactory.CreateClient();
            var client = new HttpClient();
            string result = await client.GetStringAsync(categoryurl + "?sort=featured&page=" + page);
            //client.BaseAddress = new Uri("https://www.meerschaummarket.com/animal-kingdom?sort=featured&page=" + page);
            //string result = await client.GetStringAsync("/");


            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(result);



            var productlist = document.DocumentNode.Descendants("article").
                  Where(node => node.GetAttributeValue("class", "").
                  Equals("card ")).ToList();

            foreach (var item in productlist)
            {
                var title = item.Descendants("h4").
                           Where(node => node.GetAttributeValue("class", "")
                           .Equals("card-title")).FirstOrDefault().InnerText.Trim();


                var link = item.Descendants("h4").
                            Where(node => node.GetAttributeValue("class", "")
                            .Equals("card-title")).FirstOrDefault().InnerHtml.Split('"').Where(F => F.StartsWith("http")).SingleOrDefault();


                var image = item.Descendants("figure").
                 Where(node => node.GetAttributeValue("class", "")
                 .Equals("card-figure")).FirstOrDefault().InnerHtml.Split('"').Where(g => g.EndsWith(".JPG?c=2")).SingleOrDefault();

                var price = item.Descendants("span").
                         Where(node => node.GetAttributeValue("class", "")
                         .Equals("price price--withoutTax")).FirstOrDefault().InnerText.Replace("$", "").Split('.')[0].Trim();
                //.Replace(".", ",")


                var detailproduct = await detail(link);

                var webdetail = detailproduct as webdetails;


                using (MeerschaumContext ds = new MeerschaumContext())
                {
                    if (ds.Products.Where(g => g.Link == link).ToList().Count < 1)
                    {
                        Products product = new Products();
                        product.Price = Convert.ToDecimal(price) * 2;
                        product.Title = title;
                        product.Link = link;
                        product.Category_ID = 1;
                        product.raiting = 2;
                        product.Satus_ID = 1;
                        product.Info = webdetail.detail;
                        #region imagefrount
                        if (webdetail.images.Count > 0)
                        {
                            product.Image = webdetail.images[0].Url;
                        }
                        else
                        {
                            break;
                        }
                        if (webdetail.images.Count > 1)
                        {
                            product.Image1 = webdetail.images[1].Url;
                        }
                        else
                        {
                            product.Image1 = webdetail.images[0].Url;
                        }
                        #endregion


                        product.mothercategory_id = 1;
                        product.undercategory_id = 2;
                        ds.Add(product);
                        ds.SaveChanges();



                        foreach (var items in webdetail.images)
                        {
                            Photo photo = new Photo();
                            photo.Url = items.Url;
                            photo.Product_ID = product.Product_ID;
                            ds.Add(photo);
                            ds.SaveChanges();
                        }
                    }
                    else
                    {
                        var product = (from f in ds.Products where f.Link == link select f).SingleOrDefault();
                        product.Price = Convert.ToDecimal(price) * 2;
                        product.Title = title;
                        product.Link = link;
                        product.Category_ID = 1;
                        product.raiting = 2;
                        product.Satus_ID = 1;
                        product.Info = webdetail.detail;
                        #region imagefrount
                        if (webdetail.images.Count > 0)
                        {
                            product.Image = webdetail.images[0].Url;
                        }
                        else
                        {
                            break;
                        }
                        if (webdetail.images.Count > 1)
                        {
                            product.Image1 = webdetail.images[1].Url;
                        }
                        else
                        {
                            product.Image1 = webdetail.images[0].Url;
                        }
                        #endregion
                        product.mothercategory_id = 1;
                        product.undercategory_id = 2;
                        ds.SaveChanges();
                    }





                }

            }

            return productlist.Count;
        }
        public async Task<webdetails> detail(string url)
        {
            //var client = _httpClientFactory.CreateClient();
            var client = new HttpClient();
            string result = await client.GetStringAsync(url);
            //client.BaseAddress = new Uri("https://www.meerschaummarket.com/imp-meerschaum-pipe-lee-van-cleef-hand-carved-in-a-fitted-case-i1686/");
            //string result = await client.GetStringAsync("/");


            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(result);

            webdetails wb = new webdetails();

            var detail = document.DocumentNode.Descendants("article").
                  Where(node => node.GetAttributeValue("class", "").
                  Equals("productView-description")).FirstOrDefault();
            wb.detail = detail.InnerHtml.Replace("clearfix", "").Replace("Product Description", "").Replace("meerschaummarket", "meerschaum");
            //foreach (var item in detail)
            //{
            //    //var image = item.Descendants("a").
            //    //           Where(node => node.GetAttributeValue("class", "")
            //    //           .Equals("productView-thumbnail-link")).FirstOrDefault().InnerText.Trim();

            //}





            var docume = document.DocumentNode.Descendants("section").
                  Where(node => node.GetAttributeValue("class", "").
                  Equals("productView-images")).FirstOrDefault();


            string[] images = docume.InnerHtml.Split('"').Where(f => f.EndsWith(".JPG?c=2") && f.Contains("1280x1280")).ToArray();


            List<Entities.Photo> p = new List<Entities.Photo>();
            foreach (var item in images)
            {
                if (p.Where(g => g.Url == item).SingleOrDefault() == null)
                {
                    p.Add(new Entities.Photo { Url = item });

                }
            }
            wb.images = p;
            return wb;
        }
    }
}
public class aglitycategory
{

    public string categoryname { get; set; }
    public string url { get; set; }
    static public List<aglitycategory> categorylist()
    {

        List<aglitycategory> list = new List<aglitycategory>();
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/classical-shapes/srv/", categoryname = "SRV Meerschaum Pipes" });

        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/classical-shapes/wgm-meerschaum-pipes/", categoryname = "WGM Meerschaum Pipes" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/classical-shape-meerschaum-pipes/", categoryname = "CLASSICAL SHAPE MEERSCHAUM PIPES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/calabash-pipes/", categoryname = "CALABASH MEERSCHAUM PIPES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/animal-kingdom/", categoryname = "ANIMAL KINGDOM" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/horror-pipes/", categoryname = "HORROR PIPES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/mythological-figures/", categoryname = "MYTHOLOGICAL FIGURES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/eagles-claw-pipes/", categoryname = "EAGLE'S CLAW PIPES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/faces-meerschaum-pipes/", categoryname = "FACES MEERSCHAUM PIPES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/dragon-meerschaum-pipes/", categoryname = "DRAGON MEERSCHAUM PIPES" });
        list.Add(new aglitycategory { url = "https://www.meerschaummarket.com/churchwarden-pipes/", categoryname = "CHURCHWARDEN PIPES" });
        //list.Add(new aglitycategory { url = "", categoryname = "" });
        //list.Add(new aglitycategory { url = "", categoryname = "" });
        //list.Add(new aglitycategory { url = "", categoryname = "" });




        return list;
    }
}
public class webdetails
{
    public List<eticaret.Entities.Photo> images { get; set; }
    public string detail { get; set; }

}