﻿using StivePC.Models;
using StivePC.Views;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StivePC
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

	// ToDo: email format validator
	// ToDo: auto-hidding password

		private void Connection_Btn_Click(object sender, RoutedEventArgs e)
		{
			Error_login.Visibility = Visibility.Hidden;

			List<Utilisateur> employes = Database.GetAllEmployes();

			string email = Email_Txt.Text;
			string password = Password_Txt.Text;

			foreach ( Utilisateur employe in employes )
			{
				if ( employe.email == email && employe.password == password )
				{
					Session session = Session.GetInstance( employe );
					Dashboard dashboard = new();

					dashboard.Show();
					Close();
				}
			}

			Error_login.Visibility = Visibility.Visible;
		}
	}
}
