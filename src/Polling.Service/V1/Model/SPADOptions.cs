using System;
using System.Collections.Generic;
using System.Text;

namespace Polling.Service.V1.Model
{
    /// <summary>
    /// Service Principal Active Directory Options
    /// </summary>
    public class SPADOptions
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Instance { get; set; }

        public string TenantId { get; set; }

        public string ResourceId { get; set; }
    }
}
