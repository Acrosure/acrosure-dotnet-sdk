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
	class ClientTest
	{
		public AcrosureClient Client { get; set; }
		public void CreateAnInstance()
		{
			Const.SetDotEnv();
			Client = new AcrosureClient(Environment.GetEnvironmentVariable("TEST_PUBLIC_TOKEN"), Environment.GetEnvironmentVariable("TEST_API_URL"));
		}
		[Test]
		public void VeriflySignature()
		{
			CreateAnInstance();
			var isValid = Client.VerifySignature(Environment.GetEnvironmentVariable("VERIFY_STRING"), @"{'data':'อโครชัว!'}");
			
			Assert.That(isValid, Is.EqualTo(true));
		}

	}
}
