using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class API_Parser
	{
		public static Object? GetClass( string url )
		{
			string pattern = @"\/([A-Z])\w+";
			Regex regex = new( pattern );
			MatchCollection matchCollection = regex.Matches( url );
			string className = matchCollection[ 0 ].Value[ 1.. ];
			Type? t = Type.GetType( "StivePC.Models." + className );

			return t != null ? Activator.CreateInstance( t ) : null;
		}
	}
}
