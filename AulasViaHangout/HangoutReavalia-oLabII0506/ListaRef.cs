/*
 * Nome: Lucas Carvalho Corrês
 * Matricula: 469006 2P noite
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangout0506
{
    class ListaRef
    {
        //Classe Aninhada Celula, contem o item (valor) e uma referencia para a proxima celula do tipo celula.
        private class Celula
        {
            public int item;
            public Celula prox;
        }

        //Atributos da classe ListaRef
        private Celula primeiro, ultimo, pos;
        private double soma, tam;
        
        //Operações de manipulação da lista.
        //Construtor padrão, cria a lista vazia
        public ListaRef()
        {
            this.primeiro = new Celula();
            this.pos = this.primeiro;
            this.ultimo = this.primeiro;
            this.primeiro.prox = null;
        }

        //Verifica se a lista esta vazia
        public bool Vazia()
        { 
            return(this.primeiro == this.ultimo);
        }

        public void Imprime()
        {
            Celula aux = this.primeiro.prox;
            while (aux != null)
            {
                Console.Write("{0} ", aux.item.ToString());
                aux = aux.prox;
            }
        }

        //Insere elementos na lista
        private void Insere(int valor)
        {
            this.ultimo.prox = new Celula();
            this.ultimo = this.ultimo.prox;
            this.ultimo.item = valor;
            this.ultimo.prox = null;
        }

        public void InsereOrdemSimples(int valor)
        {
            Celula aux = this.primeiro.prox;
            Celula ant = this.primeiro;

            while(aux != null && valor >= aux.item)
            {
                ant = aux;
                aux = aux.prox;
            }

            Celula NovaCelula = new Celula();
            NovaCelula.item = valor;
            NovaCelula.prox = aux;
            ant.prox = NovaCelula;

            this.soma += valor;
            this.tam++;

            if (aux == null)
            {
                this.ultimo = NovaCelula;
            }

        }


        public int Retira(int valor)
        {
            if (this.Vazia() || valor == null)
            {
                throw new Exception("Erro: Lista vazia ou chave invalida");
            }
            else 
            {
                Celula aux = this.primeiro;
                while (aux.prox != null && !aux.prox.item.Equals(valor))
                {
                    aux = aux.prox;
                }

                if (aux.prox == null)
                {
                    return -1;
                }

                Celula q = aux.prox;
                int item = q.item;
                aux.prox = q.prox;
                this.soma -= item;
                this.tam--;

                if (aux.prox == null)
                {
                    this.ultimo = aux;
                }
                return(item);

            }
        }

        public int retiraPrimeiro()
        {
            if (this.Vazia())
            {
                throw new Exception("Erro:Lista Vazia"); 
            }
            Celula aux = this.primeiro;
            Celula q = aux.prox;
            int item = q.item;

            aux.prox = q.prox;

            if (aux.prox == null)
            {
                this.ultimo = aux;
            }
            return(item);
        }

        public int Pesquisa(int valor)
        {
            if (this.Vazia() || valor == null)
            {
                return (-1);
            }

            Celula aux = this.primeiro;

            while(aux.prox != null)
            {
                if (aux.prox.item.Equals(valor))
                { 
                    return(aux.prox.item);
                }

                aux = aux.prox;
            }
            return(-1);
        }

        public int Primeiro()
        {
            this.pos = primeiro;
            return(Proximo());
        }

        public int Proximo()
        {
            this.pos = this.pos.prox;
            if (this.pos == null)
            {
                return (-1);
            }
            else
            {
                return this.pos.item;
            }
        }

        public int ContaImpar()
        {
            Celula aux = this.primeiro.prox;
            int cont = 0;

            while(aux != null)
            {
                if ((aux.item % 2) != 0)
                {
                    cont++;
                }
                aux = aux.prox;
            }

            return(cont);
        }

        public int ContaImparRecu()
        { 
            return(this.ContaImparRecu(this.primeiro.prox, 0));
        }

        private int ContaImparRecu(Celula obj, int cont = 0)
        {
            if (obj == null)
            {
                return (cont);
            }
            else if ((obj.item % 2) != 0)
            {
                return (ContaImparRecu(obj.prox, ++cont));
            }

            return (ContaImparRecu(obj.prox, cont));
        }

        public int ContaAcimaMedia()
        {
            double media = this.soma / this.tam;
            return (this.ContaAcimaMedia(this.primeiro.prox, 0, media));
        }

        private int ContaAcimaMedia(Celula obj, int cont, double media)
        {
            if (obj == null)
            {
                return (cont);
            }
            else if (obj.item>media)
            {
                return (ContaAcimaMedia(obj.prox, ++cont, media));
            }

            return (ContaAcimaMedia(obj.prox, cont, media));
        }

    }
}
