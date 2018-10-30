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
		
		static void CreateAppication()
		{
			JObject basic_data = JObject.Parse(Const.TEST_BASIC_DATA);
			var EmplyAppData = new
			{
				product_id = Const.TEST_PRODUCT_ID,
				basic_data
			};
			var result = AcrosureClient.Application.Create(EmplyAppData).Result;
			JObject data = result["data"] as JObject;
			ApplicationId = data["id"].ToString();
		}


		static void GetPackageList()
		{
			var result =  AcrosureClient.Application.GetPackages(ApplicationId).Result;
			string status = result["status"].ToString();
			JArray data = result["data"] as JArray;
			Packages = data;
		}
		static void SelectPackage()
		{
			JObject firstPackage = Packages[0] as JObject;

			var SelectPackgeData = new
			{
				application_id = ApplicationId,
				package_code = firstPackage["package_code"].ToString()
			};

			var result =  AcrosureClient.Application.SelectPackage(SelectPackgeData).Result;
			string status = result["status"].ToString();
		}
		static void UpdateAppication()
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
			var result = AcrosureClient.Application.Update(UpdateAppData).Result;
			string status = result["status"].ToString();
			JObject data = result["data"] as JObject;
			string appStatus = data["status"].ToString();
		}
		static void ConfirmApplication()
		{
			var result = AcrosureClient.Application.Confirm(ApplicationId).Result;
			string status = result["status"].ToString();
		}
		static void Main(string[] args)
		{
			Const.SetDotEnv();
			AcrosureClient = new AcrosureClient(Environment.GetEnvironmentVariable("TEST_SECRET_TOKEN"), Environment.GetEnvironmentVariable("TEST_API_URL"));

			JObject teamInfo = AcrosureClient.Team.GetInfo().Result;
			JObject products = AcrosureClient.Product.List().Result;
			JObject product = AcrosureClient.Product.Get(Const.TEST_PRODUCT_ID).Result;

			CreateAppication();
			GetPackageList();
			SelectPackage();
			UpdateAppication();
			ConfirmApplication();
			
		}
	}
}