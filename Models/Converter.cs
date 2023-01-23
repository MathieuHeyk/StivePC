using Newtonsoft.Json.Linq;
using System;

namespace StivePC.Models
{
	internal class Converter
	{
	// == LIEU == //
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

	// == ARTICLE == //
		public static Article ToArticle( JToken token )
		{
			Article article = new()
			{
				id = Convert.ToInt32( token[ "id" ] ),
				nom = token[ "nom" ].ToString(),
				prix_unitaire = Convert.ToDouble( token[ "prix_unitaire" ] ),
				prix_carton = Convert.ToDouble( token[ "prix_carton" ] ),
				annee = Convert.ToInt32( token[ "annee" ] ),
				id_famille = Convert.ToInt32( token[ "iD_famille" ] ),
				id_fournisseur = Convert.ToInt32( token[ "iD_fournisseur" ] )
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
				id_famille = Convert.ToInt32( token[ "iD_famille" ] ),
				id_fournisseur = Convert.ToInt32( token[ "iD_fournisseur" ] )
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
				string.Join('.', article.prix_unitaire.ToString().Split(',')),
				string.Join('.', article.prix_carton.ToString().Split(',')),
				article.annee.ToString(),
				article.id_famille.ToString(),
				article.id_fournisseur.ToString()
			);
		}

	// == FAMILLE == //
		public static Famille ToFamille( JToken token )
		{
			Famille famille = new()
			{
				id_famille = Convert.ToInt32( token[ "id_famille" ] ),
				libelle = token[ "libelle" ].ToString()
			};

			return famille;
		}

		public static Famille ToFamille( JObject token )
		{
			Famille famille = new()
			{
				id_famille = Convert.ToInt32( token[ "id_famille" ] ),
				libelle = token[ "libelle" ].ToString()
			};

			return famille;
		}

		public static string ToParameters( Famille famille, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", famille.id_famille )
								 : String.Empty;

			return includes + String.Format(
				"libelle={0}",
				Converter.NoSpaces( famille.libelle )
			);
		}

	// == FOURNISSEUR == //
		public static Fournisseur ToFournisseur( JToken token )
		{
			Fournisseur fournisseur = new()
			{
				id = Convert.ToInt32( token[ "id" ] ),
				nom = token[ "nom" ].ToString(),
				telephone = token[ "telephone" ].ToString(),
				email = token[ "email" ].ToString(),
				id_lieu = Convert.ToInt32( token[ "id_lieu" ] )
			};

			return fournisseur;
		}

		public static Fournisseur ToFournisseur( JObject token )
		{
			Fournisseur fournisseur = new()
			{
				id = Convert.ToInt32( token[ "id" ] ),
				nom = token[ "nom" ].ToString(),
				telephone = token[ "telephone" ].ToString(),
				email = token[ "email" ].ToString(),
				id_lieu = Convert.ToInt32( token[ "id_lieu" ] )
			};

			return fournisseur;
		}

		public static string ToParameters( Fournisseur fournisseur, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", fournisseur.id )
								 : String.Empty;

			return includes + String.Format(
				"nom={0}&telepone={1}&email={2}&id_lieu={3}",
				Converter.NoSpaces( fournisseur.nom ),
				Converter.NoSpaces( fournisseur.telephone ),
				Converter.NoSpaces( fournisseur.email ),
				fournisseur.id_lieu.ToString()
			);
		}

	// == INVENTAIRE == //
		public static Inventaire ToInventaire( JToken token )
		{
			Inventaire inventaire = new()
			{
				id_inventaire = Convert.ToInt32( token[ "id" ] ),
				id_article = Convert.ToInt32( token[ "id_article" ] ),
				quantite = Convert.ToInt32( token[ "quantite" ] ),
				date = token[ "date" ].ToString(),
				id_utilisateur = Convert.ToInt32( token[ "id_utilisateur" ] )
			};

			return inventaire;
		}

		public static Inventaire ToInventaire( JObject token )
		{
			Inventaire inventaire = new()
			{
				id_inventaire = Convert.ToInt32( token[ "id" ] ),
				id_article = Convert.ToInt32( token[ "id_article" ] ),
				quantite = Convert.ToInt32( token[ "quantite" ] ),
				date = token[ "date" ].ToString(),
				id_utilisateur = Convert.ToInt32( token[ "id_utilisateur" ] )
			};

			return inventaire;
		}

		public static string ToParameters( Inventaire inventaire, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", inventaire.id_inventaire )
								 : String.Empty;

			return includes + String.Format(
				"id_article={0}&quantite={1}&date={2}&id_utilisateur={3}",
				inventaire.id_article.ToString(),
				inventaire.quantite.ToString(),
				Converter.NoSpaces( inventaire.date ),
				inventaire.id_utilisateur.ToString()
			);
		}

	// == LIGNE COMMANDE == //
		public static LigneCommande ToLigneCommande( JToken token )
		{
			LigneCommande ligneCommande = new()
			{
				id_ligne_commande = Convert.ToInt32( token[ "id_ligne_commande" ] ),
				id_article = Convert.ToInt32( token[ "id_article" ] ),
				quantite = Convert.ToInt32( token[ "quantite" ] ),
				num_commande = Convert.ToInt32( token[ "num_commande" ] )
			};

			return ligneCommande;
		}

