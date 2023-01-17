using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Fournisseur
	{
		public int id { get; set; }

		public string nom { get; set; }

		public string telephone { get; set; }

		public string email { get; set; }

		public int id_lieu { get; set; }
	}
}
