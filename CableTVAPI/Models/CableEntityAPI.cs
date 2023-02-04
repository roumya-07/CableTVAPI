using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CableTVAPI.Models
{
    public class CableEntityAPI
    {
        public int registration_id { get; set; } = 0;
        public string applicant_name { get; set; } = null;
        public string email_id { get; set; } = null;
        public string mobile_no { get; set; } = null;
        public string gender { get; set; } = null;
        public string dob { get; set; } = null;
        public string image_path { get; set; } = null;
        public int provider_id { get; set; } = 0;
        public string provider_name { get; set; } = null;
        public int subscription_id { get; set; } = 0;
        public string subscription_name { get; set; } = null;
    }
}
