using System;
using System.Collections.Generic;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using System.Text;
using System.Collections.ObjectModel;
using Polling.Service.V1.Model;

namespace Polling.Service.V1.Service
{
    public class PollingService
    {
        private IPoolingProvider _poolingProvider;
        private Token _acessToken;
        private InsightsClient _insightsClient;

        public PollingService(IPoolingProvider poolingProvider)
        {
            _poolingProvider = poolingProvider;
            _insightsClient = GetInsightsClient();
        }


        private InsightsClient GetInsightsClient()
        {
            if (_insightsClient != null) return _insightsClient;

            if (_poolingProvider != null)
            {


                //_insightsClient = new InsightsClient();
                //    (new DelegateAuthenticationProvider(
                //async requestMessage =>
                //{
                //    if (_token == null || _token.IsTokenExperied())
                //        _token = await _grahpProvider.GetUserAccessTokenAsync();

                //    // Append the access token to the request
                //    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token.access_token);
                //}));


                return _insightsClient;
            }
            else
                throw new Exception("GraphProvider is null!");

        }

        //public async Task<List<object>> GetMetrics()
        //{
        //    if (_poolingProvider.get== null || _accessToken.IsTokenExperied)
        //        _accessToken = await GetUserAccessTokenAsync();

        //    var token = GetAccessToken();
        //    var creds = new TokenCloudCredentials(_subscriptionId, token);
        //    var collectionMeasurements = new List<CollectionMeasurement>();

        //    string docDbFilterString = "(name.value eq 'Total Requests' or name.value eq 'Throttled Requests')";

        //    foreach (var collection in cosmosCollections)
        //    {
        //        var metrics = new Dictionary<DateTime, Measurement>();

        //        string collectionResourceUri = string.Format(_collectionResourceBaseUri, _subscriptionId, _cosmosDbResourceGroupName, _cosmosDbAccountName, collection.DatabaseResourceId, collection.CollectionResourceId);
        //        var resourceMetrics = GetResourceMetrics(creds, collectionResourceUri, docDbFilterString, TimeSpan.FromHours(1), "PT5M");

        //        var collectionMeasurement = new CollectionMeasurement()
        //        {
        //            DatabaseId = collection.DatabaseId,
        //            CollectionId = collection.CollectionId,
        //            Measurements = resourceMetrics
        //        };
        //        collectionMeasurements.Add(collectionMeasurement);
        //    }

        //    return collectionMeasurements;
        //}


    }
}
