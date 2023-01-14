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
	}
}
