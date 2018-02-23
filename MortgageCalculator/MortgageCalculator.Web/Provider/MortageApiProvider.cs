using MortgageCalculator.Dto;
using MortgageCalculator.Web.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MortgageCalculator.Web.Provider
{
    public class MortageApiProvider : IMortageApiProvider
    {
        private readonly HttpClient _client;
        public MortageApiProvider(IApiClientHelper client)
        {
            _client = client.HttpClient;

        }

        /// <summary>
        /// Gets all Mortages 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Mortgage> GetMortgages()
        {
            HttpResponseMessage response = _client.GetAsync(AppConstants.GET_MORTAGES_URL).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var result = JsonConvert.DeserializeObject<IEnumerable<Mortgage>>(data);
                return result;
            }
            return null;
        }
      
        public LoanDetails GetLoanRepaymentDetails(LoanDetails loandetails)
        {
            LoanDetails interestResponse = null;
            string loandetailsjson = JsonConvert.SerializeObject(loandetails);
            var httpContent = new StringContent(loandetailsjson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = _client.PostAsync(AppConstants.GET_REPAYMENTDETAILS_URL, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                interestResponse =  JsonConvert.DeserializeObject<LoanDetails>(result);
            }
            return interestResponse;
        }

        

    }
    
}