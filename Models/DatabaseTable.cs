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
		public dynamic? GetElementsById( int id, string url = "https://localhost:7201/" )
		{
			API api = API.GetInstance( url );
			string tableName	= GetTableName( this );
		//	string idName		= GetIdName( this ); // "idName" is always "id"
			string parameters = tableName + "/" + "Get" + tableName + "ById?id=" + id;
			JObject? result	= api.Query( parameters );

			if ( result == null )
			{
				return null;
			}

			return Converter.JSONToObject( result, this.GetType() );
		}

		public string GetTableName( object table )
		{
			return table.GetType().Name;
		}
	}
}