using StivePC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StivePC.Views
{
	/// <summary>
	/// Logique d'interaction pour Dashboard.xaml
	/// </summary>
	public partial class Dashboard : Window
	{
		public Dashboard()
		{
			List<Article> articles = Database.GetAllArticle();
			List<ArticleSummary> articlesSummary = new();

			foreach ( Article article in articles )
			{
				ArticleSummary summary = new( article );
				articlesSummary.Add( summary );
			}

			InitializeComponent();

			PrintSession();
			Articles_Grid.ItemsSource = articlesSummary;

		// Printing users (non clients)
		/*
			List<Utilisateur> employes = Database.GetAllUtilisateur();
			List<UserSummary> users = new();

			foreach ( Utilisateur user in employes )
			{
				users.Add( user.ToShorted() );
			}

			UsersLs.ItemsSource = users;
		*/
		}

		public void PrintSession()
		{
			Session session = Session.GetInstance();
			Utilisateur currentUser = session.GetUser();

			UserName_Lbl.Content = currentUser.ToString();
		}
	}
}