		public static LigneCommande ToLigneCommande( JObject token )
		{
			LigneCommande ligneCommande = new()
			{
				id_ligne_commande = Convert.ToInt32( token[ "id_ligne_commande" ] ),
				id_article = Convert.ToInt32( token[ "id_article" ] ),
				quantite = Convert.ToInt32( token[ "quantite" ] ),
				num_commande = Convert.ToInt32( token[ "num_commande" ] )
			};

			return ligneCommande;
		}

		public static string ToParameters( LigneCommande ligneCommande, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", ligneCommande.id_ligne_commande )
								 : String.Empty;

			return includes + String.Format(
				"id_article={0}&quantite={1}&num_commande={2}",
				ligneCommande.id_article.ToString(),
				ligneCommande.quantite.ToString(),
				ligneCommande.num_commande.ToString()
			);
		}

	// == ROLE == //
		public static Role ToRole( JToken token )
		{
			Role role = new()
			{
				id_role = Convert.ToInt32( token[ "id_role" ] ),
				libelle = token[ "libelle" ].ToString()
			};

			return role;
		}

		public static Role ToRole( JObject token )
		{
			Role role = new()
			{
				id_role = Convert.ToInt32( token[ "id_role" ] ),
				libelle = token[ "libelle" ].ToString()
			};

			return role;
		}

		public static string ToParameters( Role role, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", role.id_role )
								 : String.Empty;

			return includes + String.Format(
				"libelle={0}",
				Converter.NoSpaces( role.libelle )
			);
		}

	// == STOCK == //
		public static Stock ToStock( JToken token )
		{
			Stock stock = new()
			{
				id_stock = Convert.ToInt32( token[ "id_stock" ] ),
				id_article = Convert.ToInt32( token[ "id_article" ] ),
				quantite = Convert.ToInt32( token[ "quantite" ] )
			};

			return stock;
		}

		public static Stock ToStock( JObject token )
		{
			Stock stock = new()
			{
				id_stock = Convert.ToInt32( token[ "id_stock" ] ),
				id_article = Convert.ToInt32( token[ "id_article" ] ),
				quantite = Convert.ToInt32( token[ "quantite" ] )
			};

			return stock;
		}

		public static string ToParameters( Stock stock, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", stock.id_stock )
								 : String.Empty;

			return includes + String.Format(
				"id_aticle={0}&quantite={1}",
				stock.id_article.ToString(),
				stock.quantite.ToString()
			);
		}

	// == UTILISATEUR == //
		public static Utilisateur ToUtilisateur( JToken token )
		{
			Utilisateur utilisateur = new()
			{
				id_utilisateur = Convert.ToInt32( token[ "id_utilisateur" ] ),
				nom = token[ "nom" ].ToString(),
				prenom = token[ "prenom" ].ToString(),
				email = token[ "email" ].ToString(),
				password = token[ "password" ].ToString(),
				telephone = token[ "telephone" ].ToString(),
				id_lieu = Convert.ToInt32( token[ "id_lieu" ] ),
				id_role = Convert.ToInt32( token[ "id_role" ] )
			};

			return utilisateur;
		}

		public static Utilisateur ToUtilisateur( JObject token )
		{
			Utilisateur utilisateur = new()
			{
				id_utilisateur = Convert.ToInt32( token[ "id_utilisateur" ] ),
				nom = token[ "nom" ].ToString(),
				prenom = token[ "prenom" ].ToString(),
				email = token[ "email" ].ToString(),
				password = token[ "password" ].ToString(),
				telephone = token[ "telephone" ].ToString(),
				id_lieu = Convert.ToInt32( token[ "id_lieu" ] ),
				id_role = Convert.ToInt32( token[ "id_role" ] )
			};

			return utilisateur;
		}

		public static string ToParameters( Utilisateur utilisateur, bool mustContainsId = false )
		{
			string includes = mustContainsId
								 ? String.Format( "id={0}&", utilisateur.id_utilisateur )
								 : String.Empty;

			return includes + String.Format(
				"nom={0}&prenom={1}&email={2}&password={3}&telephone={4}&id_lieu={5}&id_role={6}",
				Converter.NoSpaces( utilisateur.nom ),
				Converter.NoSpaces( utilisateur.prenom ),
				Converter.NoSpaces( utilisateur.email ),
				Converter.NoSpaces( utilisateur.password ),
				Converter.NoSpaces( utilisateur.telephone ),
				utilisateur.id_lieu.ToString(),
				utilisateur.id_role.ToString()
			);
		}

		public static string NoSpaces( string value )
		{
			return value.Contains( ' ' )
				  ? String.Join( "%20", value.Split( ' ' ) )
				  : value;
		}

		// == OTHER == //
		public static string ToDoubleFormat(string value)
		{
			const char TO_REPLACE = '.';
			const char REPLACER = ',';

			string[] valueSplitted = value.Split(TO_REPLACE);
			return string.Join(REPLACER, valueSplitted);
		}
	}
}
