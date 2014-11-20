﻿using Isla.Logging;
using Isla.Serialisation.Blacklists;
using Newtonsoft.Json;

namespace Isla.Serialisation.Components
{
    public class JsonSerializer : IJsonSerializer
    {
		public IBlacklist Blacklist { get; set; }

        #region IJsonSerializer implementation

        public T Deserialize<T>(string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }

        public string Serialize(TimedInvocation invocation)
        {
	        var serialisedInvocation = JsonConvert.SerializeObject(
		        invocation,
		        new JsonSerializerSettings { ContractResolver = new BlacklistedContractResolver(Blacklist) });

            return serialisedInvocation;
        }

        #endregion
    }
}