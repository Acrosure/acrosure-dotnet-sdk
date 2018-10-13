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
	class Data
	{
		public AcrosureClient Client { get; set; }
		public void CreateAnInstance()
		{
			Const.SetDotEnv();
			Client = new AcrosureClient(Environment.GetEnvironmentVariable("TEST_PUBLIC_TOKEN"), Environment.GetEnvironmentVariable("TEST_API_URL"));
		}
		[Test]
		public async Task GetDataValuesNoDependencies()
		{
			CreateAnInstance();
			var result = await Client.Data.Get(@"{handler: 'province'}");
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JArray>(result["data"]);
		}
		[Test]
		public async Task GetDataValuesOneDependencies()
		{
			CreateAnInstance();
			var result = await Client.Data.Get(@"{handler: 'district',dependencies: ['กรุงเทพมหานคร']}");
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JArray>(result["data"]);
		}
		[Test]
		public async Task GetDataValuesTwoDependencies()
		{
			CreateAnInstance();
			var result = await Client.Data.Get(@"{handler: 'district',dependencies:  ['กรุงเทพมหานคร', 'ห้วยขวาง']}");
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JArray>(result["data"]);
		}

	}
}

