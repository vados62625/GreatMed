using GreatMed.Models;

namespace GreatMed.Data.Interfaces
{
    public interface IGetServices
    {

        IEnumerable<GMService> gMServices { get; }

        GMService GetService(int serviceId);

    }
}
