using MortgageCalculator.Web.Provider;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MortgageCalculator.Web.Helpers
{
    public  class ApiClientHelper : IApiClientHelper
    {
        private  HttpClient httpClient;
        public ApiClientHelper()
        {

        }
        /// <summary>
        /// Creates an instance of HttpClient with base settings
        /// </summary>
        public  HttpClient HttpClient
        {
           get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(ConfigHelper.GetValue(AppConstants.BASE_ADDRESS));
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return httpClient;
            }
        }
    }
}