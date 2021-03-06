﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Acrosure.Examples
{
	class Const
	{
		private static void ConfigRunner(bool throwOnError = true, string filePath = ".env", Encoding encoding = null)
		{
			// if configured to throw errors then throw otherwise return
			if (!File.Exists(filePath))
			{
				if (throwOnError)
				{
					throw new FileNotFoundException($"An enviroment file with path \"{filePath}\" does not exist.");
				}
				return;
			}

			if (encoding == null)
			{
				encoding = Encoding.Default;
			}

			// read all lines from the env file
			string dotEnvContents = File.ReadAllText(filePath, encoding);

			// split the long string into an array of rows
			string[] dotEnvRows = dotEnvContents.Split(new[] { "\n", "\r\n", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			// loop through rows, split into key and value then add to enviroment
			foreach (var row in dotEnvRows)
			{
				var dotEnvRow = row.Trim();
				if (dotEnvRow.StartsWith("#"))
					continue;

				int index = dotEnvRow.IndexOf("=");

				if (index >= 0)
				{
					string key = dotEnvRow.Substring(0, index).Trim();
					string value = dotEnvRow.Substring(index + 1, dotEnvRow.Length - (index + 1)).Trim();

					if (key.Length > 0)
					{
						if (value.Length == 0)
						{
							Environment.SetEnvironmentVariable(key, null);
						}
						else
						{
							Environment.SetEnvironmentVariable(key, value);
						}
					}
				}
			}
		}
		public static void SetDotEnv()
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "../../.env");
			ConfigRunner(false, path,null);
		}
		public const string TEST_PRODUCT_ID = "prod_ta";
		public const string SUBMIT_EMPTY_APP_DATA = @"{product_id: 'prod_ta'}";
		public const string TEST_BASIC_DATA = @"{
			countries: ['GERMANY', 'JAPAN'],
			policy_date: '2018-12-11',
			expiry_date: '2018-12-18',
			policy_unit: 'D'
		  }";
		public const string TEST_ADDITION_DATA = @"{
			customer_title: 'MR.',
			customer_first_name: 'MANA',
			customer_last_name: 'MUNGMARN',
			company_name: '-',
			card_type: 'I',
			id_card: '1489900087857',
			email: 'developer@example.com',
			phone: '0810000000',
			insurer_list: [
			  {
				title: 'MR.',
				first_name: 'MANA',
				last_name: 'MUNGMARN',
				card_type: 'I',
				id_card: '1489900087857',
				birthdate: '1988-10-14',
				email: 'developer@example.com',
				phone: '0812345678',
				nominee: '',
				relationship: '',
				address: {
				  address_no: '1',
				  moo: '2',
				  village: 'VILLAGE',
				  alley: '',
				  lane: 'LAD PRAO 4',
				  street: 'LAD PRAO',
				  minor_district: '',
				  subdistrict: 'Chomphon',
				  district: 'Chatuchak',
				  province: 'Bangkok',
				  postal_code: '10900'
				}
			  },
			  {
				title: 'MR.',
				first_name: 'MANEE',
				last_name: 'MUNGMARN',
				card_type: 'I',
				id_card: '1682086540364',
				birthdate: '1988-12-31',
				email: 'developer@example.com',
				phone: '0812345678',
				nominee: 'MR. MANOCH MUNGMARN',
				relationship: 'Brother/Sister',
				address: {
				  address_no: '1',
				  moo: '2',
				  village: 'VILLAGE',
				  alley: '',
				  lane: 'LAD PRAO 4',
				  street: 'LAD PRAO',
				  minor_district: '',
				  subdistrict: 'Chomphon',
				  district: 'Chatuchak',
				  province: 'Bangkok',
				  postal_code: '10900'
				}
			  }
			]
		  }";
		public const string TEST_PACKAGE_OPTION_DATA = @"{insurer_count: 2}";
		public const string SUBMIT_APP_DATA = @"{
			  product_id: 'prod_contractor',
			  basic_data: {
				contract_value: 10000000,
				existing_property_value: 3000000,
				gross_floor_area: 15000,
				project_type: 'Residential',
				contractor_grade: 'A'
			  },
			  package_options: null,
			  additional_data: {
				principal: {
				  name: 'บริษัท ผู้ว่าจ้าง จำกัด',
				  address: {
					address_no: '1',
					moo: '2',
					village: 'วิลเลจ 3',
					alley: '',
					lane: 'ลาดพร้าว 4',
					street: 'ลาดพร้าว',
					minor_district: '',
					subdistrict: 'จอมพล',
					district: 'จตุจักร',
					province: 'กรุงเทพมหานคร',
					postal_code: '10900'
				  }
				},
				contractor: {
				  name: 'บริษัท ผู้รับเหมา จำกัด',
				  title: 'นาย',
				  first_name: 'สมชาย',
				  last_name: 'สายชม',
				  tax_id: '1111111111119',
				  branch: 'สมุทรปราการ',
				  phone: '0811111111',
				  email: 'somchai@email.com',
				  address: {
					address_no: '1',
					moo: '2',
					village: 'วิลเลจ 3',
					alley: '',
					lane: 'ลาดพร้าว 4',
					street: 'ลาดพร้าว',
					minor_district: '',
					subdistrict: 'จอมพล',
					district: 'จตุจักร',
					province: 'กรุงเทพมหานคร',
					postal_code: '10900'
				  }
				},
				delivery: {
				  name: 'นายสมชาย สายชม',
				  policy_postal: false,
				  address: {
					address_no: '1',
					moo: '2',
					village: 'วิลเลจ 3',
					alley: '',
					lane: 'ลาดพร้าว 4',
					street: 'ลาดพร้าว',
					minor_district: '',
					subdistrict: 'จอมพล',
					district: 'จตุจักร',
					province: 'กรุงเทพมหานคร',
					postal_code: '10900'
				  }
				},
				project_name: 'โครงการ อโครบิวดิ้ง',
				project_site: {
				  subdistrict: 'จอมพล',
				  district: 'จตุจักร',
				  province: 'กรุงเทพมหานคร'
				},
				project_effective_date: '2018-10-01',
				project_expiry_date: '2019-10-01',
				project_duration: 365,
				warranty_duration: 5,
				warranty_expiry_date: '2018-10-06',
				payment_type: 'ONLINE',
				policy_code: '',
				files: null
			  }
			}";
	}
}
