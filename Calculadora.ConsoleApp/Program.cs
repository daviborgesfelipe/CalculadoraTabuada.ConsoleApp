namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculadora calculadora = null;
            char entradaOperacao;
            string[] descricao = new string[100];
            int qntdOperacao = 0;

            while (true) 
            {
                double entradaNumA;
                double entradaNumB;
                Console.Clear();
                Console.WriteLine("============================[ CTRL + C ]=");
                Console.WriteLine("========  Calculadora Top 2023  =========");
                Console.WriteLine("=========================================");
                Console.WriteLine("Selecione uma das operacoes disponiveis: ");
                Console.WriteLine(" + = Adicao");
                Console.WriteLine(" - = Subtracao");
                Console.WriteLine(" * = Multiplicacao");
                Console.WriteLine(" / = Divisao");
                Console.WriteLine(" % = Modulo da divisao");
                Console.WriteLine(" # = Gera tabuada do numero desejado");
                Console.WriteLine(" @ = Gera relatorio");
                Console.WriteLine("=========================================");
                Console.Write("Informe a operacao: ");
                entradaOperacao = Convert.ToChar(Console.ReadLine());
                //if (entradaOperacao == '#' || entradaOperacao == '+' || entradaOperacao == '-' || entradaOperacao == '*' || entradaOperacao == '/' || entradaOperacao == '%')
                //{
                //}
                if (entradaOperacao == '@')
                {
                    switch (entradaOperacao)
                    {
                        case '@':
                            calculadora = new Calculadora(descricao);
                            calculadora.GerarRelatorio();
                            break;
                    }
                }
                Console.WriteLine("=========================================");
                Console.Write("Informe o primeiro numero: ");
                entradaNumA = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("=========================================");
                Console.Write("Informe o segundo numero: ");
                entradaNumB = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("=========================================");
                Console.WriteLine("=========================================");
                if(entradaOperacao != '#' && entradaOperacao != '+' && entradaOperacao != '-' && entradaOperacao != '*' && entradaOperacao != '/' && entradaOperacao != '%' && entradaOperacao != '@')
                {
                    Console.WriteLine("A operacao nao existe na calculadora.");
                }
                switch (entradaOperacao) 
                {
                    case '+':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Adicao();
                        break;
                    case '-':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Subtracao();
                        break;
                    case '*':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Multiplicacao();
                        break;
                    case '/':
                        while(entradaNumB == 0)
                        {
                            Console.WriteLine("O divisor nao pode ser igual a zero");
                            Console.WriteLine("=========================================");
                            Console.Write("Digite o divisor novamente: ");
                            entradaNumB = Convert.ToDouble(Console.ReadLine());
                        }
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Divisao();
                        break;
                    case '%':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.Modulo();
                        break;
                    case '#':
                        calculadora = new Calculadora(entradaNumA, entradaNumB);
                        calculadora.GerarTabuada();
                        break;
                    //case '@':
                    //    calculadora = new Calculadora(descricao);
                    //    calculadora.GerarRelatorio();
                    //    break;
                    default:
                        calculadora = new Calculadora(entradaOperacao);
                        calculadora.Erro();
                        continue;
                }
                if (entradaOperacao == '#' || entradaOperacao == '+' || entradaOperacao == '-' || entradaOperacao == '*' || entradaOperacao == '/' || entradaOperacao == '%')
                {
                    descricao[qntdOperacao] = calculadora.NumA +" "+ calculadora.Operacao+" "+calculadora.NumB + " = " +calculadora.Resultado;
                    qntdOperacao++;
                }
                Console.WriteLine("=============   RESULTADO   =============");
                if(entradaOperacao != '#')
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
}