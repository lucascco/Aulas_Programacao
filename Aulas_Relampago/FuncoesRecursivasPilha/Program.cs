using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncoesRecursivas
{
    class Program
    {
        static void Main(string[] args)
        {

           //Console.WriteLine(somarNumerosAnteriores(5));

            int[] vetor = new int[4] { 3, 1, 5, 9 };

            Console.WriteLine(encontrarMenorValor(vetor.Length - 1, vetor));

            Console.ReadKey();
        }

        static int somarNumerosAnteriores(int num)
        {
            if (num <= 1) {
                return 1;
            }
            else
            {
                return somarNumerosAnteriores(num - 1) + num;
            }
        }

        static int encontrarMenorValor(int ultiPos, int[] vetor)
        {
            if(ultiPos == 0)
            {
                return vetor[ultiPos];
            }
            else
            {
                int aux = vetor[ultiPos];
                int menor = encontrarMenorValor(ultiPos - 1, vetor);
                if(aux < menor)
                {
                    menor = aux;
                }
                return menor;
            }
        }
    }
}
