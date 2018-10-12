﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acrosure;
using NUnit.Framework;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using DotEnv;
namespace Acrosure.Test
{

	[TestFixture]
	class Product
	{
		public AcrosureClient Client { get; set; }
		public void CreateAnInstance()
		{
			Client = new AcrosureClient(Const.TEST_PUBLIC_TOKEN, Const.TEST_API_URL);
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
		[Test]
		public async Task GetProduct()
		{
			CreateAnInstance();
			var result = await Client.Product.Get(Const.TEST_PRODUCT_ID);
			string status = result["status"].ToString();

			Assert.That(status, Is.EqualTo("ok"));
			Assert.IsInstanceOf<JObject>(result["data"]);
		} 

	}
}