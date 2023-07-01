using BuzzOff_Pre_Alpha.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BuzzOff_Pre_Alpha.Repository
{
    public class CreateDB
    {
        SqlConnection conn;

        public CreateDB()
        {            
            CreateDatabase();
        }

        bool DatabaseExists()
        {
            using (var conn = new SqlConnection(DBConnect.Create()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM SYS.DATABASES WHERE NAME = @name";
                cmd.Parameters.AddWithValue("@name", DBConnect.initialCatalog);
                var count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        private void CreateDatabase()
        {
            if (!DatabaseExists())
            {
                using (var conn = new SqlConnection(DBConnect.Create()))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = $"CREATE DATABASE {DBConnect.initialCatalog}";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Banco de dados criado.");
                }
            }

            CreateTables();
        }

        bool TableExists(string tableName)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM SYS.TABLES WHERE NAME = @tableName";
                cmd.Parameters.AddWithValue("@tableName", tableName);
                var count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        private void CreateTables()
        {
            List<string> tables = new List<string> { "Users", "Addresses", "Denunciations", "Visits",  "Solicitations", "DengueFocus"};

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                foreach (var table in tables)
                {
                    if (!TableExists(table))
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = TableScript(table);
                            cmd.ExecuteNonQuery();

                            Console.WriteLine("Tabela criada: " + table);
                        }
                    }
                }
            }
        }

        private string TableScript(string tableName)
        {
            switch (tableName)
            {
                case "Addresses":
                    return @"CREATE TABLE Addresses (
                                ID INT PRIMARY KEY IDENTITY,
                                Neighborhood NVARCHAR(100) NOT NULL,
                                Street NVARCHAR(100) NOT NULL,
                                Number NVARCHAR(10) NOT NULL,
                                Reference NVARCHAR(200) NOT NULL,
                                Latitude NVARCHAR(100) NOT NULL,
                                Longitude NVARCHAR(100) NOT NULL,
                                
                            )";

                case "DengueFocus":
                    return @"CREATE TABLE DengueFocus (
                                ID INT PRIMARY KEY IDENTITY,
                                IDAddress INT NOT NULL,
                                IDVisit int not null,
                                Type INT NOT NULL,
                                Priority INT NOT NULL,
                                IsEradicated BIT NOT NULL,
                                FOREIGN KEY (IDAddress) REFERENCES Addresses(ID),
                                FOREIGN KEY (IDVisit) REFERENCES Visits(ID)
                            )";

                case "Denunciations":
                    return @"CREATE TABLE Denunciations (
                                ID INT PRIMARY KEY IDENTITY,
                                IDInformer INT NOT NULL,                                
                                IDAddress INT NOT NULL,
                                DataDenunciation DATETIME NOT NULL,                                
                                Media VARBINARY(MAX),
                                IsAnswered BIT NOT NULL,
                                FOREIGN KEY (IDInformer) REFERENCES Users(ID),                                
                                FOREIGN KEY (IDAddress) REFERENCES Addresses(ID)
                            )";

                case "Visits":
                    return @"CREATE TABLE Visits ( 
                                ID INT PRIMARY KEY IDENTITY, 
                                IDAgent int not null, 
                                IDDenunciation int not null, 
                                DataVisit DATETIME NOT NULL, 
                                Assessment nvarchar(200) not null,
                                FOREIGN KEY (IDAgent) REFERENCES Users(ID),                                
                                FOREIGN KEY (IDDenunciation) REFERENCES Denunciations(ID))"

;

                case "Solicitations":
                    return @"CREATE TABLE Solicitations (
                                ID INT PRIMARY KEY IDENTITY,
                                IDVisit INT NOT NULL,
                                Priority INT NOT NULL,
                                Description NVARCHAR(MAX) NOT NULL,
                                FOREIGN KEY (IDVisit) REFERENCES Visits(ID)
                            )";

                case "Users":
                    return @"CREATE TABLE Users (
                                ID INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(150) NOT NULL,
                                Email NVARCHAR(200) NOT NULL,
                                CPF NVARCHAR(11) NOT NULL,
                                Password NVARCHAR(150) NOT NULL,
                                AccessLevel INT NOT NULL
                            )";

                default:
                    throw new ArgumentException($"A tabela: {tableName} não possui script.");
            }
        }
    }
}
