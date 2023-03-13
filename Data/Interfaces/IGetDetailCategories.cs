using MotoHelp.Models;

namespace MotoHelp.Data.Interfaces
{
    public interface IGetDetailCategories
    {
        IEnumerable<MHCategory> categories { get; }
		MHCategory GetCategoryById(int id);
        MHCategory GetCategoryByUrl(string url);
        void DeleteCategory(int id);
        void EditDetail(MHCategory detail);
    }
}
