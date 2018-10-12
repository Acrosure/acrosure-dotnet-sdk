using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Acrosure
{
	public class PolicyManager
	{
		internal Api Api;
		public async Task<JObject> List()
		{
			return await this.Api.PostAsync("policies/list", null) as JObject;

		}
		public async Task<JObject> Get(string policyId)
		{
			var data = new { policy_id = policyId };
			return await this.Api.PostAsync("policies/get", data) as JObject;
		}
	}
}
