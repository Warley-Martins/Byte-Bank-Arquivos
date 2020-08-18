using _2_ByteBank;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBank_Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public static void RecuperarDados()
        {
            Console.Write("Digite o nome do arquivo que deseja Recuperar: ");
            var arquivo = Console.ReadLine();
            if (arquivo.IndexOf('.') == -1)
            {
                arquivo += ".txt";
            }
            var clientes = new List<Cliente2>();
            using (var fluxoDeArquivo = new FileStream(arquivo, FileMode.Open))
            using (StreamReader leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var dadosCliente = leitor.ReadLine();
                    var atributos = dadosCliente.Split(',');
                    var nome = atributos[0];
                    var cpf = atributos[1];
                    var telefone = atributos[2];
                    Cliente2 c = new Cliente2(nome, cpf, telefone);
                    var numeroAgencia = int.Parse(atributos[3]);
                    var numeroConta = int.Parse(atributos[4]);
                    var senha = atributos[5];
                    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta, senha);
                    c.contaCorrente = conta;
                    clientes.Add(c);
                }
            }
        }
        private static void LeituraArquivo()
        {
            EscritaEmArquivo();
            Console.Write("Digite o nome do arquivo que deseja ler: ");
            var arquivo = Console.ReadLine();
            if (arquivo.IndexOf('.') == -1)
            {
                arquivo += ".txt";
            }
            using (var fluxoDeArquivo = new FileStream(arquivo, FileMode.Open))
            using (StreamReader leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    Console.WriteLine(leitor.ReadLine());
                }
            }
        }

        private static void EscritaBinaria()
        {
            Console.Write("Digite o nome do arquivo que deseja criar: ");
            var arquivo = Console.ReadLine();
            if (arquivo.IndexOf('.') == -1)
            {
                arquivo += ".txt";
            }
            using (var fluxoDeArquivo = new FileStream(arquivo, FileMode.Create))
            using (BinaryWriter escritor = new BinaryWriter(fluxoDeArquivo))
            {
                Console.Write("Digite a quantidade de clientes que deseja salvar: ");
                int quantidadeClientes = int.Parse(Console.ReadLine());
                for (int i = 0; i < quantidadeClientes; i++)
                {

                    Cliente2 c = CadastrarNovoCliente();
                    escritor.Write(c.Nome);
                    escritor.Write(c.CPF);
                    escritor.Write(c.Telefone);
                    escritor.Write(c.contaCorrente.Agencia);
                    escritor.Write(c.contaCorrente.Conta);
                }
            }
        }
        private static void LeituraBinaria()
        {
            Console.Write("Digite o nome do arquivo que deseja Ler: ");
            var arquivo = Console.ReadLine();
            if (arquivo.IndexOf('.') == -1)
            {
                arquivo += ".txt";
            }
            using (var fluxoDeArquivo = new FileStream(arquivo, FileMode.Open))
            using (var leitor = new BinaryReader(fluxoDeArquivo))
            {
                Console.Write("Digite a quantidade de clientes que deseja salvar: ");
                int quantidadeClientes = int.Parse(Console.ReadLine());

                var nome = leitor.Read();
                var telefone = leitor.Read();
                var cpf = leitor.Read();
                var numeroAgencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var senha = leitor.Read();
                var texto = $"{nome}{cpf}{telefone}{numeroAgencia}{numeroConta}{senha}";
                if (arquivo.IndexOf(".cvs") != -1)
                {
                    texto.Replace(',', ' ');
                }
                Console.WriteLine(texto);

            }
        }

        private static void EscritaEmArquivo()
        {
            Console.Write("Digite o nome do arquivo que deseja criar: ");
            var arquivo = Console.ReadLine();
            if (arquivo.IndexOf('.') == -1)
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

        private static Cliente2 CadastrarNovoCliente()
        {
            Console.Write("Digite o nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write("Digite o cpf do cliente: ");
            var cpf = Console.ReadLine();
            Console.Write("Digite o telefone do cliente: ");
            var telefone = Console.ReadLine();
            Cliente2 c = new Cliente2(nome, cpf, telefone);
            Console.Write("Digite a senha do cliente: ");
            var senha = Console.ReadLine();
            Console.Write("Digite a agencia da conta do cliente: ");
            var numeroAgencia = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta do cliente: ");
            var numeroConta = int.Parse(Console.ReadLine());
            ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta, senha);
            c.contaCorrente = conta;
            return c;


        }
    }
}
