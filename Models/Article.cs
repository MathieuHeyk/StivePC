using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Article
	{
		public int id { get; set; }

		public string nom { get; set; }

		public double prix_unitaire { get; set; }

		public double prix_carton { get; set; }

		public int annee { get; set; }

		public int id_famille { get; set; }

		public int id_fournisseur { get; set; }
	}
}
