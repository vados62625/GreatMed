using GreatMed.Data;
using Microsoft.EntityFrameworkCore;

namespace GreatMed.Repository
{

    public class GMServiceRepository
    {

        private readonly DBContent dBContent;

        public GMServiceRepository (DBContent dBContent)
        {
            this.dBContent = dBContent;
        }

        public IEnumerable<GMService> gMServices => dBContent.GMService.Include(c => c.IsActive);

        public GMService GetService(int id) => dBContent.GMService.FirstOrDefault(p => p.Id == id);

    }
}
