using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class DatabaseTable
	{
		public dynamic? GetElementById( int id )
		{
			string tableName	= GetTableName( this );
		//	string idName		= GetIdName( this ); // "idName" is always "id"
			string parameters = tableName + "/Get" + tableName + "ById?id=" + id;
			JObject? result	= API.Query( parameters );

			if ( result == null )
			{
				return null;
			}

			return Converter.JSONToObject( result, GetType() );
		}

		/** 
		 *	<remarks>Need casting result into the type.
		 *	<example>For example:
		 *	<code>
		 *	Article art = new Article();
		 *	object[]? listsOfArticles = art.GetAllElements();
		 *	</code>
		 *	</example>
		 *	</remarks>
		 *	<returns></returns>
		 */
		public dynamic[]? GetAllElements()
		{
		// ToDo: Move this block inside API object ?
			string tableName  = GetTableName( this );
			string parameters = tableName + "/GetAll" + tableName + "x";
			JArray? result 	= API.Query( parameters );

			if ( result == null )
			{
				return null;
			}

			int totalElements  = result.Count;
			dynamic[] elements = new dynamic[ totalElements ];

			for ( int i = 0; i < totalElements; i++ )
			{
				JObject jsonElement = ( JObject ) result[ i ];
				var element = Converter.JSONToObject( jsonElement, GetType() );

				if ( element == null )
				{
					return null;
				}

				elements[ i ] = element;
			}

			return elements;
		}

		public static string GetTableName( object table )
		{
			return table.GetType().Name;
		}
	}
}