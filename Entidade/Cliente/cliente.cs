namespace Caelum
{
    using System;
    public abstract class Cliente
    {

        public string PrimeiroNome;

        public string UltimoNome;

        public string Rg;

        public string Cpf;

        public string dataNascismento;



        public Cliente(string primeiroNome, string ultimoNome, string rg, string cpf)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Rg = rg;
            Cpf = cpf;
            dataNascismento = new DateTime(1992, 12, 19).ToString();


        }
    }
}