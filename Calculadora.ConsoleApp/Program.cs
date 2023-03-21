namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char entradaOpcao;
            string[] descricao = new string[100];
            int qntdOperacao = 0;
            Calculadora calculadora = new Calculadora();

            while (true) 
            {
                calculadora.ImprimirMenu();
                entradaOpcao = calculadora.GerarEntradaOpcao();
                calculadora.ValidarOperacao(entradaOpcao);
                calculadora.IniciarCalculadora(
                    qntdOperacao,
                    entradaOpcao,
                    descricao,
                    calculadora);
            }
        }
    }
}