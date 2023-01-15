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
				dynamic? propertyValue = property.GetValue( element );
				string	valueAsString = Converter.ForURL( propertyValue );
				parameters.Add( property.Name + "=" + valueAsString );
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

	// == Others functions ==
		public static Type? GetFullTypeName( string targetType )
		{
			return Type.GetType( "StivePC.Models." + targetType );
		}
	}
}
