namespace Caelum
{
    using System;
    public class Conta : Cliente, ITributos, IPoupanca
    {
        public int NumeroDaConta;


        protected double Saldo;


        public double MostrarSaldo()
        {
            return this.Saldo;
        }


        public Conta(double saldo, string primeiroNome, string ultimoNome, string rg, string cpf) : base(primeiroNome, ultimoNome, rg, cpf)
        {
            Random gerarNumeroDaConta = new Random();
            NumeroDaConta = gerarNumeroDaConta.Next(000001, 999999);
            Saldo = saldo;


        }

        public void Depositar(Conta conta, double valorDepositado)
        {

            conta.Saldo += valorDepositado;
        }

        public void Sacar(Conta conta, double valorSacado)
        {
            if (conta.Saldo >= valorSacado)
            {
                conta.Saldo -= valorSacado + 0.10;

            }
            else
            {
                Console.WriteLine("Saldo Insuficiente");
            }
        }

        public void Transferir(Conta conta1, Conta conta2, double valorTranferido)
        {
            if (conta1.Saldo >= valorTranferido)
            {
                conta1.Saldo -= valorTranferido;
                conta2.Saldo += valorTranferido;
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente");
            }
        }

        public double CalcularTributo()
        {
            return this.Saldo * 0.02;
        }

        public double calcularRendimento()
        {
            return this.Saldo * 0.05;
        }



    }



}