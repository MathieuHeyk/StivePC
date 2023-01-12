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
			JObject? result	= API.GetQuery( parameters );

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
			JArray? result 	= API.GetQuery( parameters );

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

		public void AddElement( dynamic? element = null )
		{
			if ( element == null )
			{
				element = this;
			}

			string tableName = GetTableName( element );
			string parameters = tableName + "/Add" + tableName + "?";
			List<string> listParam = new();
			PropertyInfo[] properties = element.GetType().GetProperties();

			for ( int i = 1; i < properties.Length; i++ )
			{
				PropertyInfo property = properties[ i ];
				string propertyValue = RmSpaces( property.GetValue( element ) );
				listParam.Add( property.Name + "=" + propertyValue );
			}

			parameters += string.Join( "&", listParam );
			API.PostQuery( parameters );
		}

		public static string GetTableName( object table )
		{
			return table.GetType().Name;
		}

		public static string RmSpaces( string value )
		{
			string result = "";

			foreach ( char c in value )
			{
				result += c != ' ' ? c : "%20";
			}

			return result;
		}
	}
}