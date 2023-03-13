using MotoHelp.Models;

namespace MotoHelp.Data.Interfaces
{
    public interface IGetServices
    {

        IEnumerable<MHService> services { get; }

        MHService GetService(int serviceId);
		IEnumerable<MHService> activeServices { get; }
        void DeleteService(int serviceId);
        void EditService(MHService service);

    }
}
