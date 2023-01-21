using System.Collections.Generic;

namespace StivePC.Models
{
   struct ArticleSummary
   {
      public string Nom { get; set; }
      public string Famille { get; set; }
      public int Annee { get; set; }
      public string Fournisseur { get; set; }
      public int Quantite { get; set; }

      public ArticleSummary(Article article)
      {
			Nom = article.nom;
			Famille = Database.GetFamilleById(article.id).libelle;
         Fournisseur = Database.GetFournisseurById(article.id_fournisseur).nom;
			Annee = article.annee;
			Quantite = 0;

         foreach (Stock stock in Database.GetAllStock())
         {
            if (stock.id_article == article.id)
            {
               Quantite += stock.quantite;
            }
         }
      }
   }
}
