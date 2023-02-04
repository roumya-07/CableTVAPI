using CableTVAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CableTVAPI.Services
{
    public interface ICableService
    {
        public Task<List<CableEntityAPI>> GetAllProvider();
        public Task<List<CableEntityAPI>> GetAllSubscription(int provider_id);
        public Task<int> InsertOrUpdate(CableEntityAPI CE);
        public Task<List<CableEntityAPI>> ViewAll();
        public Task<List<CableEntityAPI>> ViewOne(int registration_id);

    }
}
