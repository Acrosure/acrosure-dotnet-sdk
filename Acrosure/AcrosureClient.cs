using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Cryptography;

namespace Acrosure
{
	public class AcrosureClient 
	{
		public string Token { get; private set; }
		public string ApiUrl { get; private set; }
		internal Api Api;
		public readonly ProductManager Product;
		public readonly PolicyManager Policy;
		public readonly ApplicationManager Application;
		public readonly TeamManager Team;
		public readonly DataManager Data;
		public AcrosureClient(string token = null,string apiUrl =null)
		{
			this.Token = token;
			this.ApiUrl = apiUrl;
			Api = new Api {
				Token = token,
				ApiUrl = apiUrl
			};
			Product = new ProductManager
			{
				Api = Api
			};

			Policy = new PolicyManager
			{
				Api = Api
			};

			Application = new ApplicationManager
			{
				Api = Api
			};

			Team = new TeamManager
			{
				Api = Api
			};

			Data = new DataManager
			{
				Api = Api
			};

		}
		
		private static string HashEncode(byte[] hash)
		{
			return BitConverter.ToString(hash).Replace("-", "").ToLower();
		}
		public bool VerifySignature(string signature , string data)
		{
			JObject jsonObject = JObject.Parse(data);

			string message = jsonObject["data"].ToString();
			

			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
			byte[] keyByte = encoding.GetBytes(this.Token);

			HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

			byte[] messageBytes = encoding.GetBytes(message);
			byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

			string expected = HashEncode(hashmessage);
			return expected == signature;
		}
	}
}
