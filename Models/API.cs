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

		public static API GetInstance( string url )
		{
			_instance ??= new API( url );

			return _instance;
		}

		public JObject? Query( string parameters )
		{
			using HttpClient client = new();
			client.BaseAddress = new Uri( _url );
			HttpResponseMessage response = client.GetAsync( _url + parameters ).Result;

			return response.IsSuccessStatusCode ? JObject.Parse( response.Content.ReadAsStringAsync().Result ) : null;
		}
	}
}
