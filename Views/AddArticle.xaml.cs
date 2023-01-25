using StivePC.Models;
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
using System.Windows.Shapes;

namespace StivePC.Views
{
    /// <summary>
    /// Logique d'interaction pour AddArticle.xaml
    /// </summary>
    public partial class AddArticle : Window
    {
        public AddArticle()
        {
            List<Famille> types = Database.GetAllFamille();
            List<Fournisseur> providers = Database.GetAllFournisseur();
			List<Article> articles = Database.GetAllArticle();

			InitializeComponent();
            foreach (Famille type in types)
            {
               Types_Combo.Items.Add(type.libelle); // A partir du libelle, retrouver l'id dans {types}
            }

            foreach (Fournisseur provider in providers)
            {
                Providers_Combo.Items.Add(provider.nom); // Pareil que pour les familles
            }
        }

		private void Reset_Btn_Click(object sender, RoutedEventArgs e)
		{
            Name_Txt.Text = string.Empty;
            PriceUnit_Txt.Text = string.Empty;
            PriceBox_Txt.Text = string.Empty;
            Year_Txt.Text = string.Empty;
            Types_Combo.SelectedIndex = -1;
            Providers_Combo.SelectedIndex = -1;

            Name_Txt.Focus();
		}

		private void Validate_Btn_Click(object sender, RoutedEventArgs e)
		{
            if (AnyFieldIsEmpty())
            {
                return;
            }

            // Correct double format
            string priceUnit = Converter.ToDoubleFormat(PriceUnit_Txt.Text);
            string priceBox = Converter.ToDoubleFormat(PriceBox_Txt.Text);


            List<Famille> types = Database.GetAllFamille();
            List<Fournisseur> providers = Database.GetAllFournisseur();

            Article newArticle = new();
            newArticle.nom = Name_Txt.Text;
            newArticle.annee = Convert.ToInt32(Year_Txt.Text);
            newArticle.prix_unitaire = Convert.ToDouble(priceUnit);
            newArticle.prix_carton = Convert.ToDouble(priceBox);

			foreach (Fournisseur provider in providers)
			{
				if (provider.nom == Providers_Combo.Text)
				{
					newArticle.id_fournisseur = provider.id;
                    break;
				}
			}

            foreach (Famille type in types)
            {
                if (type.libelle == Types_Combo.Text)
                {
                    newArticle.id_famille = type.id_famille;
                    break;
                }
            }

            Database.AddArticle(newArticle);
            // Ajouter un message de réussite d'ajout
		}

        private bool AnyFieldIsEmpty()
        {
            const bool CONTAINS_EMPTY_FIELD = true;
            
            string[] fields = {
                Name_Txt.Text,
                PriceUnit_Txt.Text,
                PriceBox_Txt.Text,
                Year_Txt.Text,
                Types_Combo.Text,
                Providers_Combo.Text
            };

            foreach (string field in fields)
            {
                if (field == "")
                {
                    return CONTAINS_EMPTY_FIELD;
                }
            }

            return !CONTAINS_EMPTY_FIELD;
        }
	}
}
