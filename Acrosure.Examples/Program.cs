using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acrosure;

namespace Acrosure.Examples
{
	class Program
	{
		public static AcrosureClient AcrosureClient { get; set; }

		static async Task GetProductList()
		{
			//AcrosureClient acrosure = new AcrosureClient(Const.TEST_PUBLIC_TOKEN);
			var result = await AcrosureClient.Product.List();
		}
		static async Task GetProduct()
		{
			AcrosureClient acrosure = new AcrosureClient(Const.TEST_PUBLIC_TOKEN);
			var result = await acrosure.Product.Get("prod_marine");
		}
		static async Task CreateAppication()
		{
			AcrosureClient acrosure = new AcrosureClient(Const.TEST_PUBLIC_TOKEN);
			var result = await acrosure.Application.Create(Const.SUBMIT_APP_DATA);
		}
		static async Task GetTeamInfo()
		{
			var result = await AcrosureClient.Team.GetInfo();
			var status = result["status"].ToString();

		}
		static void Verify()
		{
			var result = AcrosureClient.VerifySignature("4531CD338C4B3A30C8763224EB085F9202900537204B5A179C3FB4F673506822",
				@"{'data':'อโครชัว!'}");

		}
		static void Main(string[] args)
		{
			AcrosureClient = new AcrosureClient(Const.TEST_PUBLIC_TOKEN);
			GetProductList().Wait();
			//GetProduct().Wait();
			//CreateAppication().Wait();
			//GetTeamInfo().Wait();
			//Verify();

		}
	}
}