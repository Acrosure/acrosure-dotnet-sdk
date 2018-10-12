﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrosure.Test
{
	class Const
	{
		public const string TEST_PUBLIC_TOKEN = "tokn_sample_public";
		public const string TEST_SECRET_TOKEN = "tokn_sample_secret";
		public const string OMISE_SKEY = @"{
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
