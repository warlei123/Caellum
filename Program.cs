using System;
using System.Collections.Generic;

namespace Caelum
{
    class Program
    {
        public static List<Conta> contas = new List<Conta>();


        static void Main(string[] args)
        {
            string opcaoEscolhida = opcoes();

            while (opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("1- Cadastrar Cliente");
                        Console.WriteLine("2- Consultar Cliente");
                        Console.WriteLine("3- Encerrar conta");
                        Console.WriteLine("4- Listar todos os clientes");
                        var opcaoCliente = Console.ReadLine();
                        switch (opcaoCliente)
                        {
                            case "1":
                                Console.WriteLine();
                                Console.WriteLine("Informe o primeiro nome");
                                var primeiroNome = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Informe o ultimo nome");
                                var ultimoNome = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Informe o RG");
                                var rg = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Informe o CPF");
                                var cpf = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Deseja inserir saldo?");
                                var adcionarSaldo = Console.ReadLine().ToUpper();
                                double saldoAdcionado;
                                if (adcionarSaldo == "S" || adcionarSaldo == "SIM")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Quanto quer adcionar?");
                                    var saldoDigitado = Console.ReadLine();
                                    saldoAdcionado = Convert.ToDouble(saldoDigitado);
                                }
                                else
                                {
                                    saldoAdcionado = 0;
                                }

                                contas.Add(new Conta(saldoAdcionado, primeiroNome, ultimoNome, rg, cpf));
                                break;
                            case "2":
                                Console.WriteLine();
                                Console.WriteLine("informe o cpf");
                                var cpfDigitado = Console.ReadLine();

                                var clientePesquisado = contas.Find(contas => contas.Cpf == cpfDigitado);

                                if (clientePesquisado != null)
                                {

                                    Console.WriteLine($"Nome: {clientePesquisado.PrimeiroNome} {clientePesquisado.UltimoNome} ");
                                    Console.WriteLine($"Numero da conta: {clientePesquisado.NumeroDaConta}");
                                    Console.WriteLine($"RG: {clientePesquisado.Rg}");
                                    Console.WriteLine($"CPF: {clientePesquisado.Cpf}");
                                }
                                else
                                {
                                    Console.WriteLine("Cpf não cadastrado");

                                }
                                break;
                            case "3":

                                Console.WriteLine();
                                Console.WriteLine("informe o cpf");
                                var cpfParaCancelamento = Console.ReadLine();
                                var clienteCancelando = contas.Find(contas => contas.Cpf == cpfParaCancelamento);
                                if (clienteCancelando != null)
                                {
                                    if (clienteCancelando.MostrarSaldo() <= 0)
                                    {
                                        contas.Remove(clienteCancelando);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não e possivel encerrar uma conta com saldo\nFavor transferir valores à outra conta");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Cpf invalido");
                                }

                                break;
                            case "4":
                                foreach (var conta in contas)
                                {
                                    Console.WriteLine($"Nome: {conta.PrimeiroNome} {conta.UltimoNome} Conta Nº: {conta.NumeroDaConta}, Saldo: R${conta.MostrarSaldo().ToString("N2")}  ");
                                }
                                break;
                            default:
                                Console.WriteLine($"Comando Invalido");
                                break;
                        }

                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("1- Consultar saldo");
                        Console.WriteLine("2- Depositar");
                        Console.WriteLine("3- Sacar");
                        Console.WriteLine("4- Transferir");
                        var opcaoConta = Console.ReadLine();
                        switch (opcaoConta)
                        {
                            case "1":

                                Console.WriteLine();
                                Console.WriteLine("Informe o CPF do titular");
                                var cpfParaConsultaDeSaldo = Console.ReadLine();
                                var cpfPesquisadoParaSaldo = contas.Find(contas => contas.Cpf == cpfParaConsultaDeSaldo);
                                if (cpfPesquisadoParaSaldo != null)
                                {
                                    Console.WriteLine($"O saldo é: R${cpfPesquisadoParaSaldo.MostrarSaldo().ToString("N2")} ");
                                    Console.WriteLine($"Tributos R${cpfPesquisadoParaSaldo.CalcularTributo().ToString("N2")}");
                                }
                                else
                                {
                                    Console.WriteLine("Cpf não cadastrado");
                                }


                                break;
                            case "2":
                                Console.WriteLine();
                                Console.WriteLine("Informe o CPF do titular");
                                var cpfParaDeposito = Console.ReadLine();
                                var cpfPesquisadoParaDeposito = contas.Find(contas => contas.Cpf == cpfParaDeposito);
                                if (cpfPesquisadoParaDeposito != null)
                                {
                                    Console.WriteLine("Informe o valor à depositar");
                                    var valorDeposito = Console.ReadLine();
                                    var valorDepositoConvertido = Convert.ToDouble(valorDeposito);

                                    cpfPesquisadoParaDeposito.Depositar(cpfPesquisadoParaDeposito, valorDepositoConvertido);
                                }
                                else
                                {
                                    Console.WriteLine("Cpf não cadastrado");
                                }



                                break;
                            case "3":
                                Console.WriteLine();
                                Console.WriteLine("Informe o CPF do titular");
                                var cpfParaSaque = Console.ReadLine();
                                var cpfPesquisadoParaSaque = contas.Find(contas => contas.Cpf == cpfParaSaque);
                                if (cpfPesquisadoParaSaque != null)
                                {
                                    Console.WriteLine("Informe o valor à sacar");
                                    var valorSaque = Console.ReadLine();
                                    var valorSaqueConvertido = Convert.ToDouble(valorSaque);

                                    cpfPesquisadoParaSaque.Sacar(cpfPesquisadoParaSaque, valorSaqueConvertido);
                                }
                                else
                                {
                                    Console.WriteLine("Cpf não cadastrado");
                                }



                                break;
                            case "4":
                                Console.WriteLine();
                                Console.WriteLine("Informe o CPF do titular emissor");
                                var cpfDoEmissor = Console.ReadLine();
                                var cpfPesquisadoParaEmitir = contas.Find(contas => contas.Cpf == cpfDoEmissor);
                                Console.WriteLine();
                                Console.WriteLine("Informe o CPF do titular recebedor");
                                var cpfDoRecebedor = Console.ReadLine();
                                var cpfPesquisadoParaReceber = contas.Find(contas => contas.Cpf == cpfDoRecebedor);
                                Console.WriteLine("Informe o valor à transferir");
                                var valorTranferencia = Console.ReadLine();
                                var valorTransferenciaConvertido = Convert.ToDouble(valorTranferencia);

                                cpfPesquisadoParaReceber.Transferir(cpfPesquisadoParaEmitir, cpfPesquisadoParaReceber, valorTransferenciaConvertido);

                                Console.WriteLine($"Saldo de {cpfPesquisadoParaEmitir.PrimeiroNome}: R${cpfPesquisadoParaEmitir.MostrarSaldo().ToString("N2")} ");


                                break;

                            default:
                                Console.WriteLine($"Comando Invalido");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine($"Comando Invalido");
                        break;
                }
                opcaoEscolhida = opcoes();
            }



        }

        private static string opcoes()
        {
            Console.WriteLine();
            Console.WriteLine("Por favor, informe o serviço desejado");
            Console.WriteLine("1- Gerenciar clientes");
            Console.WriteLine("2- Operacões Financeiras");
            Console.WriteLine("X- Sair");
            var opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;
        }
    }
}
