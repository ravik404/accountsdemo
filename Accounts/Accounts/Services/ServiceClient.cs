using Accounts.Core;
using Accounts.Core.Interfaces;
using Accounts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services
{
    public class ServiceClient : IServiceClient
    {
        private string _serviceURI = ""; // CheckMe!        
        private JsonSerializerSettings _settings;
        private ILogging _loggingService;
        public ServiceClient(ILogging loggingService)
        {
            _loggingService = loggingService;
            _settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
            };
        }

        public async Task<IEnumerable<Account>> GetListOfAccountsAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_serviceURI))
                    return DummyAccounts(); // In case user hasn't set the uri, return instrctions in the list


                System.Net.WebClient client = new System.Net.WebClient();
                var response = await client.DownloadDataTaskAsync(_serviceURI);
                if (response != null)
                {
                    var content = Encoding.UTF8.GetString(response, 0, response.Length);
                    var Items = JsonConvert.DeserializeObject<List<Account>>(content, _settings);
                    return Items;
                }
            }
            catch(Exception ex)
            {
                _loggingService?.Error(ex);
                throw ex;
            }
            return new List<Account>();

        }

        private IEnumerable<Account> DummyAccounts()
        {
            var ret = new List<Account>();
            ret.Add(new Account() { Id = "1", Gender = "male", EyeColor = "red",
                Name = new UserName() { First = "Search and Set", Last = "_serviceURI" },
                Age = 99, IsActive = true, Registered = DateTime.Today, AccountBalance = 100, PictureURI = "" });           
            return ret;
        }
    }
}
