using _2_ByteBank;
using System;
using System.IO;
using System.Text;

namespace ByteBank_Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do arquivo que deseja criar: ");
            var arquivo = Console.ReadLine();
            if(arquivo.IndexOf('.') == -1)
            {
                arquivo += ".txt";
            }
            using (var fluxoDeArquivo = new FileStream(arquivo, FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
            {
                Console.Write("Digite a quantidade de clientes que deseja salvar: ");
                int quantidadeClientes = int.Parse(Console.ReadLine());
                for (int i = 0; i < quantidadeClientes; i++)
                {
                    escritor.Write(CadastrarNovoCliente());
                }
            }
        }

        private static Cliente CadastrarNovoCliente()
        {
            Console.Write("Digite o nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write("Digite o cpf do cliente: ");
            var cpf = Console.ReadLine();
            Console.Write("Digite o telefone do cliente: ");
            var telefone = Console.ReadLine();
            Cliente c = new Cliente(nome, cpf, telefone);
            Console.Write("Digite a senha do cliente: ");
            var senha = Console.ReadLine();
            Console.Write("Digite a agencia da conta do cliente: ");
            var numeroAgencia = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta do cliente: ");
            var numeroConta = int.Parse(Console.ReadLine());
            ContaCorrente conta = new ContaCorrente(numeroAgencia,numeroConta, senha);
            c.contaCorrente = conta;
            return c;


        }
    }
}
