using Microsoft.EntityFrameworkCore;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Data.Repository
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly DBContent dBContent;
        public ImagesRepository(DBContent dBContent) { 
            this.dBContent = dBContent;
        }
        public IEnumerable<ImageUri> ImageUris => dBContent.ImageUri.Include(c => c.AdditionalMHDetail).Include(c => c.TitleMHDetail);

        public ImageUri GetImageUri(int id) => ImageUris.Where(c => c.Id == id).FirstOrDefault();

        public void Delete(int id)
        {
            var imageUri = GetImageUri(id);
            if (imageUri != null)
            {
                dBContent.ImageUri.Remove(imageUri);
                dBContent.SaveChanges();
            }
        }
    }
}
