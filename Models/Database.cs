using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace StivePC.Models
{
	internal class Database
	{
	// == LIEU == //
		public static bool AddLieu( Lieu lieu )
		{
			string host = "https://localhost:7201/";
			string parameters = "Lieu/AddLieu?" + Converter.ToParameters( lieu );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Lieu> GetAllLieu()
		{
			string host = "https://localhost:7201/";
			string parameters = "Lieu/GetAllLieu";
			List<Lieu> lieux = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray lieuxJSON = JArray.Parse( json );

				foreach ( JToken token in lieuxJSON )
				{
					Lieu lieu = Converter.ToLieu( token );
					lieux.Add( lieu );
				}
			}

			return lieux;
		}

		public static Lieu GetLieuById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Lieu/GetLieuById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Lieu lieu = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				lieu = Converter.ToLieu( obj );
			}

			return lieu;
		}

		public static bool UpdateLieu( Lieu lieu )
		{
			string host = "https://localhost:7201/";
			string parameters = "Lieu/EditLieu?" + Converter.ToParameters( lieu, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteLieu( Lieu lieu )
		{
			string host = "https://localhost:7201/";
			string parameters = "Lieu/DeleteLieu?id=" + lieu.id_lieu;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteLieu( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Lieu/DeleteLieu?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}
	}
}
