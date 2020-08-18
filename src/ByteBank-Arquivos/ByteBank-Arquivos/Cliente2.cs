using _2_ByteBank;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ByteBank_Arquivos
{
    class Cliente2 : Cliente
    {
        public Cliente2(string nome, string cpf, string telefone)
            : base(nome, cpf, telefone)
        {

        }
        public override string ToString()
        {
            return $"{Nome},{CPF},{Telefone},{contaCorrente.Agencia},{contaCorrente.Conta},{contaCorrente.Senha}";
        }
    }
}
