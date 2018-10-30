using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acrosure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Acrosure.Examples
{
	class Program
	{
		public static AcrosureClient AcrosureClient { get; set; }
		private static string ApplicationId { get; set; }
		private static JArray Packages { get; set; }

		static async Task GetProductList()
		{
			var result = await AcrosureClient.Product.List();
		}
		static async Task GetProduct()
		{
			var result = await AcrosureClient.Product.Get(Const.TEST_PRODUCT_ID);
		}
		static async Task GetTeamInfo()
		{
			var result = await AcrosureClient.Team.GetInfo();
			var status = result["status"].ToString();
		}
		static async Task CreateAppication()
		{
			JObject basic_data = JObject.Parse(Const.TEST_BASIC_DATA);
			var EmplyAppData = new {
				product_id = Const.TEST_PRODUCT_ID,
				basic_data 
			};
			var result = await AcrosureClient.Application.Create(EmplyAppData);
			JObject data = result["data"] as JObject;
			ApplicationId = data["id"].ToString();
		}

		static async Task GetPackageList()
		{
			var result = await AcrosureClient.Application.GetPackages(ApplicationId);
			string status = result["status"].ToString();
			JArray data = result["data"] as JArray;
			Packages = data;
		}
		static async Task SelectPackage()
		{
			JObject firstPackage = Packages[0] as JObject;

			var SelectPackgeData = new
			{
				application_id = ApplicationId,
				package_code = firstPackage["package_code"].ToString()
			};

			var result = await AcrosureClient.Application.SelectPackage(SelectPackgeData);
			string status = result["status"].ToString();
		}
		static async Task UpdateAppication()
		{
			JObject basic_data = JObject.Parse(Const.TEST_BASIC_DATA);
			JObject additional_data = JObject.Parse(Const.TEST_ADDITION_DATA);
			JObject package_options = JObject.Parse(Const.TEST_PACKAGE_OPTION_DATA);
			var UpdateAppData = new
			{
				application_id = ApplicationId,
				basic_data,
				additional_data,
				package_options
			};
			var result = await AcrosureClient.Application.Update(UpdateAppData);
			string status = result["status"].ToString();
			JObject data = result["data"] as JObject;
			string appStatus = data["status"].ToString();
		}
		static async Task ConfirmApplication()
		{
			var result = await AcrosureClient.Application.Confirm(ApplicationId);
			string status = result["status"].ToString();
		}
		static void Main(string[] args)
		{
			Const.SetDotEnv();
			AcrosureClient = new AcrosureClient(Environment.GetEnvironmentVariable("TEST_SECRET_TOKEN"), Environment.GetEnvironmentVariable("TEST_API_URL"));
			GetTeamInfo().Wait();
			GetProductList().Wait();
			GetProduct().Wait();
			//CreateAppication().Wait();
			//GetPackageList().Wait();
			//SelectPackage().Wait();
			//UpdateAppication().Wait();
			//ConfirmApplication().Wait();
		}
	}
}