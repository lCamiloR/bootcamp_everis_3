using System;
using System.Collections.Generic;
using DIO.Bank.Classes;

namespace DIO.Bank
{
    class Program
    {
        static Dictionary<string, Conta> listaContas = new Dictionary<string, Conta>();

        static void Main(string[] args)
        {
            string opcaoEscolhida = ObterOpcaoUsuario();

            while(opcaoEscolhida != "X")
            {
                switch(opcaoEscolhida)
                {
                    case "1":
                        //TODO: Listagem de todas as contas disponíveis
                        ListarContas();
                        break;
                    case "2":
                        //TODO: Cadastro de nova conta
                        CadastrarNovaConta();
                        break;
                    case "3":
                        //TODO: Transferência bancária
                        TransferenciaEntreContas();
                        break;
                    case "4":
                        //TODO: Sacar valor da conta
                        Sacar();
                        break;
                    case "5":
                        //TODO: Inserir dinheiro na conta
                        DepositarConta();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção escolhida é inválida!");
                }

                opcaoEscolhida = ObterOpcaoUsuario();
            }

            Console.WriteLine("A International DIO Bank agradeçe a preferencia!.");

        }

        private static void TransferenciaEntreContas()
        {
            Console.WriteLine("Qual valor deseja transferir?");
            double valorDaTranferencia = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o código da conta de origem?");
            string codContaOrigem = Console.ReadLine();

            Console.WriteLine("Qual o código da conta de destino?");
            string codContaDestino = Console.ReadLine();

            if(!listaContas.TryGetValue(codContaDestino, out Conta contaClienteDestino))
            {
                Console.WriteLine("Conta de destino com código fornecido não foi encontrada!");
                return;
            }

            if(listaContas.TryGetValue(codContaOrigem, out Conta contaClienteOrigem))
            {
                contaClienteOrigem.Transferir(valorDaTranferencia, contaClienteDestino);
            }
            else
            {
                Console.WriteLine("Conta de origem com código fornecido não encontrada!");
            }
        }

        private static void DepositarConta()
        {
            Console.WriteLine("Qual valor deseja depositar?");
            double valorDeposito = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o código da conta?");
            string codConta = Console.ReadLine();

            if(listaContas.TryGetValue(codConta, out Conta contaCliente))
            {
                contaCliente.Depositar(valorDeposito);
            }
            else
            {
                Console.WriteLine("Conta com código fornecido não encontrada!");
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Qual valor deseja sacar?");
            double valorSaque = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o código da conta?");
            string codConta = Console.ReadLine();

            if(listaContas.TryGetValue(codConta, out Conta contaCliente))
            {
                if(contaCliente.Sacar(valorSaque))
                {
                    Console.WriteLine("Operação realizada com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Conta com código fornecido não encontrada!");
            }
        }

        private static void Transferir()
        {
            Console.WriteLine("Qual valor deseja transferir?");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o nome da conta que receberá a transferência?");
            string nomeConta = Console.ReadLine();

            
        }

        private static void ListarContas()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            int contador = 1;
            foreach(string i in listaContas.Keys)
            {
                Console.WriteLine($" ====== Conta número {contador} ====== ");
                Console.WriteLine($"Código da conta: {i}");
                Console.WriteLine(listaContas[i].ToString());
                Console.WriteLine();
                
                contador++;
            }
        }

        private static void CadastrarNovaConta()
        {
            Console.WriteLine("Qual o tipo da conta? Digite 1 para Fisica 2 para Juridica.");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o nome do titular da conta?");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual o saldo inicial da conta?");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o crédito inicial da conta?");
            double creditoInicial = double.Parse(Console.ReadLine());

            Random rnd = new Random();
            string cod = "";
            while(true)
            {
                cod = rnd.Next(0, 999).ToString();
                if (!listaContas.ContainsKey(cod)){
                    Console.WriteLine($"Este é o código da sua conta: {cod}");
                    break;
                }
            }

            Conta novaConta = new Conta(tipoConta: (Enums.TipoConta)tipoConta,
                                        saldo: saldoInicial,
                                        credito: creditoInicial,
                                        nome: nome);

            listaContas.Add(cod, novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("International DIO Bank.");
            Console.WriteLine("Qual operação deseja executar:");

            Console.WriteLine("1 - Listar contas.");
            Console.WriteLine("2 - Inserir nova conta.");
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
