using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StivePC.Models
{
	internal class Database
	{
	/**
	 * <summary>Add an element to the database (using the API)</summary>
	 * <param name="element">The element to add</param>
	 */
		public static void Add( Object element )
		{
			Type objectType			 = element.GetType();
			List<dynamic> parameters = new();

		// Loop starts with the second property (no need of ID)
			foreach ( PropertyInfo property in objectType.GetProperties()[ 1.. ] )
			{
				string propertyValue = Converter.ForURL( property.GetValue( element ) );
				parameters.Add( property.Name + "=" + propertyValue );
			}

			string url = String.Format( "{0}/Add{0}?", objectType.Name )
						  + String.Join( '&', parameters );

			API.PostQuery( url );
		}

	/**
	 * <summary>Find a element of the specified
	 * <paramref name="type" /> by its <paramref name="id" />
	 * </summary>
	 * <param name="type">The type of the element</param>
	 * <param name="id">The ID of the element</param>
	 */
		public static dynamic? GetById( string type, uint id )
		{
			string typeName  = Char.ToUpper( type[ 0 ] ) + type[ 1.. ];
			Type? targetType = GetFullTypeName( typeName );

			if ( targetType is null )
			{
				return null;
			}

			string url  	 = String.Format( "{0}/Get{0}ById?id={1}", typeName, id.ToString() );
			JObject? result = API.GetQuery( url );

			return result != null
				  ? Converter.JSONToObject( result, targetType )
				  : null;
		}

	/**
	 * <returns>Array of all the elements from a specified
	 * <paramref name="type" />
	 * </returns>
	 */
		public static dynamic? GetAll( string type )
		{
			string typeName  = Char.ToUpper( type[ 0 ] ) + type[ 1.. ];
			Type? targetType = GetFullTypeName( typeName );
			string url  	  = String.Format( "{0}/GetAll{0}", typeName );
			JArray? result   = API.GetQuery( url );

			if ( result is null || targetType is null )
			{
				return null;
			}

			object[] elements = new object[ result.Count ];
			foreach ( JToken token in result )
			{
				int idToken = result.IndexOf( token );
				var element = Converter.JSONToObject( ( JObject ) token, targetType );
				elements[ idToken ] = element;
			}

			return elements;
		}

		/**
		 * <summary>
		 * Change the values of an <paramref name="element" /> into the database
		 * </summary>
		 * <param name="element">Element containing new value and the ID of old one</param>
		 */
		public static void Update( object element )
		{
			Type type = element.GetType();
			List<string> parameters = new()
			{
				"id=" + type.GetProperties()[ 0 ].GetValue( element )
			};

			foreach ( PropertyInfo property in type.GetProperties()[ 1.. ] )
			{
				string propertyValue = Converter.ForURL( property.GetValue( element ) );
				parameters.Add( property.Name + '=' + propertyValue );
			}

			string url = String.Format( "{0}/Edit{0}?", type.Name )
						  + String.Join( "&", parameters );

			API.UpdateQuery( url );
		}

	// == Others functions ==
		public static Type? GetFullTypeName( string targetType )
		{
			return Type.GetType( "StivePC.Models." + targetType );
		}
	}
}
