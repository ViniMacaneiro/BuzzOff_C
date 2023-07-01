using BuzzOff_Pre_Alpha.Model;
using System.Data.SqlClient;
using BuzzOff_Pre_Alpha.Authentications.Cryptography;
using BuzzOff_Pre_Alpha.Others;

namespace BuzzOff_Pre_Alpha.Repository.DAO
{
    internal class UserDAO
    {
        public void Insert(UserModel model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO Users (NAME, EMAIL, PASSWORD, CPF, ACCESSLEVEL)" +
                    "VALUES (@NAME, @EMAIL, @PASSWORD, @CPF, @ACCESSLEVEL)";
                cmd.Parameters.AddWithValue("@NAME", model.Name);
                cmd.Parameters.AddWithValue("@EMAIL", model.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(model.Password));
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@ACCESSLEVEL", model.AccessLevel);

                cmd.ExecuteNonQuery();
            }
        }

       
        public void Update(UserModel model) 
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "UPDATE Users SET " +
                    "NAME = @NAME," +
                    "EMAIL = @EMAIL," +
                    "PASSWORD = @PASSWORD," +
                    "CPF = @CPF, " +
                    "ACCESSLEVEL = @ACCESSLEVEL " +
                    "WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@NAME", model.Name);
                cmd.Parameters.AddWithValue("@EMAIL", model.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(model.Password));
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@ACCESSLEVEL", model.AccessLevel);

                cmd.ExecuteNonQuery();
            }
        }
        

        public UserModel GetOne(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users WHERE ID = @ID";
                cmd.Parameters.AddWithValue ("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {                        
                        UserModel model = new UserModel(                            
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            (MyEnuns.Access) reader.GetInt32(4),
                            reader.GetInt32(0));
                        return model;
                    }
                }
                return null;
            }
        }
        
        public List<UserModel> GetAll()
        {
            var list = new List<UserModel>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users";

                using (var reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        UserModel model = new UserModel(                            
                            reader.GetString(1),
                            reader.GetString(2),                            
                            reader.GetString(3),
                            (MyEnuns.Access)reader.GetInt32(4),
                            reader.GetInt32(0));

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
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM USERS WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePassword(string password)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "UPDATE Users SET " +
                    "PASSWORD = @PASSWORD " +
                    "WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(password));
                cmd.Parameters.AddWithValue("@Id", LoggedUser.loggedUser.Id);


                cmd.ExecuteNonQuery();
            }
        }
    }
}
