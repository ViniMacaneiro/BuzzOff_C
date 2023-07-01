using BuzzOff_Pre_Alpha.View;
using PrototipoDengue.Authentications;

namespace PrototipoDengue.View
{
    public class StartView
    {
        
        RegisterView registerView = new RegisterView();
        SymptomView symptomView = new SymptomView();        
        MapView mapView = new MapView();
        LoginView loginView = new LoginView();

        public void Start()
        {
            var count = 0;
            string s;          

            Console.WriteLine(
                "\n[1] Login." +
                "\n[2] Cadastro." +
                "\n[3] Opções sem login.");                    

            do
            {
                s = Console.ReadLine().Trim();

                if (CpfValidadtions.verifyNumber(s))
                {
                    int index = int.Parse(s);

                    switch (index)
                    {
                        case 1: 
                            loginView.Start();                            
                            Console.Clear();
                            this.Start(); 
                            break;

                        case 2: 
                            registerView.start();
                            Thread.Sleep(2000);
                            Console.Clear();
                            this.Start();
                            break;

                        case 3: 
                            optionWhithoutLogin();
                            Thread.Sleep(3000);
                            Console.Clear();
                            this.Start();
                            break;

                        case 4: 
                            Console.Clear(); 
                            Environment.Exit(1); 
                            break;

                        default: 
                            Console.WriteLine("Entrada inválida.");
                            Console.WriteLine();
                            Console.Clear();
                            this.Start();
                            break;
                    }

                }

            } while (!CpfValidadtions.verifyNumber(s) && s.ToLower().Trim() != "4");
        }       

        void optionWhithoutLogin() {

            string s;

            Console.WriteLine("" +
                "\n[1] Sintomas e tratamentos." +
                "\n[2] Locais de tratamento." +
                "\n[3] Mapas." +
                "\n[4] Sair.");

            do
            {
                s = Console.ReadLine().Trim();

                if (CpfValidadtions.verifyNumber(s))
                {
                    int index = int.Parse(s);

                    switch (index)
                    {  
                        case 1: mapView.start(); break;
                        case 2: Console.Clear(); Environment.Exit(1); break;
                        default: Console.WriteLine("Entrada inválida."); break;
                    }

                }

            } while (!CpfValidadtions.verifyNumber(s) && s.ToLower().Trim() != "4");

        }
    }
}
