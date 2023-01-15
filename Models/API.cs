using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	public sealed class API
		 // sealed => avoid sub-object of API
	{
		private static API? _instance;
		private string _url;

		private API( string url )
		{
			_url = url;
		}

		public static API GetInstance( string url = "https://localhost:7201/" )
		{
			_instance ??= new API( url ); // Set API if not yet
			return _instance;
		}

		private string GetUrl()
		{
			return _url;
		}

		public static dynamic? GetQuery( string parameters )
		{
			string apiUrl		= GetInstance().GetUrl();
			HttpClient client = new()
			{
				BaseAddress = new Uri( apiUrl )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( !response.IsSuccessStatusCode )
			{
				return null;
			}

			string result = response.Content.ReadAsStringAsync().Result;

			return parameters.Contains( "All" )
				  ? JArray.Parse( result ) 		// Multiples elements
				  : JObject.Parse( result );  	// Single element
		}

	// ToDo: Rewrite editing functions to avoid using API (if enough time)
		public static bool PostQuery( string parameters )
		{
			string apiUrl		 = GetInstance().GetUrl();
			HttpClient client  = new()
			{
				BaseAddress = new Uri( apiUrl )
			};
			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteQuery( string parameters )
		{
			string apiUrl		 = GetInstance().GetUrl();
			HttpClient client  = new()
			{
				BaseAddress = new Uri( apiUrl )
			};
			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool UpdateQuery( string parameters )
		{
			string apiUrl		 = GetInstance().GetUrl();
			HttpClient client  = new()
			{
				BaseAddress = new Uri( apiUrl )
			};
			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}
	}
}
