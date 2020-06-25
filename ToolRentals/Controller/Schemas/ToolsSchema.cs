using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Schemas
{
    public static class ToolsSchema
    {
        public static readonly string TableName = "Tools";

        public static readonly string ColumnToolId = "ToolId";
        public static readonly string ColumnToolName = "ToolName";
        public static readonly string ColumnToolBrand = "ToolBrand";
        public static readonly string ColumnToolActive = "ToolActive";
        
        public static readonly string Schema = $"{ColumnToolId} int IDENTITY(1,1) PRIMARY KEY, " +
                            $"{ColumnToolName} VARCHAR (70), " +
                            $"{ColumnToolBrand} VARCHAR (70), " +
                            $"{ColumnToolActive} BIT";

        public static readonly string SchemaColumnNames = $"{ColumnToolId}, {ColumnToolName}, {ColumnToolBrand}, {ColumnToolActive}";

        public static readonly List<string> ToolsSeed = new List<string>
        {
            // ToolId, ToolName, ToolBrand, ToolActive
            "1, 'Drill', 'Bosch', 1 ",
            "2, 'Screwdriver', 'Black & Decker', 1 ",
            "3, 'Hammer', 'Bosch', 1 ",
            "4, 'Tape measure', 'Stanley', 1 "
        };
    }
}