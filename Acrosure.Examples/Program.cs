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
			var result = AcrosureClient.VerifySignature("7d903d2deec25fb075d38e6cd909db653299f6006a57379ee955de1f5a925795",
				@"{'data':'อโครชัว!'}");

		}
		static void Main(string[] args)
		{
			AcrosureClient = new AcrosureClient(Const.TEST_PUBLIC_TOKEN);
			///GetProductList().Wait();
			//GetProduct().Wait();
			//CreateAppication().Wait();
			//GetTeamInfo().Wait();
			//Verify();


			string UpdateAppData = String.Format(@"{
				application_id : {0},
				basic_data: {
				contract_value: 10000000,
				existing_property_value: 3000000,
				gross_floor_area: 15000,
				project_type: 'Residential',
				contractor_grade: 'A'
			  }
			}", "sandbox_appl_fiv0e4tXoXK2uQIM");

			var a = UpdateAppData;
		}
	}
}