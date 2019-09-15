using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ClayBackendCase.API.Presenters
{
    public abstract class BasePresenter
    {
        public ContentResult Result { get; set; }

        public BasePresenter()
        {
            Result = new ContentResult
            {
                ContentType = "application/json"
            };
        }

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
        }

        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver { }
    }
}
