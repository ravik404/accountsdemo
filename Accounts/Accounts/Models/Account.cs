using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Accounts.Core.Converters.Json;
using System.Collections.ObjectModel;

namespace Accounts.Models
{
    public class Account
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        public bool IsActive { get; set; }

        [JsonConverter(typeof(CurrencyStringToDecimalConverter))]
        public decimal? AccountBalance { get; set; }

        [JsonProperty("picture")]
        public string PictureURI { get; set; }

        public int Age { get; set; }

        public string EyeColor { get; set; }

        public string Gender { get; set; }

        public UserName Name { get; set; }

        public string GroupName { get; set; }


        public DateTime Registered { get; set; }
    }

    public class GenderGroup
    { 
        public string GroupName { get;  set; }
        public ObservableCollection<Account> Accounts { get; set; }

        public override string ToString()
        {
            return GroupName;
        }
    }
}
