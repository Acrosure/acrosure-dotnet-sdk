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
	class Product
	{
		public AcrosureClient Client { get; set; }
		public void CreateAnInstance()
		{
			Client = new AcrosureClient(Const.TEST_PUBLIC_TOKEN);
		}
		[Test]
		public async Task GetProductList()
		{
			CreateAnInstance();
			var result = await Client.Product.List();
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JArray>(result["data"]);
		}
		//[Test]
		//public async Task GetProductList()
		//{
		//	CreateAnInstance();
		//	var result = await Client.Product.List();
		//	string status = result["status"].ToString();

		//	Assert.That(status, Is.EqualTo("ok"));
		//	Assert.IsInstanceOf<JArray>(result["data"]);
		//}		//[Test]
		//public async Task GetProductList()
		//{
		//	CreateAnInstance();
		//	var result = await Client.Product.List();
		//	string status = result["status"].ToString();

		//	Assert.That(status, Is.EqualTo("ok"));
		//	Assert.IsInstanceOf<JArray>(result["data"]);
		//}

	}
}
