using BuzzOff_Pre_Alpha.Authentications.Cryptography;
using BuzzOff_Pre_Alpha.Controller;
using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Others;
using BuzzOff_Pre_Alpha.Repository.DAO;
using PrototipoDengue.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoDengue.View
{
    internal class CommonHomeView
    {    
        DenunciationController denunciationController = new DenunciationController();
        UserController userController = new UserController();
        public void Start()
        {
            
            Console.Clear();
            Console.WriteLine($"\n\n\nBem vindo, sr. {LoggedUser.loggedUser.Name} usuário comum.\n\n\n");

            Console.WriteLine("[1] Efetuar denuncia.");
            Console.WriteLine("[2] Listar denuncias efetuadas.");
            Console.WriteLine("[3] Listar denuncias atendidas.");
            Console.WriteLine("[4] Listar denuncias não atendidas.");
            Console.WriteLine("[5] Alterar senha.");
            Console.WriteLine("[6] Excluir conta.");

            var s = Console.ReadLine();

            switch (s)
            {
                case "1": 
                    Insert();
                    Thread.Sleep(3000);
                    Console.Clear();
                    this.Start();
                    break;

                case "2": 
                    ListByInformer();
                    Thread.Sleep(3000);
                    Console.Clear();
                    this.Start();
                    break;

                case "3": 
                    ListByAnswered(true);
                    Thread.Sleep(3000);
                    Console.Clear();
                    this.Start();
                    break; 

                case "4": 
                    ListByAnswered(false);
                    Thread.Sleep(3000);
                    Console.Clear();
                    this.Start();
                    break;

                case "5":
                    UpdatePassword();
                    Thread.Sleep(3000);
                    Console.Clear();
                    this.Start();
                    break;

                case "6":
                    DeleteAccount();
                    Thread.Sleep(3000);
                    Console.Clear();
                    this.Start();
                    break;

                default: 
                    Console.Clear(); 
                    this.Start(); 
                    break;
            }            
        }

        private void ListByInformer()
        {
            List<DenunciationModel> list = denunciationController.GetByInformer(LoggedUser.loggedUser.Id);
            foreach (var item in list)
            {
                Console.WriteLine(
                    $"\nDenunciante: {LoggedUser.loggedUser.Name}." + 
                    $"\nData da denuncia: {item.DataDenunciation}." +
                    $"\nVistoriado: {Translate.TranslateBool(item.IsAnswered)}");
            }
        }
        private void ListByAnswered(bool b)
        {
            var list = denunciationController.GetByInformerIdAndIsAnswered(LoggedUser.loggedUser.Id, b);
            foreach (var item in list)
            {
                Console.WriteLine(
                    $"\nDenunciante: {LoggedUser.loggedUser.Name}." +
                    $"\nData da denuncia: {item.DataDenunciation}." +
                    $"\nVistoriado: {Translate.TranslateBool(item.IsAnswered)}");
            }
        }

        private void Insert()
        {
            Message("o bairro");
            var neighborhood = Console.ReadLine();

            Message("a rua");
            var street = Console.ReadLine();

            Message("o número");
            var number = Console.ReadLine();

            Message("uma referÊncia");
            var reference = Console.ReadLine();

            var model = new AddressModel(neighborhood, street, number, reference, "1", "1");
            var addressController = new AddressController();

            var addressID = addressController.Insert(model);

            byte[] media = new byte[1];
            var denunciationModel = new DenunciationModel(addressID, media);

            denunciationController.Insert(denunciationModel);

            Console.WriteLine("Denuncia efetuada com sucesso");


        }

        private void UpdatePassword()
        {
            Console.WriteLine("Informe sua senha");
            var pass = HashGenerator.GenerateHash(Console.ReadLine());

            if (pass == LoggedUser.loggedUser.Password)
            {
                Console.WriteLine("Insira a nova senha");
                var newPass = HashGenerator.GenerateHash(Console.ReadLine());
                userController.UpdatePassword(newPass);
                Console.WriteLine("Senha alterada com sucesso.");
            }
            else throw new Exception("Senha inválida.");
            
        }

        private void DeleteAccount()
        {
            Console.WriteLine("Informe sua senha");
            var pass = HashGenerator.GenerateHash(Console.ReadLine());

            if (pass == LoggedUser.loggedUser.Password)
            {
                userController.Delete2(LoggedUser.loggedUser.Id);

                Console.WriteLine("Tchau.");
                Environment.Exit(0);
            }
                
        }
        private void Message(string s)
        {
            Console.WriteLine($"Insira {s}");
        }

    }
}
