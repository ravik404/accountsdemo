using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Core.Converters.Json
{
    public class CurrencyStringToDecimalConverter : JsonConverter
    {

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                string stringVal = token.ToString();
                if (!string.IsNullOrWhiteSpace(stringVal))
                {
                    stringVal = stringVal.Replace("$", "");
                    return Decimal.Parse(stringVal, System.Globalization.CultureInfo.CurrentCulture);
                }
                return null;
            }
            if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
            {
                return null;
            }
            throw new JsonSerializationException($"Token type not supported: { token.Type.ToString()}");
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(decimal?));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new JsonSerializationException("Not supported");
        }
    }
}
