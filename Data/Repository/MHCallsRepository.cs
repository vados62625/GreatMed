using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Data.Repository
{
	public class MHCallsRepository : ICallsRepository
	{
		private readonly DBContent _dBContent;
		public MHCallsRepository(DBContent dBContent) {
			_dBContent = dBContent;
		}

		public void AddCall(RequestedCall call)
		{
			_dBContent.RequestedCall.Add(call);
			_dBContent.SaveChanges();
		}

		public void DeleteCall (int id)
		{
			var call = _dBContent.RequestedCall.FirstOrDefault(c=>c.Id==id);
			if (call != null)
			{
				_dBContent.RequestedCall.Remove(call); 
				_dBContent.SaveChanges();
			}
		}

		public IEnumerable<RequestedCall> calls => _dBContent.RequestedCall;

		public void UpdateCallStatus(RequestedCall call, bool status)
		{
			var _call = calls.Where(c=>c.Id== call.Id).FirstOrDefault();
			if (_call != null)
			{
				call.IsProcessed = status;
			}
			_dBContent.SaveChanges();
		}
        public void UpdateCallStatus(int id)
        {
            var call = calls.FirstOrDefault(c => c.Id == id);
            if (call != null)
            {
                call.IsProcessed = !call.IsProcessed;
            }
            _dBContent.SaveChanges();
        }
    }
}
