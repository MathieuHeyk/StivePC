using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Utilisateur
	{
		public int id_utilisateur { get; set; }

		public string nom { get; set; }

		public string prenom { get; set; }

		public string email { get; set; }

		public string password { get; set; }

		public string telephone { get; set; }

		public int id_lieu { get; set; }

		public int id_role { get; set; }


		public override string ToString()
		{
			string role = Database.GetRoleById( id_role ).libelle;

			return String.Format(
				"[{0}] {1} {2}",
				role,
				prenom,
				nom
			);
		}

		public UserSummary ToShorted()
		{
			return new UserSummary( this );
		}
	}
}
