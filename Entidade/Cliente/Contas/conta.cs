namespace Caelum
{  
    using System;
    public class Conta : Cliente
    {
        public int NumeroDaConta;


        public double Saldo;


        public Conta(double saldo, string primeiroNome, string ultimoNome, string rg, string cpf) : base(primeiroNome, ultimoNome, rg, cpf)
        {   
            Random gerarNumeroDaConta = new Random();
            NumeroDaConta = gerarNumeroDaConta.Next(000001,999999);
            Saldo = saldo;


        }
        
        public void Depositar(Conta conta, double valorDepositado)
        {   

            conta.Saldo += valorDepositado;
        }

        public void Sacar(Conta conta, double valorSacado)
        {
            if(conta.Saldo >= valorSacado)
            {
            conta.Saldo -= valorSacado;
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente");
            }
        }

        public void Transferir(Conta conta1, Conta conta2, double valorTranferido)
        {
            conta1.Saldo -= valorTranferido;
            conta2.Saldo += valorTranferido;

        }

    }


    
}