using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Schemas
{
	public static class CustomerSchema
	{
		public static readonly string TableName = "Customer";

		public static readonly string ColumnCustomerId = "CustomerId";
		public static readonly string ColumnCustomerName = "CustomerName";
		public static readonly string ColumnCustomerPhone = "CustomerPhone";

		public static readonly string Schema = $"{ColumnCustomerId} int IDENTITY(1,1) PRIMARY KEY, " +
							$"{ColumnCustomerName} VARCHAR(70), " +
							$"{ColumnCustomerPhone} VARCHAR (20)";

		public static readonly string SchemaColumnNames = $"{ColumnCustomerId}, {ColumnCustomerName}, {ColumnCustomerPhone}";

		public static readonly List<string> CustomersSeed = new List<string>
		{
            // CustomerId, CustomerName, Customer Phone
            "1, 'Barry Jones', '0411333778'",
			"2, 'Susan Bond', '0412321123'",
			"3, 'Neville Longbottom', '0450987789'"
		};
	}
}