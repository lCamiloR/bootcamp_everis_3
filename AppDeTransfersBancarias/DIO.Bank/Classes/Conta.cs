
using System;
using System.Text;
using DIO.Bank.Enums;

namespace DIO.Bank.Classes
{
    public class Conta
    {
        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private TipoConta TipoDeConta {get; set;}

        public Conta (TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoDeConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // TODO: Valida se saldo suficiente
            if ((this.Saldo - valorSaque) > this.Credito)
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            // TODO: Debita o saque
            this.Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é R$ {this.Saldo}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            // TODO: Acrescimo do valor do saldo
            Console.WriteLine($"Saldo anterior de R$ {this.Saldo}");
            Console.WriteLine($"Deposito de R$ {valorDeposito}");

            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é R$ {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder($"Tipo de Conta: {this.TipoDeConta} \n");

            retorno.Append($"Tipo de Conta: {this.TipoDeConta} \n");
            retorno.Append($"Titular: {this.Nome} \n");
            retorno.Append($"Saldo: {this.Saldo} \n");
            retorno.Append($"Crédito: {this.Credito} \n");

            return retorno.ToString();
        }
    }
}