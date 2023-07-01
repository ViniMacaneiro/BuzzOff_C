using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Others;
using BuzzOff_Pre_Alpha.Repository.DAO;
using PrototipoDengue.Authentications;

namespace BuzzOff_Pre_Alpha.Controller
{
    internal class UserController
    {
        UserDAO DAO;
        public UserController()
        {
            DAO = new UserDAO();
        }
        public void Insert(int accessLevel = 3)
        {
            UserModel model = null;
            
            Message("o CPF");
            var cpf = Console.ReadLine();
            if (CpfValidadtions.IsValidCPF(cpf))
            {
                cpf = CpfValidadtions.ClearCPF(cpf);
            }
            
            Message("o nome");
            var name = Console.ReadLine();

            Message("o e-mail");
            var email = Console.ReadLine();

            Message("a senha");
            var password = Console.ReadLine();  
            
            if(accessLevel == 3)
            {
                model = new UserModel(name, email, cpf, password);
            }
            else if (accessLevel == 2)
            {
                model = new UserModel(name, email, cpf, password, MyEnuns.Access.Agent);
            }
            else if (accessLevel == 1)
            {
                model = new UserModel(name, email, cpf, password, MyEnuns.Access.Administrator);
            }

            if(model != null)
            {
                DAO.Insert(model);
            }
            else
            {
                throw new NotImplementedException("UserController Insert");
            }            
        }

        public void Update(UserModel model)
        {           
            DAO.Update(model);
        }

        public void UpdatePassword(string password)
        {
            DAO.UpdatePassword(password);
        }
        public UserModel GetOne(int id)
        {            
            return DAO.GetOne(id);
        }

        public List<UserModel> GetAll()
        {
            
            return DAO.GetAll();
        }

        public void Delete(int id)
        {       
            DAO.Delete(id);
        }


        public static void login(string CPF, string password)
        {
            var user = new LoggedUser(CPF, password);
        }

        private void Message(string s)
        {
            Console.WriteLine($"Insira {s}");
        }

        public void Delete2(int id)
        {
            DenunciationController denunciationController = new DenunciationController();
            denunciationController.Delete2();
            DAO.Delete(id);
        }
    }
}
