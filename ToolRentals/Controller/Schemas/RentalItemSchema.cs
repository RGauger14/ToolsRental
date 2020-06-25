using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Schemas
{
	public static class RentalItemSchema
	{
		public static readonly string TableName = "RentalItems";

		public static readonly string ColumnRentalItemId = "RentalItemId";
		public static readonly string ColumnRentalId = "RentalId";
		public static readonly string ColumnToolId = "ToolId";

		public static readonly string Schema = $"{ColumnRentalItemId} int IDENTITY(1,1) PRIMARY KEY, " +
								$"{ColumnRentalId} VARCHAR(70), " +
								$"{ColumnToolId} VARCHAR(70)";

		public static readonly string SchemaColumnNames = $"{ColumnRentalItemId}, {ColumnRentalId}, {ColumnToolId}";

		public static readonly List<string> RentalItemsSeed = new List<string>
		{
			// RentalItemId, RentalId, ToolId
			"1,1,1",
			"2,1,2",
			"3,2,3",
			"4,3,1",
			"5,3,2",
			"6,3,3"
		};


		// TODO - define schema here i.e. Table/Column names and seed data.
		// then update Initializer.cs to use the definitions here
		// and update code anywhere else that has the hardcoded table/column names
	}
}