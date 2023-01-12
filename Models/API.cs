using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class API
	{
		private static API? _instance;
		private string _url;

		private API( string url )
		{
			_url = url;
		}

		public static API GetInstance( string url = "https://localhost:7201/" )
		{
			_instance ??= new API( url );

			return _instance;
		}

		public static dynamic? GetQuery( string parameters )
		{
			API api = GetInstance();
			using HttpClient client = new();
			client.BaseAddress = new Uri( api.GetUrl() );
			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( !response.IsSuccessStatusCode )
			{
				return null;
			}

			string json = response.Content.ReadAsStringAsync().Result;
			return parameters.Contains( "All" ) ? JArray.Parse( json )
															: JObject.Parse( json );
		}

		public static bool PostQuery( string parameters )
		{
			API api = GetInstance();
			using HttpClient client = new();
			client.BaseAddress = new Uri( api.GetUrl() );
			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteQuery( string parameters )
		{
			API api = GetInstance();
			using HttpClient client = new();
			client.BaseAddress = new Uri( api.GetUrl() );
			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		private string GetUrl()
		{
			return _url;
		}
	}
}
