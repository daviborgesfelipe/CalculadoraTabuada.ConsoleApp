using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    }
}
