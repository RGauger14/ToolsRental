using System;
using System.Windows.Forms;

namespace ToolRentals
{
    static class Program
    {
        ///Summary
        ///the main entery point for the application
        ///
        [STAThread]
        static void Main()
        {
            // Calls the Initializer to create the database schema and populate table with dummy data
            Controller.Initializer.CreateDatabaseSchema();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());

        }
    }
}
