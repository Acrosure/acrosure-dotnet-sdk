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
			Client = new AcrosureClient(Const.TEST_PUBLIC_TOKEN, Const.TEST_API_URL);
		}
		[Test]
		public void VeriflySignature()
		{
			CreateAnInstance();
			var isValid = Client.VerifySignature("7d903d2deec25fb075d38e6cd909db653299f6006a57379ee955de1f5a925795", @"{'data':'อโครชัว!'}");
			
			Assert.That(isValid, Is.EqualTo(true));
		}

	}
}
