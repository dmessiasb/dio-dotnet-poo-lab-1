using System;

namespace DIO.Bank
{
    public class Conta
    {
        private ETipoConta TipoConta{get;set;}
        private string Nome { get; set; }
        private double Saldo {get;set;}
        private double Credito {get;set;}

        public Conta(ETipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo-valorSaque< (this.Credito*-1))
            {
                Console.WriteLine($"Saldo insuficiente! {Saldo}");
                return false;
            }

            this.Saldo-= valorSaque;
            ExibeSaldo();
            
            return true;
        }


         public void Depositar(double valorDeposito)
        {
            this.Saldo +=valorDeposito;
            ExibeSaldo();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        private void ExibeSaldo(){
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + "|";
            retorno += "Nome: " + this.Nome + "|";
            retorno += "Saldo: " + this.Saldo + "|";
            retorno += "Credito: " + this.Credito;

            return retorno;

        }

    }

}