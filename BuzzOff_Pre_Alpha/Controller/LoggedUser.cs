
using BuzzOff_Pre_Alpha.Authentications.Cryptography;
using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Others;
using BuzzOff_Pre_Alpha.Repository;
using System.Data.SqlClient;

internal class LoggedUser
{   
    protected internal LoggedUser(string CPF, string password)
    {
        using (var conn = new SqlConnection(DBConnect.Connect()))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, PASSWORD, ACCESSLEVEL FROM USERS WHERE CPF = @CPF AND PASSWORD = @PASSWORD";
            cmd.Parameters.AddWithValue("@CPF", CPF);
            cmd.Parameters.AddWithValue("PASSWORD", HashGenerator.GenerateHash(password));

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.Id = reader.GetInt32(0);
                    this.Name = reader.GetString(1);
                    this.Email = reader.GetString(2);                    
                    this.CPF = reader.GetString(3);
                    this.Password = reader.GetString(4);
                    this.AccessLevel = (MyEnuns.Access)reader.GetInt32(5);
                    authenticated = true;

                    LoggedUser.loggedUser = this;
                    
                }
              
            }
            if (!Authenticated)
            {
                throw new Exception("Usuário e/ou senha inválidos.");
            }
            
        }
    }
    public  int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string CPF { get; private set; }
    public MyEnuns.Access AccessLevel { get; private set; }

    private bool authenticated = false;
    public bool Authenticated { get { return authenticated; } }

    public static LoggedUser loggedUser { get; private set; }

}
