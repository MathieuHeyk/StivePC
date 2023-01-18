using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Session
	{
		private static Session? _instance;
		private Utilisateur _currentUser;

		private Session( Utilisateur user )
		{
			_currentUser = user;
		}

		public static Session GetInstance( Utilisateur? user = null )
		{
			_instance ??= new Session( user ?? new Utilisateur() );
			return _instance;
		}

		public Utilisateur GetUser()
		{
			return _currentUser;
		}
	}
}
