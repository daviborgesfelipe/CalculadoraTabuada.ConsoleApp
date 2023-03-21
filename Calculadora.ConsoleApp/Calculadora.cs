using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.ConsoleApp
{
    internal class Calculadora
    {
        public double NumA { get; set; }
        public double NumB { get; set; }
        public char Operacao { get; set; }
        public double Resultado { get; set; }
        public string[] Descricao { get; set; }
        public Calculadora() { }
        public Calculadora(double num1, double num2)
        {
            NumA = num1;
            NumB = num2;
        }
        public Calculadora(char operacao)
        {
            Operacao = operacao;
        }
        public Calculadora(string[] descricao)
        {
            Descricao = descricao;
        }
        public void Adicao()
        {
            Resultado = NumA + NumB;
            Operacao = '+';
        }
        public void Subtracao()
        {
            Resultado = NumA - NumB;
            Operacao = '-';
        }
        public void Divisao()
        {
            Resultado = NumA / NumB;
            Operacao = '/';
        }
        public void Multiplicacao()
        {
            Resultado = NumA * NumB;
            Operacao = '*';
        }
        public void Modulo()
        {
            Resultado = NumA % NumB;
            Operacao = '%';
        }
        public void GerarTabuada()
        {
            for(
                int i = 1; i <= NumB; i++) 
            {
                if (i % 2 == 0)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                else
                    Console.BackgroundColor = ConsoleColor.Blue;
                Resultado = NumA * i;
                Console.WriteLine(NumA + " x " + i + " = " + Resultado);
            }
            Console.BackgroundColor= ConsoleColor.Black;
        }
        public void GerarRelatorio()
        {
            Console.WriteLine("=========================================");
            for (int i = 0; i < Descricao.Length; i++)
            {
                if (Descricao[i] != null)
                {
                    Console.WriteLine(Descricao[i]);
                }
            }
        }
        public void Erro()
        {
            Console.WriteLine("Tente novamente e selecione uma operacao disponivel");
        }
        public void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine("============================[ CTRL + C ]=");
            Console.WriteLine("========  Calculadora Top 2023  =========");
            Console.WriteLine("=========================================");
            Console.WriteLine("Selecione uma das operacoes disponiveis: ");
            Console.WriteLine(" 1 = Adicao");
            Console.WriteLine(" 2 = Subtracao");
            Console.WriteLine(" 3 = Multiplicacao");
            Console.WriteLine(" 4 = Divisao");
            Console.WriteLine(" 5 = Modulo da divisao");
            Console.WriteLine(" 6 = Gera tabuada do numero desejado");
            Console.WriteLine(" 7 = Gera relatorio");
            Console.WriteLine(" 0 = Sair");
            Console.WriteLine("=========================================");
        }
        public char GerarEntradaOpcao()
        {
            Console.Write("Informe a operacao: ");
            char entradaOpcao = Convert.ToChar(Console.ReadLine());
            return entradaOpcao;
        }
        public void ValidarOperacao(char entradaOpcao)
        {
            Console.WriteLine();
            if (entradaOpcao != '1' && entradaOpcao != '2' && entradaOpcao != '3' && entradaOpcao != '4' && entradaOpcao != '5' && entradaOpcao != '6' && entradaOpcao != '7' && entradaOpcao != '0')
            {
                Console.WriteLine("A operacao nao existe na calculadora.");
            }
            Console.WriteLine();

        }
        public bool ChecarOpcao(char entradaOpcao)
        {
            bool entrada = entradaOpcao == '1' || entradaOpcao == '2' || entradaOpcao == '3' || entradaOpcao == '4' || entradaOpcao == '5' || entradaOpcao == '6' ||entradaOpcao == '0';
            return entrada;
        }
        public double GerarEntradaNumA()
        {
            Console.WriteLine("=========================================");
            Console.Write("Informe o primeiro numero: ");
            double entradaNumA = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("=========================================");
            return entradaNumA;
        }
        public double GerarEntradaNumB()
        {
            Console.Write("Informe o segundo numero: ");
            double entradaNumB = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("=========================================");
            Console.WriteLine("=========================================");
            return entradaNumB;
        }
        public void IniciarCalculadora(int qntdOperacao, char entradaOpcao, string[] descricao, Calculadora calculadora)
        {
            if(entradaOpcao == '7')
            {
                switch (entradaOpcao)
                {
                    case '7':
                        calculadora = new Calculadora(descricao);
                        calculadora.GerarRelatorio();
                        break;
                }
                if (ChecarOpcao(entradaOpcao))
                {
                    descricao[qntdOperacao] = calculadora.NumA + " " + calculadora.Operacao + " " + calculadora.NumB + " = " + calculadora.Resultado;
                    qntdOperacao++;
                }
            }
            else
            {
                double entradaNumA = GerarEntradaNumA();
                double entradaNumB = GerarEntradaNumB();
                switch (entradaOpcao)
                {
                    case '1':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Adicao();
                        break;
                    case '2':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Subtracao();
                        break;
                    case '3':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Multiplicacao();
                        break;
                    case '4':
                        while (entradaNumB == 0)
                        {
                            Console.WriteLine("O divisor nao pode ser igual a zero");
                            Console.WriteLine("=========================================");
                            Console.Write("Digite o divisor novamente: ");
                            entradaNumB = Convert.ToDouble(Console.ReadLine());
                        }
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Divisao();
                        break;
                    case '5':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Modulo();
                        break;
                    case '6':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.GerarTabuada();
                        break;
                    case '0':
                        break;
                }

                calculadora.ImprimirTabuada(descricao, entradaOpcao, calculadora, qntdOperacao);
                calculadora.ImprimirResultado(entradaOpcao, calculadora);

            }
        }
        public void ImprimirTabuada(string[] descricao, char entradaOpcao, Calculadora calculadora, int qntdOperacao)
        {
            if (ChecarOpcao(entradaOpcao))
            {
                descricao[qntdOperacao] = calculadora.NumA + " " + calculadora.Operacao + " " + calculadora.NumB + " = " + calculadora.Resultado;
                qntdOperacao++;
            }
        }
        public void ImprimirResultado(char entradaOpcao, Calculadora calculadora)
        {
            Console.WriteLine("=============   RESULTADO   =============");
            if (entradaOpcao != '#')
            {
                Console.WriteLine($" Resultado: {calculadora.NumA} {calculadora.Operacao} {calculadora.NumB} = {calculadora.Resultado}");
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Aperte enter para uma nova operacao,");
            Console.WriteLine("ou Ctrl + C para encerrar o console.");
            Console.ReadLine();
        }
    }
}
