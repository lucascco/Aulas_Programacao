using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangout0506
{
    class Program
    {

        static ArvoreBinaria LerArquivo()
        {
            string path = "alunos.txt";
            StreamReader str = new StreamReader(path);
            ArvoreBinaria av = new ArvoreBinaria();

            string linha = str.ReadLine();
            while (linha != null)
            {

                string[] atributos = linha.Split(',');
                Aluno obj = new Aluno(int.Parse(atributos[0]), atributos[1], double.Parse(atributos[2]));
                av.inserir(obj);
                linha = str.ReadLine();
            }

            str.Close();

            return(av);

        }

        static void Main(string[] args)
        {
            /*Arovre
             * 
            ArvoreBinaria avMain = LerArquivo();
            Console.WriteLine(avMain.obterAltura());
            */

            /*Lista
             * 
            Random rd = new Random();
            ListaRef lista = new ListaRef();
            for (int i = 0; i < 10; i++)
            {
                lista.InsereOrdemSimples(rd.Next(0, 100));
            }
            lista.Imprime();
            
            Console.WriteLine("\nContador "+lista.ContaImparRecu());
            Console.WriteLine("Contador Acima Media " + lista.ContaAcimaMedia());
            */


            /*Palíndromo
             * 
            Pilha p = new Pilha();
            string palavra = "carro";

            char c = palavra[0];
            bool palin = true;

            for (int i = 0; i < palavra.Length; i++)
            {
                p.Empilha(palavra[i]);
            }

            for (int i = 0; i < palavra.Length; i++)
            {
                if (p.Desempilha() != palavra[i])
                {
                    palin = false;
                    break;
                }
            }

            Console.WriteLine("Palindromo: "+palin);
            */





        }
    }
}
