using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class LigneCommande
	{
		public int id_ligne_commande { get; set; }

		public int id_article { get; set; }

		public int quantite { get; set; }

		public int num_commande { get; set; }
	}
}
