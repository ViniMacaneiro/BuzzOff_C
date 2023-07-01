using BuzzOff_Pre_Alpha.Controller;
using BuzzOff_Pre_Alpha.Others;
using PrototipoDengue.Authentications;
using PrototipoDengue.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.View
{
    internal class LoginView
    {
        public void Start()
        {
            CommonHomeView commonHomeView = new CommonHomeView();

            Console.Clear();

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("         Login         ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

            Console.WriteLine("Informe seu CPF.");
            var CPF = CpfValidadtions.ClearCPF(Console.ReadLine());

            Console.WriteLine("Informe sua senha.");
            var password = Console.ReadLine();

            UserController.login(CPF, password);


            if (LoggedUser.loggedUser.Authenticated)
            {
                switch (LoggedUser.loggedUser.AccessLevel)
                {
                    case MyEnuns.Access.Common: commonHomeView.Start(); break;
                    case MyEnuns.Access.Agent: break;
                    case MyEnuns.Access.Administrator: break;
                }
            }
            else throw new Exception("Erro ao efetuar login");
        }

    }
}
