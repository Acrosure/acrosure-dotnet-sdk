using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acrosure;
using NUnit.Framework;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Acrosure.Test
{
	[TestFixture]
	class Application
	{
		private AcrosureClient Client { get; set; }
		private string ApplicationId { get; set; }
		private JArray Packages { get; set; }
		public void CreateAnInstance(string token  = null)
		{
			Const.SetDotEnv();
			string appToken = !String.IsNullOrEmpty(token) ? token : Environment.GetEnvironmentVariable("TEST_PUBLIC_TOKEN");
			Client = new AcrosureClient(appToken, Environment.GetEnvironmentVariable("TEST_API_URL"));
		}
		[Test,Order(1)]
		public async Task CreateEmptyApplication()
		{
			CreateAnInstance(Environment.GetEnvironmentVariable("TEST_SECRET_TOKEN"));
			var EmplyAppData = new { product_id = Const.TEST_PRODUCT_ID };
			var result = await Client.Application.Create(EmplyAppData);
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
			JObject data = result["data"] as JObject;
			Assert.NotNull(data["id"]);
			ApplicationId = data["id"].ToString();
			string appStatus = data["status"].ToString();
			Assert.That(appStatus, Is.EqualTo("INITIAL"));
		}
		[Test, Order(2)]
		public async Task GetApplication()
		{
			//CreateAnInstance();
			var result = await Client.Application.Get(ApplicationId);
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
			JObject data = result["data"] as JObject;
			Assert.NotNull(data["id"]);
			string applicationId = data["id"].ToString();
			Assert.That(applicationId, Is.EqualTo(ApplicationId));
		}
		[Test, Order(3)]
		public async Task UpdateApplicationWithBasicData()
		{
			JObject basic_data = JObject.Parse(Const.TEST_BASIC_DATA);
			var UpdateAppData = new
			{
				application_id = ApplicationId,
				basic_data
			};
			var result = await Client.Application.Update(UpdateAppData);
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
			JObject data = result["data"] as JObject;
			Assert.NotNull(data["id"]);
			string applicationId = data["id"].ToString();
			Assert.That(applicationId, Is.EqualTo(ApplicationId));
			string appStatus = data["status"].ToString();
			Assert.That(appStatus, Is.EqualTo("PACKAGE_REQUIRED"));
		}
		
		[Test, Order(4)]
		public async Task GetPackageList()
		{
			var result = await Client.Application.GetPackages(ApplicationId);
			string status = result["status"].ToString();
			
			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JArray>(result["data"]);
			JArray data = result["data"] as JArray;
			Assert.IsTrue(data.Count() > 0);
			Packages = data;
		}
		[Test, Order(5)]
		public async Task SelectPackage()
		{
			JObject firstPackage = Packages[0] as JObject;

			var SelectPackgeData = new
			{
				application_id = ApplicationId,
				package_code  = firstPackage["package_code"].ToString()
			};

			var result = await Client.Application.SelectPackage(SelectPackgeData);
			string status = result["status"].ToString();
			
			Assert.That(status, Is.EqualTo("ok"));
			JObject data = result["data"] as JObject;
			string appStatus = data["status"].ToString();
			Assert.That(appStatus, Is.EqualTo("DATA_REQUIRED"));

		}

		[Test, Order(6)]
		public async Task GetCurrentPackage()
		{
			//CreateAnInstance();
			var result = await Client.Application.GetPackage(ApplicationId);
			string status = result["status"].ToString();
			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
			JObject data = result["data"] as JObject;
		}
		
		[Test, Order(7)]
		public async Task UpdateApplicationWithCompleteData()
		{
			//CreateAnInstance();
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
			var result = await Client.Application.Update(UpdateAppData);
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
			JObject data = result["data"] as JObject;
			Assert.NotNull(data["id"]);
			string applicationId = data["id"].ToString();
			//Assert.That(applicationId, Is.EqualTo(ApplicationId));
			string appStatus = data["status"].ToString();
			Assert.That(appStatus, Is.EqualTo("READY"));
		}
		//[Test, Order(8)]
		//public async Task SubmitApplication()
		//{
		//	//CreateAnInstance(Const.TEST_SECRET_TOKEN);
		//	var result = await Client.Application.Submit(ApplicationId);
		//	string status = result["status"].ToString();

		//	Assert.That(status, Is.EqualTo("ok"));
		//	Assert.IsInstanceOf<JObject>(result["data"]);
		//	JObject data = result["data"] as JObject;
		//	string appStatus = data["status"].ToString();
		//	Assert.That(appStatus, Is.EqualTo("SUBMITTED"));
		//}
		[Test, Order(9)]
		public async Task ConfirmApplication()
		{
			CreateAnInstance(Environment.GetEnvironmentVariable("TEST_SECRET_TOKEN"));
			var result = await Client.Application.Confirm(ApplicationId);
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JArray>(result["data"]);
			JArray data = result["data"] as JArray;
		}
	}
}
