using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Limites
{
    class Program
    {
        static void Main(string[] args)
        {
            int valorX, Qtd;
            

            double[] XDireita = new double[7];
            double[] XEsquerda = new double[7];

            double[] RDireita = new double[7];
            double[] REsquerda = new double[7];

            Console.Write("Quantos termos para inserir na Expressão? ");
            Qtd = int.Parse(Console.ReadLine());

            String[] Termo = new string[Qtd];
            String[] Opera = new string[Qtd - 1];
            double[] resultadosD = new double[Qtd];
            double[] resultadosE = new double[Qtd];

            // anotar a expressão inserida

            for (int Num = 0; Num < Qtd; Num++)
            {
                Console.Write($"\nInforme o {Num + 1}° termo da expressão:");
                Termo[Num] = Console.ReadLine();

                //verifica se tem que solicitar a operação
                if (Num != Qtd - 1)
                {
                    Console.Write($"\nDigite o {Num + 1} operador (+ - * /): ");
                    Opera[Num] = Console.ReadLine();
                    Console.WriteLine();
                }
            }

            for (int Num = 0; Num < Qtd; Num++)
            {
                if (Num != Qtd - 1)
                    Console.Write($"{Termo[Num]} {Opera[Num]} ");
                else
                    Console.Write($"{Termo[Num]}");
            }

            Console.WriteLine("\n\nDigite o valor de X:");
            valorX = Int32.Parse(Console.ReadLine());
            Console.WriteLine("=================================");

            //calcular a expressão

            XDireita[0] = valorX;
            XDireita[1] = (double)(valorX + 0.5);
            XDireita[2] = (double)(valorX + 0.1);
            XDireita[3] = (double)(valorX + 0.01);
            XDireita[4] = (double)(valorX + 0.001);
            XDireita[5] = (double)(valorX + 0.0001);
            XDireita[6] = (double)(valorX + 0.00001);

            XEsquerda[0] = valorX;
            XEsquerda[1] = (double)(valorX - 0.5);
            XEsquerda[2] = (double)(valorX - 0.1);
            XEsquerda[3] = (double)(valorX - 0.01);
            XEsquerda[4] = (double)(valorX - 0.001);
            XEsquerda[5] = (double)(valorX - 0.0001);
            XEsquerda[6] = (double)(valorX - 0.00001);

            for (int D = 0; D <= 6; D++) // calculo da direita
            {
                for (int parte = 0; parte < Qtd; parte++)
                {
                    resultadosD[parte] = Termonologia(XDireita[D], Termo[parte]);
                }

                for (int l = 0; l < Qtd - 1; l++)
                {
                    RDireita[D] = Kickassia(Opera[l], resultadosD[l], resultadosD[l + 1], RDireita[D]);
                }

            }

            for (int E = 0; E <= 6; E++) // calculo da esquerda
            {
                for (int parte = 0; parte < Qtd; parte++)
                {
                    resultadosE[parte] = Termonologia(XEsquerda[E], Termo[parte]);
                }

                for (int l = 0; l < Qtd - 1; l++)
                {
                    REsquerda[E] = Kickassia(Opera[l], resultadosE[l], resultadosE[l + 1], REsquerda[E]);
                }

            }

            
            Console.WriteLine("\nCalculo da direita");

            for (int Dshow = 0; Dshow <= 6; Dshow++) // calculo da direita
            {
                Console.WriteLine($"\n{XDireita[Dshow]} = {RDireita[Dshow]}");
                Console.WriteLine("\n=================================");

            }

            Console.WriteLine("\nCalculo da esquerda");

            for (int Eshow = 0; Eshow <= 6; Eshow++) // calculo da direita
            {
                Console.WriteLine($"\n{XEsquerda[Eshow]} = {REsquerda[Eshow]}");                
                Console.WriteLine("\n=================================");

            }



            Console.ReadKey();



        }

        static private double Termonologia(double valorX, String expressao)
        {
            double resultado = 0;

            //se a expressao não tem variavel, não precisa calcular
            if (expressao.ToUpper().IndexOf("X") == -1)
            {
                resultado = double.Parse(expressao);
            }
            else
            {
                //separa a expressão e joga dentro de um vetor
                String[] separado = expressao.ToUpper().Split('X');

                //verifica se a expressao tem exponencial
                if (separado.Length == 2 && separado[1] != "")
                {
                    resultado = Math.Pow(valorX, double.Parse(separado[1]));
                    resultado = resultado * double.Parse(separado[0]);
                }
                else //não tem exponencial
                {
                    resultado = valorX * double.Parse(separado[0]);
                }
            }

            return resultado;

        }

        static private double Kickassia(String Op, double Res, double Res1, double Prevs) //somadora dos resultados
        {
            double resultado = 0;

            if (Prevs == 0)
            {
                if (Op == "+")
                    resultado = Res + Res1;
                else if (Op == "-")
                    resultado = Res - Res1;
                else if (Op == "*")
                    resultado = Res * Res1;
                else if (Op == "/")
                    resultado = Res / Res1;
            }
            else
            {
                if (Op == "+")
                    resultado = Prevs + Res1;
                else if (Op == "-")
                    resultado = Prevs - Res1;
                else if (Op == "*")
                    resultado = Prevs * Res1;
                else if (Op == "/")
                    resultado = Prevs / Res1;
            }
            return resultado;

        }

    }
}
