using CableTVAPI.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CableTVAPI.Repository
{
    public class CableRepository : BaseRepository, ICableRepository
    {
        public CableRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<List<CableEntityAPI>> GetAllProvider()
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Action", "FillProviderDD");
                var lstste = await cn.QueryAsync<CableEntityAPI>("SP_CableTV", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CableEntityAPI>> GetAllSubscription(int provider_id)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@provider_id", provider_id);
                param.Add("@Action", "FillSubscriptionDD");
                var lstste = await cn.QueryAsync<CableEntityAPI>("SP_CableTV", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdate(CableEntityAPI CE)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@registration_id", CE.registration_id);
                param.Add("@applicant_name", CE.applicant_name);
                param.Add("@email_id", CE.email_id);
                param.Add("@mobile_no", CE.mobile_no);
                param.Add("@gender", CE.gender);
                param.Add("@dob", CE.dob);
                param.Add("@image_path", CE.image_path);
                param.Add("@provider_id", CE.provider_id);
                param.Add("@subscription_id", CE.subscription_id);
                param.Add("@Action", "InsertOrUpdate");
                int x = await cn.ExecuteAsync("SP_CableTV", param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CableEntityAPI>> ViewAll()
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Action", "ViewAll");
                var lstste = await cn.QueryAsync<CableEntityAPI>("SP_CableTV", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<CableEntityAPI>> ViewOne(int registration_id)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@registration_id", registration_id);
                param.Add("@Action", "ViewOne");
                var lstste = await cn.QueryAsync<CableEntityAPI>("SP_CableTV", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
