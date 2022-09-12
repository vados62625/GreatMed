using GreatMed.Data.Interfaces;
using GreatMed.Models;
using Microsoft.EntityFrameworkCore;

namespace GreatMed.Data.Repository
{
    public class GMServiceRepository : IGetServices
    {

        private readonly DBContent dBContent;

        public GMServiceRepository(DBContent dBContent)
        {
            this.dBContent = dBContent;
        }

        public IEnumerable<GMService> activeGMServices => dBContent.GMService.Where(c => c.IsActive);

        public IEnumerable<GMService> gMServices => dBContent.GMService;

        public GMService GetService(int serviceId) => dBContent.GMService.FirstOrDefault(p => p.Id == serviceId);

    }
}
