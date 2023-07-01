using BuzzOff_Pre_Alpha.Controller;

namespace PrototipoDengue.View
{
    internal class RegisterView
    {
        public void start()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("        Cadastro       ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

            UserController controller = new UserController();
            controller.Insert();

            Console.WriteLine("Registrado com sucesso");

        }
    }
}
