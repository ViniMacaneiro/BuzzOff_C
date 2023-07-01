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
    internal class SolicitationDAO
    {        
        public void Insert(SolicitationModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Solicitations (IdDenunciation, Priority, Description) " +
                                  "VALUES (@IdDenunciation, @Priority, @Description)";
                cmd.Parameters.AddWithValue("@IdDenunciation", model.IdDenunciation);
                cmd.Parameters.AddWithValue("@Priority", (int)model.Priority);
                cmd.Parameters.AddWithValue("@Description", model.Description);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(SolicitationModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Solicitations SET IdDenunciation = @IdDenunciation, " +
                                  "Priority = @Priority, Description = @Description WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@IdDenunciation", model.IdDenunciation);
                cmd.Parameters.AddWithValue("@Priority", (int)model.Priority);
                cmd.Parameters.AddWithValue("@Description", model.Description);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public SolicitationModel GetOne(int id)
        {
            SolicitationModel model = null;

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdDenunciation, Priority, Description FROM Solicitations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new SolicitationModel(
                            (int)reader["Id"],
                            (int)reader["IdDenunciation"],
                            (MyEnuns.Priority)reader["Priority"],
                            (string)reader["Description"]
                        );
                    }
                }
            }
            return model;
        }

        public List<SolicitationModel> GetAll()
        {
            var list = new List<SolicitationModel>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdDenunciation, Priority, Description FROM Solicitations";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SolicitationModel solicitation = new SolicitationModel(
                            (int)reader["Id"],
                            (int)reader["IdDenunciation"],
                            (MyEnuns.Priority)reader["Priority"],
                            (string)reader["Description"]
                        );

                        list.Add(solicitation);
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
                cmd.CommandText = "DELETE FROM Solicitations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
