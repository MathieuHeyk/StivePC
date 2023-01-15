using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Lieu
	{
		public int id_lieu { get; set; }
		public string numero { get; set; }
		public string type { get; set; }
		public string nom { get; set; }
		public string ville { get; set; }
		public string code_postal { get; set; }
		public string pays { get; set; }
	}
}
