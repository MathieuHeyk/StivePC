using System;
using System.Collections.Generic;
using System.Reflection;

namespace StivePC.Models
{
	internal class Database
	{
		public static void Add( Object elementToAdd )
		{
			Type objectType			 = elementToAdd.GetType();
			List<dynamic> parameters = new();

			foreach ( PropertyInfo property in objectType.GetProperties()[ 1.. ] )
			{
				dynamic? propertyValue = property.GetValue( elementToAdd );
				string	valueAsString = Converter.ForURL( propertyValue );
				parameters.Add( property.Name + "=" + valueAsString );
			}

			string url = String.Format( "{0}/Add{0}?", objectType.Name )
						  + String.Join( '&', parameters );

			API.PostQuery( url );
		}
	}
}
