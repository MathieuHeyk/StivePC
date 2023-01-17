﻿using Newtonsoft.Json.Linq;
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

		public static Article ToArticle( JToken token )
		{
			Article article = new()
			{
				id = Convert.ToInt32( token[ "id" ] ),
				nom = token[ "nom" ].ToString(),
				prix_unitaire = Convert.ToDouble( token[ "prix_unitaire" ] ),
				prix_carton = Convert.ToDouble( token[ "prix_carton" ] ),
				annee = Convert.ToInt32( token[ "annee" ] ),
				id_famille = Convert.ToInt32( token[ "id_famille" ] ),
				id_fournisseur = Convert.ToInt32( token[ "id_fournisseur" ] )
			};

			return article;
		}

		public static Article ToArticle( JObject token )
		{
			Article article = new()
			{
				id = Convert.ToInt32( token[ "id" ] ),
				nom = token[ "nom" ].ToString(),
				prix_unitaire = Convert.ToDouble( token[ "prix_unitaire" ] ),
				prix_carton = Convert.ToDouble( token[ "prix_carton" ] ),
				annee = Convert.ToInt32( token[ "annee" ] ),
				id_famille = Convert.ToInt32( token[ "id_famille" ] ),
				id_fournisseur = Convert.ToInt32( token[ "id_fournisseur" ] )
			};

			return article;
		}

		public static string ToParameters( Article article, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", article.id )
								 : String.Empty;

			return includes + String.Format(
				"nom={0}&prix_unitaire={1}&prix_carton={2}&annee={3}&id_famille={4}&id_fournisseur={5}",
				Converter.NoSpaces( article.nom ),
				article.prix_unitaire.ToString(),
				article.prix_carton.ToString(),
				article.annee.ToString(),
				article.id_famille.ToString(),
				article.id_fournisseur.ToString()
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
