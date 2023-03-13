using MotoHelp.Models;

namespace MotoHelp.Data.Interfaces
{
    public interface IGetDetails
    {
        IEnumerable<MHDetail> details { get; }
        IEnumerable<MHDetail> GetDetailsByCategory(MHCategory mHDetailCategory);
        IEnumerable<MHDetail> GetDetailsByCategory(string categoryName);
		MHDetail GetDetailById(int id);
        IEnumerable<MHDetail> GetDetailsByName(string name);
        void DeleteDetail(int id);
        void EditDetail(MHDetail detail);
        void DeleteTitlePicture(MHDetail detail);
    }
}
