using eticaret.Entities;
using eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.DataAccess
{
    public class EFCategoryDal : EFEntityRepositoryBase<Category, MeerschaumContext>, ICategoryDal
    {
        public List<CategoryAll> allcategory()
        {
            List<CategoryAll> categorylist = new List<CategoryAll>();
            using (MeerschaumContext ds = new MeerschaumContext())
            {


                var categoryalllist = ds.Category.ToList();
                for (int i = 0; i < categoryalllist.Count; i++)
                {
                    CategoryAll category = new CategoryAll();
                    category.Category_ID = categoryalllist[i].Category_ID;
                    category.Category_Name = categoryalllist[i].Category_Name;
                    category.mothercategory_id = categoryalllist[i].mothercategory_id;
                    var undercategorylist = ds.UnderCategory.Where(f => f.category_id == categoryalllist[i].Category_ID).ToArray();
                    category.Undercategory = undercategorylist;
                    categorylist.Add(category);
                }
            }
            return categorylist;

        }
    }
}
