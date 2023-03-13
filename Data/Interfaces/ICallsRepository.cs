using MotoHelp.Models;

namespace MotoHelp.Data.Interfaces
{
	public interface ICallsRepository
	{
		void AddCall(RequestedCall call);
		void DeleteCall(int id);
		void UpdateCallStatus(RequestedCall call, bool status);
		void UpdateCallStatus(int id);
		IEnumerable<RequestedCall> calls { get; }
	}
}
