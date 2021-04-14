using System;
using System.Collections.Generic;
using System.Threading;
namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "S")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "L":
                        Limpar();
                        break;
                    default:
                        Console.WriteLine("Opcao é inválida! Comece novamente!");
                    break;
                }
               opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void Limpar()
        {
            
            Console.WriteLine("Carregando...");                        
            Thread.Sleep(3000);
            Console.Clear(); 
                      
        }

        
        private static void Transferir()
        {
            ListarContas();

            Console.WriteLine("Digite o número da conta Origem:");
            int indiceContaOrigem  = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor para Depósito:");
            double valorTransferencia  = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta Destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            if (indiceContaDestino != indiceContaOrigem)
            {
                listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);                            
            }else
            {
                Limpar();
                Console.WriteLine();
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxx ATENÇÃO xxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Você não pode transfêrir um valor para a mesma conta!! Tente novamente!");
                Console.WriteLine();
                Console.WriteLine();

                Transferir();
            }

        }

        private static void Depositar()
        {
            ListarContas();

            Console.WriteLine("Digite o número da conta para Depósito:");
            int indiceConta  = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do Depósito:");
            int valorSaque  = int.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorSaque);
        }

        private static void Sacar()
        {
            ListarContas();

            Console.WriteLine("Digite o número da conta:");
            int indiceConta  = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do Saque:");
            int valorSaque  = int.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
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

        private static void ListarContas()
        {
            Limpar();
           Console.WriteLine("CONTAS DISPONÍVEIS");
           Console.WriteLine("######################################################################################");
           for(int i=0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0}- ", i);
                Console.WriteLine(conta);            
           }
           Console.WriteLine("######################################################################################");
           Console.WriteLine();
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
