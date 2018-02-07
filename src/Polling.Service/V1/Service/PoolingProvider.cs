using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polling.Service.V1.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Polling.Service.V1.Service
{
    public class PoolingProvider : IPoolingProvider
    {
        private const string POLLING_OPTIONS_SECTION = "PollingAD";
        private SPADOptions _ADOptions;
        private Token _accessToken;

        public PoolingProvider(IConfiguration configurator)
        {
            _ADOptions = GetOptions(configurator, POLLING_OPTIONS_SECTION);
        }

        private SPADOptions GetOptions(IConfiguration configuration, string graphSection)
        {
            var adOptions = new SPADOptions();

            if (configuration.GetType().GetMethod("Bind") != null)
            {
                object[] parameters = { graphSection, adOptions };
                adOptions = configuration.GetType().GetMethod("Bind").Invoke(configuration, parameters) as GraphAdOptions;
            }
            else
            {
                adOptions.Instance = configuration.GetSection(graphSection)["Instance"];
                adOptions.TenantId = configuration.GetSection(graphSection)["TenantId"];
                adOptions.ClientId = configuration.GetSection(graphSection)["ClientId"];
                adOptions.ClientSecret = configuration.GetSection(graphSection)["ClientSecret"];
                adOptions.ResourceId = configuration.GetSection(graphSection)["ResourceId"];
            }

            return adOptions;
        }


        public async Task<Token> GetUserAccessTokenAsync()
        {

            using (HttpClient request = new HttpClient())
            {

                string postData = "grant_type=client_credentials";
                postData += "&resource=" + HttpUtility.UrlEncode(_ADOptions.ResourceId);
                postData += "&client_id=" + HttpUtility.UrlEncode(_ADOptions.ClientId);
                postData += "&client_secret=" + HttpUtility.UrlEncode(_ADOptions.ClientSecret);

                string url = $"{_ADOptions.Instance}{_ADOptions.TenantId}/oauth2/token?api-version=1.0";

                var content = new StringContent(postData, Encoding.ASCII, "application/x-www-form-urlencoded");

                var response = await request.PostAsync(url, content);
                var response_content = await response.Content.ReadAsStringAsync();

                var token = JsonConvert.DeserializeObject<Token>(response_content);

                return token;

            }
        }

    }
}
