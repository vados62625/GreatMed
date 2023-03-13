using Microsoft.EntityFrameworkCore;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Data.Repository
{
    public class MHDetailRepositiory : IGetDetails
    {
        private readonly DBContent dBContent;

        public MHDetailRepositiory(DBContent dBContent)
        {
            this.dBContent = dBContent;
        }


        //public IEnumerable<MHDetail> mHDetails => dBContent.MHDetail;
        public IEnumerable<MHDetail> details => dBContent.MHDetail
            .Include(x => x.MHCategory)
            .Include(x => x.AdditionalPictures)
            .Include(x => x.TitlePictire);
        
        public IEnumerable<MHDetail> GetDetailsByCategory(MHCategory? mHDetailCategory)
        {
            IEnumerable<MHDetail> details = this.details;
            if (mHDetailCategory != null)
            {
                details = details.Where(c => c.MHCategory == mHDetailCategory);
            }
            return details;
        }
        public MHDetail GetDetailById(int id) => details.Where(c => c.Id == id).FirstOrDefault();

        public IEnumerable<MHDetail> GetDetailsByName(string name) => details.Where(c => c.Name.Contains(name));

        public void DeleteDetail(int id)
        {
            var detail = GetDetailById(id);
            if (detail != null)
            {
                dBContent.MHDetail.Remove(detail);
                dBContent.SaveChanges();
            }
        }

        public void EditDetail(MHDetail detail)
        {
            if (detail.Id == default)
                dBContent.Entry(detail).State = EntityState.Added;
            else
                dBContent.Entry(detail).State = EntityState.Modified;
            if (detail.TitlePictire != null)
            {
                if (detail.TitlePictire.Id == default)
                    dBContent.Entry(detail.TitlePictire).State = EntityState.Added;
                else
                    dBContent.Entry(detail.TitlePictire).State = EntityState.Modified;
            }
            if (detail.AdditionalPictures != null)
            {
                foreach (var pictire in detail.AdditionalPictures)
                {
                    if (pictire.Id == default)
                        dBContent.Entry(pictire).State = EntityState.Added;
                    else
                        dBContent.Entry(pictire).State = EntityState.Modified;
                }
            }
            dBContent.SaveChanges();
        }
        public void DeleteTitlePicture(MHDetail detail)
        {
            detail.TitlePictire = null;
            dBContent.Entry(detail).State = EntityState.Modified;
            dBContent.SaveChanges();
        }

        public IEnumerable<MHDetail> GetDetailsByCategory(string categoryName) => details.Where(c => c.MHCategory.Url == categoryName);
    }
}
