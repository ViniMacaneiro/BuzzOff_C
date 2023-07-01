using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Others;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Repository.DAO
{
    internal class DengueFocusDAO
    {
      
        public void Insert(DengueFocusModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DengueFocus (IdAddress, IdVisit, Type, IsEradicated) " +
                                  "VALUES (@IdAddress, @IdVisit, @Type, @IsEradicated)";

                cmd.Parameters.AddWithValue("@IdVisit", model.IdVisit);
                cmd.Parameters.AddWithValue("@IdAddress", model.IdAddress);
                cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                cmd.Parameters.AddWithValue("@IsEradicated", 0);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DengueFocusModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE DengueFocus SET " +
                    "IdAddress = @IdAddress, " +
                    "IdVisit =  @Idvisit" +
                    "Type = @Type, " +
                    "IsEradicated = @IsEradicated " +
                    "WHERE Id = @Id";


                cmd.Parameters.AddWithValue("@IdAddress", model.IdAddress);
                cmd.Parameters.AddWithValue("@IdVisit", model.IdVisit);
                cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                cmd.Parameters.AddWithValue("@IsEradicated",(bool)model.IsEradicated);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public DengueFocusModel GetOne(int id)
        {
            DengueFocusModel model = null;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdAddress, IdVisit, IdVisit, Type, IsEradicated  FROM DengueFocus WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new DengueFocusModel(
                            (int)reader["Id"],
                            (int)reader["IdAddress"],
                            (int)reader["IdVisit"],
                            (MyEnuns.FocusType)reader["Type"],
                            (bool)reader["IsEradicated"]
                        );
                    }
                }
            }
            return model;
        }

        public List<DengueFocusModel> GetAll()
        {
            var list = new List<DengueFocusModel>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdAddress, IdVisit, IdVisit, Type, IsEradicated  FROM DengueFocus";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DengueFocusModel model = new DengueFocusModel(
                            (int)reader["Id"],
                            (int)reader["IdAddress"],
                            (int)reader["IdVisit"],
                            (MyEnuns.FocusType)reader["Type"],
                            (bool)reader["IsEradicated"]
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
                cmd.CommandText = "DELETE FROM DengueFocus WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
