using System.Net.Http;

namespace MortgageCalculator.Web.Helpers
{
    public interface IApiClientHelper
    {
        HttpClient HttpClient
        {
            get;
        }
    }
}
