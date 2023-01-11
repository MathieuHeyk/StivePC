using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StivePC.Models
{
	internal class Converter
	{
		public static dynamic? JSONToObject( JObject data, Type objectType )
		{
			Type objType = GetFullTypeName( objectType );
			dynamic? obj = Activator.CreateInstance( objType );

			if ( obj == null )
			{
				return null;
			}

			PropertyInfo[] propertyInfos = objType.GetProperties();

			foreach ( PropertyInfo propertyInfo in propertyInfos )
			{
				string propertyName  = propertyInfo.Name;
				var	 propertyValue = data.GetValue( propertyName );
				Type   propertyType	= propertyInfo.PropertyType;

				var value = Convert.ChangeType( propertyValue, propertyType );
				propertyInfo.SetValue( obj, value );
			}

			return obj;
		}

		public static Type GetFullTypeName( Type type )
		{
			string assemblyName = type.AssemblyQualifiedName ?? type.Name;
			Type?  fullTypeName = Type.GetType( assemblyName );

			return fullTypeName ?? type;
		}
	}
}
