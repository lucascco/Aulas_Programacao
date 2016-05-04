//Aluno: Lucas Carvalho Corrêa / Matr. 469006 / PUC Minas São Gabriel - Noite SI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangout0506
{
    class Pilha
    {
        class Celula
        {
            public char item;
            public Celula prox;
        }

        private Celula topo, aux;
        private int qtdItem;

        //Retorna a quantidade de item da pilha.
        public int QtdItem
        {
            get { return (qtdItem); }
        }

        //Construtor padrão da pilha q recebe o nome como atributo obrigatorio.
        public Pilha()
        {
            topo = new Celula();
            topo.item = ' ';
            topo.prox = null;
            qtdItem = 0;
        }

        public bool Vazia()
        {
            return (qtdItem == 0);
        }
        
        public void Empilha(char valor)
        {
            //Testa se é o primeiro item a ser inserido da pilha
            if (this.Vazia())
            {
                topo.item = valor; //topo recebe o item;
                qtdItem++;
                Console.WriteLine("\nObjeto {0} empilhado com exito!", valor);
            }
            else //Tratamento especial quando é a segunda ou as proximas inserções  
            {
                //Instancia uma nova celula
                Celula NovaCel = new Celula();
                NovaCel.item = valor; //Recebe o item
                NovaCel.prox = topo; //o antigo topo fica sendo o anterior ao novo topo
                topo = NovaCel; // o topo recebe o objeto
                qtdItem++; //a quantidade de item ganha mais um.
                Console.WriteLine("\nObjeto {0} empilhado com exito!", valor);
            }

        }

        public char Desempilha()
        {
            if (this.Vazia())
            {
                throw new Exception("A Lista esta vazia!");
            }
            else
            {
                aux = topo; //a variavel auxiliar recebe o topo.
                topo = topo.prox; // o topo recebe o seu anterior
                qtdItem--;//Decrescenta 1 da quantidade de item.
                return (aux.item); // Retorna o item que era o topo (que foi desempilhado)
            }
        }

        public void PecorrerPilha() // Pecorre todos os elementos da pilha.
        {
            if (this.Vazia())
            {
                throw new Exception("A Lista esta vazia!");
            }
            else
            {
                aux = topo; // variavel auxila do tipo celula recebe o topo
                while (aux != null) // quando o aux for null, chegou no final da pilha
                {
                    Console.Write("\n-{0}", aux.item); // Imprime os itens da pilha
                    aux = aux.prox;
                }
            }
        }

        public void ZeraPilha()
        {
            while (qtdItem > 0)
            {
                this.Desempilha();
            }
        }
    }
}
