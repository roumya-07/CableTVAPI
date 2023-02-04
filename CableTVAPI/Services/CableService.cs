using CableTVAPI.Models;
using CableTVAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CableTVAPI.Services
{
    public class CableService : ICableService
    {
        private readonly ICableRepository _cableRepository;
        public CableService(ICableRepository cableRepository)
        {
            _cableRepository = cableRepository;
        }

        public async Task<List<CableEntityAPI>> GetAllProvider()
        {
            return await _cableRepository.GetAllProvider();
        }

        public async Task<List<CableEntityAPI>> GetAllSubscription(int provider_id)
        {
            return await _cableRepository.GetAllSubscription(provider_id);
        }

        public async Task<int> InsertOrUpdate(CableEntityAPI CE)
        {
            return await _cableRepository.InsertOrUpdate(CE);
        }

        public async Task<List<CableEntityAPI>> ViewAll()
        {
            return await _cableRepository.ViewAll();
        }

        public async Task<List<CableEntityAPI>> ViewOne(int registration_id)
        {
            return await _cableRepository.ViewOne(registration_id);
        }
    }
}
