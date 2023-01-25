using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	sealed class Session
	{
		private static Session? _instance;
		private Utilisateur _currentUser;
		private Role _userRole;
		private Lieu _userPlace;

		private Session( Utilisateur user )
		{
			_currentUser = user;

			_userRole = !String.IsNullOrEmpty( user.id_role.ToString() )
						 ? Database.GetRoleById( user.id_role )
						 : new Role();

			_userPlace = !String.IsNullOrEmpty( user.id_lieu.ToString() )
						  ? Database.GetLieuById( user.id_lieu )
						  : new Lieu();
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

		public Role GetUserRole()
		{
			return _userRole;
		}

		public Lieu GetUserPlace()
		{
			return _userPlace;
		}
	}
}
