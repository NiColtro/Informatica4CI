/*

	Gestisci un Giornale composto da un array di Pagine. Implementa
	la ricerca della pagina più lunga e del totale di parole.

*/

using System;

namespace Giornale
{
    class Pagina {
        int numeroPagina, numeroParole, numeroRighe;

        int calcolaRighe() {
            return numeroParole / 20;
        }

        public Pagina(int numeroPagina, int numeroParole) {
            this.numeroPagina = numeroPagina;
            this.numeroParole = numeroParole;
            numeroRighe = calcolaRighe();
        }

        public int getNumeroPagina() {
            return numeroPagina;
        }
        
        public int getNumeroParole() {
            return numeroParole;
        }
        
        public int getNumeroRighe() {
            return numeroRighe;
        }
    }

    class Giornale {
        Pagina[] pagine = new Pagina[20];
        int numeroPagine;

        public Giornale() {
            numeroPagine = 0;
        }

        public void aggiungiPagina(int numeroParole) {
            pagine[numeroPagine] = new Pagina(numeroPagine, numeroParole);
            numeroPagine++;
        }

        public int totaleParole() {
            int paroleTotali = 0;
            
            for (int i = 0; i < numeroPagine; i++) {
                paroleTotali += pagine[i].getNumeroParole();
            }

            return paroleTotali;
        }
        
        public Pagina paginaPiuLunga() {
            int maxPag = 0, maxRighe = 0;
            
            for (int i = 0; i < numeroPagine; i++) {
                if (maxRighe < pagine[i].getNumeroRighe()) {
                    maxPag = pagine[i].getNumeroPagina();
                    maxRighe = pagine[i].getNumeroRighe();
                }
            }

            return pagine[maxPag];
        }

    }

    class Program {
        static void Main(string[] args) {
            Giornale giornale = new Giornale();
            
            giornale.aggiungiPagina(32);
            giornale.aggiungiPagina(18);
            giornale.aggiungiPagina(10);
            giornale.aggiungiPagina(50);
            
            Console.WriteLine(giornale.totaleParole());
            Console.WriteLine(giornale.paginaPiuLunga().getNumeroParole());
        }
    }
}