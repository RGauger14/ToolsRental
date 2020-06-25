using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Schemas
{
	public static class RentalSchema
	{
		public static readonly string TableName = "Rental";

		public static readonly string ColumnRentalId = "RentalId";
		public static readonly string ColumnCustomerId = "CustomerId";
		public static readonly string ColumnDateRented = "DateRented";
		public static readonly string ColumnDateReturned = "DateReturned";

		public static readonly string Schema = $"{ColumnRentalId} int IDENTITY(1,1) PRIMARY KEY, " +
								$"{ColumnCustomerId} VARCHAR (70), " +
								$"{ColumnDateRented} Date, " +
								$"{ColumnDateReturned} Date";

		public static readonly string SchemaColoumNames = $"{ColumnRentalId}, {ColumnCustomerId}, {ColumnDateRented}, {ColumnDateReturned}";

		public static readonly List<string> RentalsSeed = new List<string>
		{
			// Rental Id, CustomerId, DateRented, DateReturned
			$"1, 1, '{GetDateRelativeToNow(-20)}', '{GetDateRelativeToNow(-1)}'",
			$"2, 2, '{GetDateRelativeToNow(0)}', null",
			$"3, 1, '{GetDateRelativeToNow(-5)}', '{GetDateRelativeToNow(-1)}'"
		};

		private static string GetDateRelativeToNow(int days)
        {
			var date = DateTime.Now.AddDays(days);
			return date.ToString("yyyy-MM-dd");
        }

		// TODO - define schema here i.e. Table/Column names and seed data.
		// then update Initializer.cs to use the definitions here
		// and update code anywhere else that has the hardcoded table/column names
	}
}