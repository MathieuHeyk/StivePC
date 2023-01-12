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

		public static dynamic? Query( string parameters )
		{
			API api = GetInstance();
			using HttpClient client = new();
			client.BaseAddress = new Uri( api.GetUrl() );
			HttpResponseMessage response = client.GetAsync( api.GetUrl() + parameters ).Result;

			if ( !response.IsSuccessStatusCode )
			{
				return null;
			}

			string json = response.Content.ReadAsStringAsync().Result;
			return parameters.Contains( "All" ) ? JArray.Parse( json )
															: JObject.Parse( json );
		}

		private string GetUrl()
		{
			return _url;
		}
	}
}
