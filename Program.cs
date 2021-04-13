using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    default:
                        Console.WriteLine("Opcao é inválida! Comece novamente!");
                    break;
                }
               opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inseir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("L - Limpar Tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }

        private static void ListaContas()
        {
            throw new NotImplementedException();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Escolha o tipo de Conta:");
            Console.WriteLine($" 1 Pessoa Fisica:");
            Console.WriteLine($" 2 Pessoa Juridica:");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (ETipoConta)tipoConta, 
                                        nome: nome, 
                                        saldo: saldo, 
                                        credito: credito);

            listContas.Add(novaConta);
            
        }
    }
}
