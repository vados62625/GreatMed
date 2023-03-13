using Microsoft.EntityFrameworkCore;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Data.Repository
{
    public class MHCategoryRepositiory : IGetDetailCategories
    {
        private readonly DBContent dBContent;

        public MHCategoryRepositiory(DBContent dBContent)
        {
            this.dBContent = dBContent;
        }

        public IEnumerable<MHCategory> categories => dBContent.MHCategory;

        public MHCategory GetCategoryById(int id)
        {
            return dBContent.MHCategory.Where(c => c.Id == id).FirstOrDefault();
        }

        public void DeleteCategory(int id)
        {
            var detail = GetCategoryById(id);
            if (detail != null)
            {
                dBContent.MHCategory.Remove(detail);
                dBContent.SaveChanges();
            }
        }

        public void EditDetail(MHCategory category)
        {
            if (category.Id == default)
                dBContent.Entry(category).State = EntityState.Added;
            else
                dBContent.Entry(category).State = EntityState.Modified;
            dBContent.SaveChanges();
        }

        public MHCategory GetCategoryByUrl(string url) => categories.Where(c => c.Url == url).FirstOrDefault();
    }
}
