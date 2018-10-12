using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
//using System.Net.WebException;


namespace Acrosure
{
	class Api
	{
		//public const string API_URL = "https://api.phantompage.com/";
		public const string API_URL = "https://api.acrosure.com/";
		public string Token { get; set; }
		public string ApiUrl { get; set; }

		//}
		//private static async Task<JObject> GetAsync(string uri)
		//{
		//	HttpClient client = new HttpClient();

		//	client.DefaultRequestHeaders.Add("Authorization", "Bearer tokn_sample_public");
		//	var content = await client.GetStringAsync(uri);
		//	//return content;
		//	return JObject.Parse(content);
		//}
		internal static async Task<JObject> PostAsync(string path, object data, string token)
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));

			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

				var response = await client.PostAsync(String.Format("{0}{1}", API_URL, path), content).ConfigureAwait(false);
				string result = await response.Content.ReadAsStringAsync();

				//return JsonConvert.DeserializeObject<T>(result);
				//return result;
				return JObject.Parse(result);
			}
			catch (Exception ex)
			{
				throw new System.Exception($"response :{ex.InnerException}", ex);
			}
		}


		internal async Task<JObject> PostAsync(string path, object data)
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", this.Token));
			string Url = !String.IsNullOrEmpty(ApiUrl) ? ApiUrl : API_URL;
			string a = JsonConvert.SerializeObject(data);
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

				var response = await client.PostAsync(
					String.Format("{0}{1}", Url, path), 
					content
					).ConfigureAwait(false);
				string result = await response.Content.ReadAsStringAsync();
				
				//JObject resultObject = JObject.Parse(result);
				//return resultObject["data"];
				return JObject.Parse(result);
			}
			catch (Exception ex)
			{
				throw new System.Exception($"response :{ex.InnerException}", ex);
			}
		}

	}
}
