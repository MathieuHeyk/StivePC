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

	// == ARTICLE == //
		public static bool AddArticle( Article article )
		{
			string host = "https://localhost:7201/";
			string parameters = "Article/AddArticle?" + Converter.ToParameters( article );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Article> GetAllArticle()
		{
			string host = "https://localhost:7201/";
			string parameters = "Article/GetAllArticle";
			List<Article> articles = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray articlesJSON = JArray.Parse( json );

				foreach ( JToken token in articlesJSON )
				{
					Article article = Converter.ToArticle( token );
					articles.Add( article );
				}
			}

			return articles;
		}

		public static Article GetArticleById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Article/GetArticleById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Article article = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				article = Converter.ToArticle( obj );
			}

			return article;
		}

		public static bool UpdateArticle( Article article )
		{
			string host = "https://localhost:7201/";
			string parameters = "Article/EditArticle?" + Converter.ToParameters( article, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteArticle( Article article )
		{
			string host = "https://localhost:7201/";
			string parameters = "Article/DeleteArticle?id=" + article.id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteArticle( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Article/DeleteArticle?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

	// == FAMILLE == //
		public static bool AddFamille( Famille famille )
		{
			string host = "https://localhost:7201/";
			string parameters = "Famille/AddFamille?" + Converter.ToParameters( famille );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Famille> GetAllFamille()
		{
			string host = "https://localhost:7201/";
			string parameters = "Famille/GetAllFamille";
			List<Famille> familles = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray famillesJSON = JArray.Parse( json );

				foreach ( JToken token in famillesJSON )
				{
					Famille famille = Converter.ToFamille( token );
					familles.Add( famille );
				}
			}

			return familles;
		}

		public static Famille GetFamilleById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Famille/GetFamilleById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Famille famille = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				famille = Converter.ToFamille( obj );
			}

			return famille;
		}

		public static bool UpdateFamille( Famille famille )
		{
			string host = "https://localhost:7201/";
			string parameters = "Famille/EditFamille?" + Converter.ToParameters( famille, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteFamille( Famille famille )
		{
			string host = "https://localhost:7201/";
			string parameters = "Famille/DeleteFamille?id=" + famille.id_famille;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteFamille( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Famille/DeleteFamille?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

	// == FOURNISSEUR == //
		public static bool AddFournisseur( Fournisseur fournisseur )
		{
			string host = "https://localhost:7201/";
			string parameters = "Fournisseur/AddFournisseur?" + Converter.ToParameters( fournisseur );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Fournisseur> GetAllFournisseur()
		{
			string host = "https://localhost:7201/";
			string parameters = "Fournisseur/GetAllFournisseur";
			List<Fournisseur> fournisseurs = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray fournisseursJSON = JArray.Parse( json );

				foreach ( JToken token in fournisseursJSON )
				{
					Fournisseur fournisseur = Converter.ToFournisseur( token );
					fournisseurs.Add( fournisseur );
				}
			}

			return fournisseurs;
		}

		public static Fournisseur GetFournisseurById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Fournisseur/GetFournisseurById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Fournisseur fournisseur = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				fournisseur = Converter.ToFournisseur( obj );
			}

			return fournisseur;
		}

		public static bool UpdateFournisseur( Fournisseur fournisseur )
		{
			string host = "https://localhost:7201/";
			string parameters = "Fournisseur/EditFournisseur?" + Converter.ToParameters( fournisseur, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteFournisseur( Fournisseur fournisseur )
		{
			string host = "https://localhost:7201/";
			string parameters = "Fournisseur/DeleteFournisseur?id=" + fournisseur.id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteFournisseur( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Fournisseur/DeleteFournisseur?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

	// == FOURNISSEUR == //
		public static bool AddInventaire( Inventaire inventaire )
		{
			string host = "https://localhost:7201/";
			string parameters = "Inventaire/AddInventaire?" + Converter.ToParameters( inventaire );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Inventaire> GetAllInventaire()
		{
			string host = "https://localhost:7201/";
			string parameters = "Inventaire/GetAllInventaire";
			List<Inventaire> inventaires = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray inventairesJSON = JArray.Parse( json );

				foreach ( JToken token in inventairesJSON )
				{
					Inventaire inventaire = Converter.ToInventaire( token );
					inventaires.Add( inventaire );
				}
			}

			return inventaires;
		}

		public static Inventaire GetInventaireById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Inventare/GetInventaireById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Inventaire inventaire = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				inventaire = Converter.ToInventaire( obj );
			}

			return inventaire;
		}

		public static bool UpdateInventaire( Inventaire inventaire )
		{
			string host = "https://localhost:7201/";
			string parameters = "Inventaire/EditInventaire?" + Converter.ToParameters( inventaire, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteInventaire( Inventaire inventaire )
		{
			string host = "https://localhost:7201/";
			string parameters = "Inventaire/DeleteInventaire?id=" + inventaire.id_inventaire;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteInventaire( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Inventaire/DeleteInventaire?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}
	}
}
