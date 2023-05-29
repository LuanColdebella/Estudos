using System;
using System.Collections.Generic;

namespace JogoEducacional
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criação de uma lista de perguntas e respostas
            List<Pergunta> perguntas = new List<Pergunta>()
            {
                new Pergunta("Qual é a capital do Brasil?", new List<string>(){ "Rio de Janeiro", "São Paulo", "Brasília" }, 3),
                new Pergunta("Quem pintou a Mona Lisa?", new List<string>(){ "Pablo Picasso", "Leonardo da Vinci", "Vincent van Gogh" }, 2),
                new Pergunta("Qual é o maior planeta do Sistema Solar?", new List<string>(){ "Terra", "Júpiter", "Marte" }, 2)
            };

            int pontuacaoTotal = 0;

            // Loop para exibir as perguntas e obter as respostas dos jogadores
            foreach (Pergunta pergunta in perguntas)
            {
                Console.WriteLine(pergunta.Descricao);

                for (int i = 0; i < pergunta.Opcoes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {pergunta.Opcoes[i]}");
                }

                Console.Write("Escolha a opção correta (1, 2, 3): ");
                int resposta = Convert.ToInt32(Console.ReadLine());

                if (resposta == pergunta.RespostaCorreta)
                {
                    Console.WriteLine("Resposta correta!");
                    pontuacaoTotal++;
                }
                else
                {
                    Console.WriteLine("Resposta incorreta!");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Pontuação total: {pontuacaoTotal}/{perguntas.Count}");

            Console.ReadLine();
        }
    }

    class Pergunta
    {
        public string Descricao { get; }
        public List<string> Opcoes { get; }
        public int RespostaCorreta { get; }

        public Pergunta(string descricao, List<string> opcoes, int respostaCorreta)
        {
            Descricao = descricao;
            Opcoes = opcoes;
            RespostaCorreta = respostaCorreta;
        }
    }
}
