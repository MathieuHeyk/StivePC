using Newtonsoft.Json.Linq;
using System;

namespace StivePC.Models
{
	internal class Converter
	{
		public static Lieu ToLieu( JToken token )
		{
			Lieu lieu = new()
			{
				id_lieu = Convert.ToInt32( token[ "id_lieu" ] ),
				numero = token[ "numero" ].ToString(),
				type = token[ "type" ].ToString(),
				nom = token[ "nom" ].ToString(),
				ville = token[ "ville" ].ToString(),
				code_postal = token[ "code_postal" ].ToString(),
				pays = token[ "pays" ].ToString()
			};

			return lieu;
		}

		public static Lieu ToLieu( JObject token )
		{
			Lieu lieu = new()
			{
				id_lieu = Convert.ToInt32( token[ "id_lieu" ] ),
				numero = token[ "numero" ].ToString(),
				type = token[ "type" ].ToString(),
				nom = token[ "nom" ].ToString(),
				ville = token[ "ville" ].ToString(),
				code_postal = token[ "code_postal" ].ToString(),
				pays = token[ "pays" ].ToString()
			};

			return lieu;
		}

		public static string ToParameters( Lieu lieu, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", lieu.id_lieu )
								 : String.Empty;

			return includes + String.Format(
				"numero={0}&type={1}&nom={2}&ville={3}&code_postal={4}&pays={5}",
				Converter.NoSpaces( lieu.numero ),
				Converter.NoSpaces( lieu.type ),
				Converter.NoSpaces( lieu.nom ),
				Converter.NoSpaces( lieu.ville ),
				Converter.NoSpaces( lieu.code_postal ),
				Converter.NoSpaces( lieu.pays )
			);
		}

		public static string NoSpaces( string value )
		{
			return value.Contains( ' ' )
				  ? String.Join( "%20", value.Split( ' ' ) )
				  : value;
		}
	}
}
