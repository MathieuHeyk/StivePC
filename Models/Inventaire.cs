using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Inventaire
	{
		public int id_inventaire { get; set; }

		public int id_article { get; set; }

		public int quantite { get; set; }

		public string date { get; set; }

		public int id_utilisateur { get; set; }
	}
}
