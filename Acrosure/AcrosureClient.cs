using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;
using System.Security;


namespace Acrosure
{
	public class AcrosureClient 
	{
		public string Token { get; private set; }

		internal Api Api;
		public readonly ProductManager Product;
		public readonly PolicyManager Policy;
		public readonly ApplicationManager Application;
		public readonly TeamManager Team;
		public readonly DataManager Data;
		public AcrosureClient(string token = null)
		{
			this.Token = token;
			Api = new Api {
				Token = token
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

		//public static string HmacSha256Digest(this string message, string secret)
		//{
		//	ASCIIEncoding encoding = new ASCIIEncoding();
		//	byte[] keyBytes = encoding.GetBytes(secret);
		//	byte[] messageBytes = encoding.GetBytes(message);
		//	System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);

		//	byte[] bytes = cryptographer.ComputeHash(messageBytes);

		//	return BitConverter.ToString(bytes).Replace("-", "").ToLower();
		//}
		public JObject VerifySignature(string signature , string data)
		{
			JObject jsonObject = JObject.Parse(data);
			//System.Text.ASCIIEncoding
			//var a = HMACSHA256
			return jsonObject;
		}
	}
}
