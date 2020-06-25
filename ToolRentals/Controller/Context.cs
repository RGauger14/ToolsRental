using SQLConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class Context
    {
        #region Member Variables

        static SQL _sql = new SQL();

        #endregion

        #region Constructors

        #endregion

        #region Accessors

        /// <summary>
        /// This method will return all records from the specified database tbale.
        /// </summary>
        /// <param name="tableName">The database tbale name where the records will come from.</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName)
        {
            return _sql.GetDataTable(tableName);
        }

        /// <summary>
        /// This method will return the records based on the sepcified SQL query.
        /// </summary>
        /// <param name="sqlQuery">The SELECT query that will be used to filter the records.</param>
        /// <param name="TableName">The database table name where the records will come from</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sqlQuery, string tableName)
        {
            return _sql.GetDataTable(sqlQuery, tableName);
        }

        /// <summary>
        /// This mothed will return the records based on the specified SQL query.
        /// </summary>
        /// <param name="sqlQuery">the SELECT query that will be used to filter the records</param>
        /// <param name="tableName">The databse table name where the records will come from</param>
        /// <param name="isReadOnly">To indicate whether the returned database tabel is updated or not</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sqlQuery, string tableName, bool isReadOnly)
        {
            return _sql.GetDataTable(sqlQuery, tableName, isReadOnly);
        }
    
        #endregion

        #region Mutators

        public static void SaveDatabaseTable(DataTable table)
        {
            _sql.SaveDatabaseTable(table);
        }

        public static int InsertParentTable(string tableName, string columnNames, string columnValues)
        {
            return _sql.InsertParentRecord(tableName, columnNames, columnValues);
        }

        public static void DeleteRecord(string tableName, string pkName, string pkId)
        {
            _sql.DeleteRecord(tableName, pkName, pkId);
        }


        #endregion

        #region Helper Methods

        #endregion
    }
}

