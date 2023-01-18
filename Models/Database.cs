using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
			string parameters = "Inventaire/GetInventaireById?id=" + id;
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

	// == LIGNE COMMANDE == //
		public static bool AddLigneCommande( LigneCommande ligneCommande )
		{
			string host = "https://localhost:7201/";
			string parameters = "LigneCommande/AddLigneCommande?" + Converter.ToParameters( ligneCommande );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<LigneCommande> GetAllLigneCommande()
		{
			string host = "https://localhost:7201/";
			string parameters = "LigneCommande/GetAllLigneCommande";
			List<LigneCommande> ligneCommandes = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray ligneCommandesJSON = JArray.Parse( json );

				foreach ( JToken token in ligneCommandesJSON )
				{
					LigneCommande ligneCommande = Converter.ToLigneCommande( token );
					ligneCommandes.Add( ligneCommande );
				}
			}

			return ligneCommandes;
		}

		public static LigneCommande GetLigneCommandeById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "LigneCommande/GetLigneCommandeById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			LigneCommande ligneCommande = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				ligneCommande = Converter.ToLigneCommande( obj );
			}

			return ligneCommande;
		}

		public static bool UpdateLigneCommande( LigneCommande ligneCommande )
		{
			string host = "https://localhost:7201/";
			string parameters = "LigneCommande/EditLigneCommande?" + Converter.ToParameters( ligneCommande, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteLigneCommande( LigneCommande ligneCommande )
		{
			string host = "https://localhost:7201/";
			string parameters = "LigneCommande/DeleteLigneCommande?id=" + ligneCommande.id_ligne_commande;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteLigneCommande( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "LigneCommande/DeleteLigneCommande?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

	// == ROLE == //
		public static bool AddRole( Role role )
		{
			string host = "https://localhost:7201/";
			string parameters = "Role/AddRole?" + Converter.ToParameters( role );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Role> GetAllRole()
		{
			string host = "https://localhost:7201/";
			string parameters = "Role/GetAllRole";
			List<Role> roles = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray rolesJSON = JArray.Parse( json );

				foreach ( JToken token in rolesJSON )
				{
					Role role = Converter.ToRole( token );
					roles.Add( role );
				}
			}

			return roles;
		}

		public static Role GetRoleById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Role/GetRoleById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Role role = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				role = Converter.ToRole( obj );
			}

			return role;
		}

		public static bool UpdateRole( Role role )
		{
			string host = "https://localhost:7201/";
			string parameters = "Role/EditRole?" + Converter.ToParameters( role, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteRole( Role role )
		{
			string host = "https://localhost:7201/";
			string parameters = "Role/DeleteRole?id=" + role.id_role;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteRole( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Role/DeleteRole?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

	// == STOCK == //
		public static bool AddStock( Stock stock )
		{
			string host = "https://localhost:7201/";
			string parameters = "Stock/AddStock?" + Converter.ToParameters( stock );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Stock> GetAllStock()
		{
			string host = "https://localhost:7201/";
			string parameters = "Stock/GetAllStock";
			List<Stock> stocks = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray stocksJSON = JArray.Parse( json );

				foreach ( JToken token in stocksJSON )
				{
					Stock stock = Converter.ToStock( token );
					stocks.Add( stock );
				}
			}

			return stocks;
		}

		public static Stock GetStockById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Stock/GetStockById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Stock stock = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				stock = Converter.ToStock( obj );
			}

			return stock;
		}

		public static bool UpdateStock( Stock stock )
		{
			string host = "https://localhost:7201/";
			string parameters = "Stock/EditStock?" + Converter.ToParameters( stock, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteStock( Stock stock )
		{
			string host = "https://localhost:7201/";
			string parameters = "Stock/DeleteStock?id=" + stock.id_stock;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteStock( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Stock/DeleteStock?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

	// == UTILISATEUR == //
		public static bool AddUtilisateur( Utilisateur utilisateur )
		{
			string host = "https://localhost:7201/";
			string parameters = "Utilisateur/AddUtilisateur?" + Converter.ToParameters( utilisateur );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PostAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static List<Utilisateur> GetAllUtilisateur()
		{
			string host = "https://localhost:7201/";
			string parameters = "Utilisateur/GetAllUtilisateur";
			List<Utilisateur> utilisateurs = new();
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JArray utilisateursJSON = JArray.Parse( json );

				foreach ( JToken token in utilisateursJSON )
				{
					Utilisateur utilisateur = Converter.ToUtilisateur( token );
					utilisateurs.Add( utilisateur );
				}
			}

			return utilisateurs;
		}

		public static Utilisateur GetUtilisateurById( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Utilisateur/GetUtilisateurById?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.GetAsync( parameters ).Result;
			Utilisateur utilisateur = new();

			if ( response.IsSuccessStatusCode )
			{
				string json = response.Content.ReadAsStringAsync().Result;
				JObject obj = JObject.Parse( json );
				utilisateur = Converter.ToUtilisateur( obj );
			}

			return utilisateur;
		}

		public static bool UpdateUtilisateur( Utilisateur utilisateur )
		{
			string host = "https://localhost:7201/";
			string parameters = "Utilisateur/EditUtilisateur?" + Converter.ToParameters( utilisateur, true );
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.PutAsync( parameters, null ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteUtilisateur( Utilisateur utilisateur )
		{
			string host = "https://localhost:7201/";
			string parameters = "Utilisateur/DeleteUtilisateur?id=" + utilisateur.id_utilisateur;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}

		public static bool DeleteUtilisateur( int id )
		{
			string host = "https://localhost:7201/";
			string parameters = "Utilisateur/DeleteUtilisateur?id=" + id;
			HttpClient client = new()
			{
				BaseAddress = new Uri( host )
			};

			HttpResponseMessage response = client.DeleteAsync( parameters ).Result;

			return response.IsSuccessStatusCode;
		}


	// == OTHERS == //
		public static List<Utilisateur> GetAllEmployes()
		{
			List<Role> roles = GetAllRole();
			Role roleEmploye = new();

			foreach ( Role role in roles )
			{
				if ( role.libelle == "Employé" )
				{
					roleEmploye = role;
				}
			}

			List<Utilisateur> utilisateurs = GetAllUtilisateur();
			List<Utilisateur> employes = new();

			foreach ( Utilisateur utilisateur in utilisateurs )
			{
				if ( utilisateur.id_role == roleEmploye.id_role )
				{
					employes.Add( utilisateur );
				}
			}

			return employes;
		}
	}
}
