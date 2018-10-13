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
	class Team
	{
		public AcrosureClient Client { get; set; }
		public void CreateAnInstance()
		{
			Const.SetDotEnv();
			Client = new AcrosureClient(Environment.GetEnvironmentVariable("TEST_PUBLIC_TOKEN"), Environment.GetEnvironmentVariable("TEST_API_URL"));
		}
		[Test]
		public async Task GetTeamInfo()
		{
			CreateAnInstance();
			var result = await Client.Team.GetInfo();
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
		}

	}
}
