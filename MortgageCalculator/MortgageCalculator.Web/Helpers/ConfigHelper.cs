using System.Configuration;

namespace MortgageCalculator.Web.Helpers
{
    public class ConfigHelper
    {
        /// <summary>
        /// Gets value for the given key from the AppSettings file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}