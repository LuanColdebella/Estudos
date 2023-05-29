using System;
using System.Collections.Generic;

namespace GerenciadorFinancas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> transacoes = new List<double>(); // Lista para armazenar as transações (despesas e receitas)
            double saldo = 0; // Saldo atual

            bool executando = true;
            while (executando)
            {
                Console.WriteLine("----- Gerenciador de Finanças -----");
                Console.WriteLine("1. Adicionar transação");
                Console.WriteLine("2. Visualizar saldo atual");
                Console.WriteLine("3. Sair");
                Console.WriteLine("-----------------------------------");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o valor da transação: ");
                        double valor = double.Parse(Console.ReadLine());

                        Console.WriteLine("A transação é uma despesa ou receita? (D/R)");
                        string tipo = Console.ReadLine().ToUpper();

                        if (tipo == "D")
                            saldo -= valor; // Deduz o valor da despesa do saldo
                        else if (tipo == "R")
                            saldo += valor; // Adiciona o valor da receita ao saldo

                        transacoes.Add(valor); // Adiciona a transação à lista
                        Console.WriteLine("Transação adicionada com sucesso!");
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("Saldo atual: " + saldo);
                        Console.WriteLine();
                        break;

                    case "3":
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Por favor, tente novamente.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
