using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace provaespecial
{
    class ArvoreBinaria
    {
        private class No
        {
            public Func reg;
            public No esq, dir;
        }
        private No raiz;

        public void imprimirMaiorMenor() 
        {
            if (raiz == null) {
                Console.WriteLine("Arvore Vazia!");
            }
            else 
            {
                imprimirMaiorMenor(raiz);
            }
        
        }

        private void imprimirMaiorMenor(No p)
        {
            if(p != null)
            {
                imprimirMaiorMenor(p.dir);
                Console.Write("{0} - ", p.reg.CPF);
                imprimirMaiorMenor(p.esq);
            }
        }


		public void imprime ( )
		{
			imprime (raiz);
		}

		private void imprime (No p)
		{
			if (p != null) {
				imprime (p.esq);
				Console.WriteLine (p.reg.CPF);
				imprime (p.dir);
			}
		}

        private Func pesquisa(Func reg, No p)
        {
            if (p == null) return null; //reg.CPFistro não econtrado
            else if (reg.CPF < p.reg.CPF)
                return pesquisa(reg, p.esq);
            else if (reg.CPF > p.reg.CPF)
                return pesquisa(reg, p.dir);
            else return p.reg;
        }

        private No insere(Func reg, No p)
        {
            if (p == null)
            {
                p = new No(); p.reg = reg;
                p.esq = null; p.dir = null;
            }

            else if (reg.CPF < p.reg.CPF) p.esq = insere(reg, p.esq);
            else if (reg.CPF > p.reg.CPF) p.dir = insere(reg, p.dir);
            else Console.WriteLine("Erro: reg.CPFistro ja existente");

            return p;
        }

        private No antecessor(No q, No r)
        {
            if (r.dir != null) r.dir = antecessor(q, r.dir);
            else { q.reg.CPF = r.reg.CPF; r = r.esq; }
            return r;
        }

        private No retira(Func reg, No p)
        {
            if (p == null) Console.WriteLine("Erro: reg.CPFistro nao encontrado");
            else if (reg.CPF < p.reg.CPF) p.esq = retira(reg, p.esq);
            else if (reg.CPF > p.reg.CPF) p.dir = retira(reg, p.dir);
            else
            {
                if (p.dir == null) p = p.esq;
                else if (p.esq == null) p = p.dir;
                else p.esq = antecessor(p, p.esq);
            }
            return p;
        }

        public ArvoreBinaria()
        {
            this.raiz = null;
        }

        public Func pesquisa(Func reg)
        {
            return this.pesquisa(reg, this.raiz);
        }

        public void insere(Func reg)
        {
            this.raiz = this.insere(reg, this.raiz);
        }

        public void retira(Func reg)
        {
            this.raiz = this.retira(reg, this.raiz);
        }

    }
}
