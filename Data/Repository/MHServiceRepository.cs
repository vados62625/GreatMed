using MotoHelp.Data.Interfaces;
using MotoHelp.Models;
using Microsoft.EntityFrameworkCore;

namespace MotoHelp.Data.Repository
{
    public class MHServiceRepository : IGetServices
    {

        private readonly DBContent dBContent;

        public MHServiceRepository(DBContent dBContent)
        {
            this.dBContent = dBContent;
        }

        public IEnumerable<MHService> activeServices => services.Where(c => c.IsActive);

        public IEnumerable<MHService> services => dBContent.MHService.Include(c => c.TitlePictire);

        public MHService GetService(int serviceId) => services.FirstOrDefault(p => p.Id == serviceId);
        public void DeleteService(int id)
        {
            var service = this.GetService(id);
            if (service != null)
            {
                dBContent.MHService.Remove(service);
                dBContent.SaveChanges();
            }
        }
        public void EditService(MHService service)
        {
            if (service.Id == default)
                dBContent.Entry(service).State = EntityState.Added;
            else
                dBContent.Entry(service).State = EntityState.Modified;
            if (service.TitlePictire != null)
            {
                if (service.TitlePictire.Id == default)
                    dBContent.Entry(service.TitlePictire).State = EntityState.Added;
                else
                    dBContent.Entry(service.TitlePictire).State = EntityState.Modified;
            }
            dBContent.SaveChanges();
        }
    }
}
