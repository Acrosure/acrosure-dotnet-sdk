using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Acrosure
{
	public class ProductManager
	{
		internal Api Api;
		public class Product
		{
			/*
			[JsonProperty("id")]
			public string Id { get; set; }

			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("type")]
			public string Type { get; set; }

			[JsonProperty("insurer_product_code")]
			public string InsurerProductCode { get; set; }

			[JsonProperty("form_items")]
			public JObject FormItems { get; set; }

			[JsonProperty("handler_id")]
			public string HandlerId { get; set; }

			[JsonProperty("sample_form_data")]
			public JObject SampleFormData { get; set; }

			[JsonProperty("language")]
			public string Language { get; set; }

			[JsonProperty("handler_option")]
			public JObject HandlerOption { get; set; }

			[JsonProperty("complete_process")]
			public string CompleteProcess { get; set; }

			[JsonProperty("is_form_available")]
			public bool IsFormAvailable { get; set; }
			*/

			[JsonProperty("id")]
			public string id { get; set; }

			[JsonProperty("name")]
			public string name { get; set; }

			[JsonProperty("type")]
			public string type { get; set; }

			[JsonProperty("insurer_product_code")]
			public string insurer_product_code { get; set; }

			[JsonProperty("form_items")]
			public JArray form_items { get; set; }

			[JsonProperty("handler_id")]
			public string handler_id { get; set; }

			[JsonProperty("sample_form_data")]
			public JObject sample_form_data { get; set; }

			[JsonProperty("language")]
			public string language { get; set; }

			[JsonProperty("handler_option")]
			public JObject handler_option { get; set; }

			[JsonProperty("complete_process")]
			public string complete_process { get; set; }

			[JsonProperty("is_form_available")]
			public bool is_form_available { get; set; }
		}

		public async Task<JObject> List()
		{

			return await this.Api.PostAsync("products/list", null) as JObject;

			//return 
			//return JsonConvert.DeserializeObject<List<Product>>(result["data"].ToString());
			//return JsonConvert.DeserializeObject<List<Product>>(result["data"].ToString());
		}
		public async Task<JObject> Get(string productId)
		{
			var data = new { product_id = productId };
			//var result = await this.Api.PostAsync("products/get", data);
			//return JsonConvert.DeserializeObject<Product>(result["data"].ToString());
			return await this.Api.PostAsync("products/get", data) as JObject;
		}
	}
}
