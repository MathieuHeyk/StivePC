﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StivePC.Models
{
	internal class DBTableManager
	{
		public dynamic? FindElementById( int id )
		{
			Type objectType	= GetType();
			string tableName	= objectType.Name;
			string parameters = string.Format( "{0}/Get{0}ById?id={1}", tableName, id );
			JObject? result	= API.GetQuery( parameters );

			return result != null											// condition
				  ? Converter.JSONToObject( result, objectType )	// if condition is true
				  : null;														// else
		}

		/** 
		 *	<remarks>Variable type must be "<c>object[]?</c>".
		 *	<example>For example:
		 *	<code>
		 *	Article articleManager = new Article();
		 *	object[]? listsOfArticles = articleManager.GetAllElements();
		 *	</code>
		 *	</example>
		 *	</remarks>
		 */
		public dynamic[]? FindAllElements()
		{
			Type objectType   = GetType();
			string tableName	= objectType.Name;
			string parameters = string.Format( "{0}/GetAll{0}", tableName );
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
				elements[ i ] = Converter.JSONToObject(jsonElement, objectType);
			}

			return elements;
		}

		public void AddElement( dynamic? element = null )
		{
			element ??= this;

			Type objectType   = element.GetType();
			string tableName  = objectType.Name;
			string parameters = string.Format( "{0}/Add{0}?", tableName );
			List<string> listParam = new();
			PropertyInfo[] properties = objectType.GetProperties();

			for ( int i = 1; i < properties.Length; i++ )
			{
				PropertyInfo property = properties[ i ];
				string propertyValue  = RmSpaces( property.GetValue( element ) );
				listParam.Add( property.Name + "=" + propertyValue );
			}

			parameters += string.Join( "&", listParam );
			API.PostQuery( parameters );
		}

		public void DeleteElement( dynamic? element = null )
		{
			element ??= this;

			string tableName  = element.GetType().Name;
			string idElement  = element.GetId().ToString();
			string parameters = string.Format( "{0}/Delete{0}?id={1}", tableName, idElement );

			API.DeleteQuery( parameters );
		}

		public dynamic EditElement( dynamic element, dynamic? element2 = null )
	// ToDo: Check if arguments are both of the same type
		{
			dynamic elt  = element2 is null ? this : element,
					  elt2 = element2 is null ? element : element2;

			string elementID = elt.GetId().ToString();
			Type objectType = elt.GetType();
			Type objectType2 = elt2.GetType();
			string tableName = objectType.Name;
			elt2.GetType().GetProperties()[ 0 ].SetValue( elt2, Convert.ToInt32( elementID ) );
			string parameters = string.Format( "{0}/Edit{0}?id={1}&", tableName, elementID );

			List<string> listParam = new();
			PropertyInfo[] properties = objectType2.GetProperties();

			for (int i = 1; i < properties.Length; i++)
			{
				PropertyInfo property = properties[ i ];
				string propertyValue = RmSpaces( property.GetValue( element ) );
				listParam.Add( property.Name + "=" + propertyValue );
			}

			parameters += string.Join( "&", listParam );

			API.UpdateQuery( parameters );
			return elt2;
		}

		public int GetId( dynamic? element = null )
		{
			element ??= this;
			Type objectType = element.GetType();
			PropertyInfo mainProperty = objectType.GetProperties()[ 0 ];
			object? propertyValue = mainProperty.GetValue( element );

			return Convert.ToInt32( propertyValue );
		}

		public static string RmSpaces( string str )
		{
			string[] splittedBySpace = str.Split( ' ' );

			return string.Join( "%20", splittedBySpace );
		}
	}
}