using System;
using System.Collections.Generic;
using DIO.Bank.Classes;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoEscolhida = ObterOpcaoUsuario();

            while(opcaoEscolhida != "X")
            {
                switch(opcaoEscolhida)
                {
                    case "1":

                        break;
                    case "2":
                        
                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção escolhida é inválida!");
                }

                opcaoEscolhida = ObterOpcaoUsuario();
            }

            Console.WriteLine("A International DIO Bank agradeçe a preferencia!.");

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("International DIO Bank.");
            Console.WriteLine("Qual operação deseja executar:");

            Console.WriteLine("1 - Listar contas.");
            Console.WriteLine("2 - Inserir nova compra.");
            Console.WriteLine("3 - Transferir.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - Depositar.");
            Console.WriteLine("6 - Limpar a tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
