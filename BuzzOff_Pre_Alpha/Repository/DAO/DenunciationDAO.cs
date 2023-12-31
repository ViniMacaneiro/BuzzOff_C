﻿using BuzzOff_Pre_Alpha.Model;
using System.Data.SqlClient;

namespace BuzzOff_Pre_Alpha.Repository.DAO
{
    internal class DenunciationDAO
    {
        byte[] midia = new byte[10];
       
        public void Insert(DenunciationModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Denunciations (IdInformer, IdAddress, DataDenunciation, Media, IsAnswered) " +
                                  "VALUES (@IdInformer, @IdAddress, @DataDenunciation, @Media, @IsAnswered)";
                cmd.Parameters.AddWithValue("@IdInformer", model.IdInformer);                
                cmd.Parameters.AddWithValue("@IdAddress", model.IdAddress);
                cmd.Parameters.AddWithValue("@DataDenunciation", model.DataDenunciation);                
                cmd.Parameters.AddWithValue("@Media", midia); //Alterado de byte[] para null em virtude erro envolventdo o Banco. Falar com o professor para usar o Blob.
                cmd.Parameters.AddWithValue("@IsAnswered", model.IsAnswered);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DenunciationModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Denunciations SET " +
                    "IdInformer = @IdInformer, " +
                    "IdAddress = @IdAddress," +
                    "DataDenunciation = @DataDenunciation, " +                    
                    "Media = @Media, " +
                    "IsAnswered = @IsAnswered" +
                    " WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@IdInformer", model.IdInformer);                
                cmd.Parameters.AddWithValue("@IdAddress", model.IdAddress);
                cmd.Parameters.AddWithValue("@DataDenunciation", model.DataDenunciation);                
                cmd.Parameters.AddWithValue("@Media", midia);  //Alterado de byte[] para null em virtude erro envolventdo o Banco. Falar com o professor para usar o Blob.
                cmd.Parameters.AddWithValue("@IsAnswered", model.IsAnswered);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public DenunciationModel GetOne(int id)
        {
            DenunciationModel model = null;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, IsAnswered FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new DenunciationModel(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],                            
                            (int)reader["IdAddress"],
                            (DateTime)reader["DataDenunciation"],                            
                            (byte[])reader["Media"],
                            (bool)reader["IsAnswered"]
                        );
                    }
                }
            }
            return model;
        }

        public List<DenunciationModel> GetByInformerId(int id)
        {
            var list = new List<DenunciationModel>();           

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, IsAnswered FROM Denunciations WHERE IdInformer = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DenunciationModel model = new DenunciationModel(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],                            
                            (int)reader["IdAddress"],
                            (DateTime)reader["DataDenunciation"],                            
                            (byte[])reader["Media"],
                            (bool)reader["IsAnswered"]
                        );
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        public List<DenunciationModel> GetByInformerIdAndIsAnswered(int id, bool b)
        {
            var list = new List<DenunciationModel>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, IsAnswered FROM Denunciations WHERE IdInformer = @Id and IsAnswered = @B";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@B", b);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DenunciationModel model = new DenunciationModel(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],                            
                            (int)reader["IdAddress"],
                            (DateTime)reader["DataDenunciation"],                            
                            (byte[])reader["Media"],
                            (bool)reader["IsAnswered"]
                        );
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public List<DenunciationModel> GetAll()
        {
            var list = new List<DenunciationModel>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, IsAnswered FROM Denunciations";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DenunciationModel model = new DenunciationModel(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],  
                            (int)reader["IdAddress"],
                            (DateTime)reader["DataDenunciation"],                            
                            (byte[])reader["Media"],
                            (bool)reader["IsAnswered"]
                        );

                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public (List<DenunciationModel>, List<AddressModel>) JoinWithAddress()
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var sql = @"SELECT d.*, a.*
                    FROM Denunciations d
                    INNER JOIN Addresses a ON d.IDAddress = a.ID";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    var denunciations = new List<DenunciationModel>();
                    var addresses = new List<AddressModel>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var address = new AddressModel(
                                (int)reader["IDAddress"],
                                (string)reader["Neighborhood"],
                                (string)reader["Street"],
                                (string)reader["Number"],
                                (string)reader["Reference"],
                                (string)reader["Latitude"],
                                (string)reader["Longitude"]                                
                            );

                            addresses.Add(address);

                            var denunciation = new DenunciationModel(
                            
                                (int)reader["ID"],
                                (int)reader["IDInformer"],                                
                                (int)reader["IDAddress"],
                                (DateTime)reader["DataDenunciation"],                                
                                (byte[])reader["Media"],
                                (bool)reader["IsAnswered"]                                
                            );

                            denunciations.Add(denunciation);
                        }
                    }

                    return (denunciations, addresses);
                }
            }
        }

        public void Delete2()
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Denunciations WHERE IDInformer = @IDInformer";
                cmd.Parameters.AddWithValue("@IDInformer", LoggedUser.loggedUser.Id);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
