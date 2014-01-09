/**
JWT for .NET
Written by John Sheehan
(http://john-sheehan.com)
 
This work is public domain.
"The person who associated a work with this document has 
 dedicated the work to the Commons by waiving all of his
 or her rights to the work worldwide under copyright law
 and all related or neighboring legal rights he or she
 had in the work, to the extent allowable by law."
  
For more information, please visit:
http://creativecommons.org/publicdomain/zero/1.0/
*/

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JWT
{
	public enum JwtHashAlgorithm
	{
		HS256,
		HS384,
		HS512
	}

	public class JsonWebToken
	{
		private static Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>> HashAlgorithms;

		static JsonWebToken()
		{
			HashAlgorithms = new Dictionary<JwtHashAlgorithm, Func<byte[], byte[], byte[]>>
			{
				{ JwtHashAlgorithm.HS256, (key, value) => { using (var sha = new HMACSHA256(key)) { return sha.ComputeHash(value); } } },
				{ JwtHashAlgorithm.HS384, (key, value) => { using (var sha = new HMACSHA384(key)) { return sha.ComputeHash(value); } } },
				{ JwtHashAlgorithm.HS512, (key, value) => { using (var sha = new HMACSHA512(key)) { return sha.ComputeHash(value); } } }
			};
		}

		public static string Encode(object payload, string key, JwtHashAlgorithm algorithm)
		{
			var segments = new List<string>();
			var header = new { typ = "JWT", alg = algorithm.ToString() };

			JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
			jsonSettings.NullValueHandling = NullValueHandling.Ignore;
			jsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

			byte[] headerBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header, Formatting.None));
			byte[] payloadBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload, Formatting.None, jsonSettings));

			segments.Add(Base64UrlEncode(headerBytes));
			segments.Add(Base64UrlEncode(payloadBytes));

			var stringToSign = string.Join(".", segments.ToArray());

			var bytesToSign = Encoding.UTF8.GetBytes(stringToSign);
			var keyBytes = Encoding.UTF8.GetBytes(key);

			byte[] signature = HashAlgorithms[algorithm](keyBytes, bytesToSign);
			segments.Add(Base64UrlEncode(signature));

			return string.Join(".", segments.ToArray());
		}

		public static string Decode(string token, string key)
		{
			return Decode(token, key, true);
		}

		public static string Decode(string token, string key, bool verify)
		{
			var parts = token.Split('.');
			var header = parts[0];
			var payload = parts[1];
			byte[] crypto = Base64UrlDecode(parts[2]);

			var headerJson = Encoding.UTF8.GetString(Base64UrlDecode(header));
			var headerData = JObject.Parse(headerJson);
			var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
			var payloadData = JObject.Parse(payloadJson);

			if (verify)
			{
				var bytesToSign = Encoding.UTF8.GetBytes(string.Concat(header, ".", payload));
				var keyBytes = Encoding.UTF8.GetBytes(key);
				var algorithm = (string)headerData["alg"];

				var signature = HashAlgorithms[GetHashAlgorithm(algorithm)](keyBytes, bytesToSign);
				var decodedCrypto = Convert.ToBase64String(crypto);
				var decodedSignature = Convert.ToBase64String(signature);

				if (decodedCrypto != decodedSignature)
				{
					throw new ApplicationException(string.Format("Invalid signature. Expected {0} got {1}", decodedCrypto, decodedSignature));
				}
			}

			return payloadJson;
		}

		private static JwtHashAlgorithm GetHashAlgorithm(string algorithm)
		{
			switch (algorithm)
			{
				case "HS256": return JwtHashAlgorithm.HS256;
				case "HS384": return JwtHashAlgorithm.HS384;
				case "HS512": return JwtHashAlgorithm.HS512;
				default: throw new InvalidOperationException("Algorithm not supported.");
			}
		}

		// from JWT spec
		private static string Base64UrlEncode(byte[] input)
		{
			var output = Convert.ToBase64String(input);
			output = output.Split('=')[0]; // Remove any trailing '='s
			output = output.Replace('+', '-'); // 62nd char of encoding
			output = output.Replace('/', '_'); // 63rd char of encoding
			return output;
		}

		// from JWT spec
		private static byte[] Base64UrlDecode(string input)
		{
			var output = input;
			output = output.Replace('-', '+'); // 62nd char of encoding
			output = output.Replace('_', '/'); // 63rd char of encoding
			switch (output.Length % 4) // Pad with trailing '='s
			{
				case 0: break; // No pad chars in this case
				case 2: output += "=="; break; // Two pad chars
				case 3: output += "="; break; // One pad char
				default: throw new System.Exception("Illegal base64url string!");
			}
			var converted = Convert.FromBase64String(output); // Standard base64 decoder
			return converted;
		}
	}

}
