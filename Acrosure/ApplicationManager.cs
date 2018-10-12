using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Acrosure
{
	public class ApplicationManager
	{
		internal Api Api;
		private class CreateApplicationAgrs
		{
			[JsonProperty("product_id")]
			public string product_id { get; set; }

			[JsonProperty("basic_data")]
			public JObject basic_data { get; set; }

			[JsonProperty("package_options")]
			public JObject package_options { get; set; }

			[JsonProperty("additional_data")]
			public JObject additional_data { get; set; }

			[JsonProperty("attachments")]
			public JArray attachments { get; set; }

			[JsonProperty("package_code")]
			public string package_code { get; set; }

			[JsonProperty("ref1")]
			public string ref1 { get; set; }

			[JsonProperty("ref2")]
			public string ref2 { get; set; }

			[JsonProperty("ref3")]
			public string ref3 { get; set; }

			[JsonProperty("group_policy_id")]
			public string group_policy_id { get; set; }

			[JsonProperty("step")]
			public int? step { get; set; }
		}

		private class UpddateApplicationAgrs
		{
			[JsonProperty("application_id")]
			public string application_id { get; set; }

			[JsonProperty("basic_data")]
			public JObject basic_data { get; set; }

			[JsonProperty("package_options")]
			public JObject package_options { get; set; }

			[JsonProperty("additional_data")]
			public JObject additional_data { get; set; }

			[JsonProperty("attachments")]
			public JArray attachments { get; set; }

			[JsonProperty("package_code")]
			public string package_code { get; set; }

			[JsonProperty("ref1")]
			public string ref1 { get; set; }

			[JsonProperty("ref2")]
			public string ref2 { get; set; }

			[JsonProperty("ref3")]
			public string ref3 { get; set; }

			[JsonProperty("group_policy_id")]
			public string group_policy_id { get; set; }

			[JsonProperty("step")]
			public int? step { get; set; }
		}

		private class SelectPackageAgrs
		{
			[JsonProperty("application_id")]
			public string application_id { get; set; }

			[JsonProperty("package_code")]
			public string package_code { get; set; }
		}

		public class Get2C2PAgrs
		{
			[JsonProperty("application_id")]
			public string application_id { get; set; }

			[JsonProperty("frontend_url")]
			public string frontend_url { get; set; }
		}

		public async Task<JObject> GetInfo()
		{
			return await this.Api.PostAsync("teams/get-info", null) as JObject;

		}
		public async Task<JObject> List(object query)
		{
			return await this.Api.PostAsync("applications/list", query) as JObject;

		}
		public async Task<JObject> Get(string applicationId)
		{
			var data = new { application_id = applicationId };
			return await this.Api.PostAsync("applications/get", data) as JObject;
		}

		public async Task<JObject> Create(string json)
		{
			CreateApplicationAgrs data = JObject.Parse(json).ToObject<CreateApplicationAgrs>();
			return await this.Api.PostAsync("applications/create", data) as JObject;
		}
		public async Task<JObject> Create(object data)
		{
			return await this.Api.PostAsync("applications/create", data) as JObject;
		}

		public async Task<JObject> Update(string json)
		{
			UpddateApplicationAgrs data = JObject.Parse(json).ToObject<UpddateApplicationAgrs>();
			return await this.Api.PostAsync("applications/update", data) as JObject;
		}
		public async Task<JObject> Update(object data)
		{
			return await this.Api.PostAsync("applications/update", data) as JObject;
		}

		public async Task<JObject> GetPackage(string applicationId)
		{
			var data = new { application_id = applicationId };
			return await this.Api.PostAsync("applications/get-package", data) as JObject;
		}
		

		public async Task<JObject> GetPackages(string applicationId)
		{
			var data = new { application_id = applicationId };
			return await this.Api.PostAsync("applications/get-packages", data);
		}

		public async Task<JObject> SelectPackage(string json)
		{
			SelectPackageAgrs data = JObject.Parse(json).ToObject<SelectPackageAgrs>();
			return await this.Api.PostAsync("applications/select-package", data) as JObject;
		}
		public async Task<JObject> SelectPackage(object data)
		{
			return await this.Api.PostAsync("applications/select-package", data) as JObject;
		}

		public async Task<JObject> Submit(string applicationId)
		{
			var data = new { application_id = applicationId };
			return await this.Api.PostAsync("applications/submit", data) as JObject;
		}

		public async Task<JObject> Confirm(string applicationId)
		{
			var data = new { application_id = applicationId };
			return await this.Api.PostAsync("applications/confirm", data) as JObject;
		}
		

	}
}
