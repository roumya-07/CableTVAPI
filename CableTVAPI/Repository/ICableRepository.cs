using CableTVAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CableTVAPI.Repository
{
    public interface ICableRepository
    {
        public Task<List<CableEntityAPI>> GetAllProvider();
        public Task<List<CableEntityAPI>> GetAllSubscription(int provider_id);
        public Task<int> InsertOrUpdate(CableEntityAPI CE);
        public Task<List<CableEntityAPI>> ViewAll();
        public Task<List<CableEntityAPI>> ViewOne(int registration_id);

    }
}
