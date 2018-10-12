using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Acrosure
{
	public class TeamManager
	{
		internal Api Api;
		public async Task<JObject> GetInfo()
		{
			return await this.Api.PostAsync("teams/get-info", null) as JObject;

		}

	}
}
