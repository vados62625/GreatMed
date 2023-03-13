using MotoHelp.Models;

namespace MotoHelp.Data.Interfaces
{
    public interface IImagesRepository
    {
        ImageUri GetImageUri(int id);
        void Delete(int id);
        IEnumerable<ImageUri> ImageUris { get; }
    }
}
