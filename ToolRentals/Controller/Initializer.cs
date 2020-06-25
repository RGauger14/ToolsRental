using Controller.Schemas;
using SQLConnection;
using System;
using System.Collections.Generic;

namespace Controller
{
	public static class Initializer
	{
		#region Member Variables

		private static SQL _sql = new SQL();

		#endregion Member Variables

		#region Create Database Schema

		public static void CreateDatabaseSchema()
		{
			// call the SQL CreateDatabase metho to create the databse in SQL.
			_sql.CreateDatabase();
			CreateDatabaseTables();
			SeedDatabaseTables();
		}

		#endregion Create Database Schema

		#region Create Database Tables

		private static void CreateDatabaseTables()
		{
			CreateToolTable();
			CreateCustomerTable();
			CreateRentalTable();
			CreateRentalItemTable();
		}

		private static void CreateRentalItemTable()
		{
			// Call CreateDatabaseTable method and pass the table name and schema
			_sql.CreateDatabaseTable(RentalItemSchema.TableName, RentalItemSchema.Schema);
		}

		private static void CreateRentalTable()
		{
			// Call CreateDatabaseTable method and pass the table name and schema
			_sql.CreateDatabaseTable(RentalSchema.TableName, RentalSchema.Schema);
		}

		private static void CreateCustomerTable()
		{
			// Call the CreateDatabaseTable method pass the name and schema
			_sql.CreateDatabaseTable(CustomerSchema.TableName, CustomerSchema.Schema);
		}

		private static void CreateToolTable()
		{
			// Call CreateDatabaseTable method and pass the table name and schema
			_sql.CreateDatabaseTable(ToolsSchema.TableName, ToolsSchema.Schema);
		}

		#endregion Create Database Tables

		#region Seed Database Tables

		private static void SeedDatabaseTables()
		{
			// Use profiling in this method and improve the performance by making sure method calls to SeedMovieTable, SeedCustomerTable ect.
			// Will not be called if tables in SQL already contains dummy data

			SeedToolsTable();
			SeedCustomerTable();
			SeedRentalTable();
			SeedRentalItemTable();
		}

		private static void SeedRentalItemTable()
		{
			// Loop thorugh the list of rentals and push that data on rental at a time
			foreach (var rentalItems in RentalItemSchema.RentalItemsSeed)
			{
				_sql.InsertRecord(RentalItemSchema.TableName, RentalItemSchema.SchemaColumnNames, rentalItems);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private static void SeedRentalTable()
		{
			// Loop thorugh the list of rentals and push that data on rental at a time
			foreach (var rental in RentalSchema.RentalsSeed)
			{
				// column names must match the order of the seed data
				_sql.InsertRecord(RentalSchema.TableName, RentalSchema.SchemaColoumNames, rental);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private static void SeedCustomerTable()
		{
			// loop through the list of tools and push the data one tool at a time
			foreach (var customer in CustomerSchema.CustomersSeed)
			{
				// column names must match the order of the seed data
				_sql.InsertRecord(CustomerSchema.TableName, CustomerSchema.SchemaColumnNames, customer);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private static void SeedToolsTable()
		{
			// loop thorugh the list of tools and push the data one tool at a time
			foreach (var tool in ToolsSchema.ToolsSeed)
			{
				// column names must match the order of the seed data
				_sql.InsertRecord(ToolsSchema.TableName, ToolsSchema.SchemaColumnNames, tool);
			}
		}
	}
}

#endregion Seed Database Tables