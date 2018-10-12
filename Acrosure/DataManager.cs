using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Acrosure
{
	public class DataManager
	{
		internal Api Api;
		private class DataAgrs
		{
			[JsonProperty("handler")]
			public string handler { get; set; }

			[JsonProperty("dependencies")]
			public JArray dependencies { get; set; }
		}

		public async Task<JObject> Get(string json)
		{
			DataAgrs data = JObject.Parse(json).ToObject<DataAgrs>();
			return await this.Api.PostAsync("data/get", data) as JObject;

		}

	}
}
