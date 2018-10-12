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
		public async Task<JObject> Get(string json)
		{
			try
			{
				JObject data = JObject.Parse(json);
				return await this.Api.PostAsync("data/get", data) as JObject;
			}
			catch (Exception ex)
			{
				throw new System.Exception($"response : data is not Json string", ex);
			}
		}

	}
}
