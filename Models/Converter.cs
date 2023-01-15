using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace StivePC.Models
{
	internal class Converter
	{
		public static dynamic? JSONToObject( JObject data, Type targetType )
		{
			dynamic? obj = Activator.CreateInstance( targetType );

			if ( obj == null )
			{
				return null;
			}

			foreach ( PropertyInfo propertyInfo in targetType.GetProperties() )
			{
				var propertyValue = data.GetValue( propertyInfo.Name );
				var finalValue 	= Convert.ChangeType( propertyValue, propertyInfo.PropertyType );
				propertyInfo.SetValue( obj, finalValue );
			}

			return obj;
		}

		public static string ForURL( object? data )
		{
			string valueAsString = data?.ToString() ?? "";

			if ( !valueAsString.Contains( ' ' ) )
			{
				return valueAsString;
			}

			return String.Join( "%20", valueAsString.Split( ' ' ) );
		}

		public static Type GetFullTypeName( Type type )
		{
			string assemblyName = type.AssemblyQualifiedName ?? type.Name;

			return Type.GetType( assemblyName ) ?? type;
		}
	}
}
