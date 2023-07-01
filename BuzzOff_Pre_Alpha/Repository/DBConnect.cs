using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Repository
{
    internal class DBConnect
    {


        public static string initialCatalog = "BuzzOffDB";
        static string dataSource = @"BUE0102D006\SQLEXPRESS";

        static string userID = "Sa";
        static string password = "Senac@2023";


        public static string Connect()
        {
            if (Environment.MachineName == "X")
            {
                dataSource = @"localhost\SQLSERVER";
                password = "sa";
            }

            return
                $"Data Source={dataSource};" +
                $"Initial Catalog={initialCatalog};" +
                $"User ID={userID};" +
                $"Password={password};";

        }
        public static string Create()
        {
            if (Environment.MachineName == "X")
            {
                dataSource = @"localhost\SQLSERVER";
                password = "sa";
            }

            return
                $"Data Source={dataSource};" +
                $"User ID={userID};" +
                $"Password={password};";
        }
    }

}
