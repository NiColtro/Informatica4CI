/*

	Gestisci una rivista, composta da un array di Articoli.
	Permetti l'aggiunta di articoli ed il calcolo del costo
	totale (+ articolo più costoso).

*/

using System;
using System.Collections.Generic;

namespace Rivista {
    class Articolo {
        private String titolo, autore;
        private int numeroPagine;
        private double costo;
            public double Costo { get => costo; }

        private double calcolaCosto() {
            return numeroPagine * 0.10;
        }
        
        public Articolo(string titolo, string autore, int numeroPagine) {
            this.titolo = titolo;
            this.autore = autore;
            this.numeroPagine = numeroPagine;
            costo = calcolaCosto();
        }
    }

    class Rivista {
        private String nome;
            public String Nome { get => nome; }
        private int numeroArticoli;
        private Articolo[] articoli = new Articolo[30];

        public Rivista(String nome) {
            numeroArticoli = 0;
            this.nome = nome;
        }
        
        public bool aggiungiArticolo(Articolo articolo) {
            if (numeroArticoli < 30) {
                articoli[numeroArticoli] = articolo;
                numeroArticoli++;
                return true;
            } else return false;
        }

        public double costoRivista() {
            double costo = 0;
            
            for (int i=0; i<numeroArticoli; i++)
                costo += articoli[i].Costo;

            return costo;
        }
        
        public Articolo articoloPiuCostoso() {
            double costoMax = 0;
            int idMax = 0;

            for (int i = 0; i < numeroArticoli; i++) {
                if (articoli[i].Costo > costoMax) {
                    costoMax = articoli[i].Costo;
                    idMax = i;
                }
            }

            return articoli[idMax];
        }
    }
    
    class Program {
        static void Main(string[] args)
        {
       
            Articolo articolo0 = new Articolo("Titolo0", "Autore0", 80); // Istanzia Articolo0
            Articolo articolo1 = new Articolo("Titolo1", "Autore1", 100); // Istanzia Articolo1

            Rivista rivista = new Rivista("NomeRivista"); // Istanzia Rivista
            rivista.aggiungiArticolo(articolo0); // Aggiunge Articolo0 alla Rivista
            rivista.aggiungiArticolo(articolo1); // Aggiunge Articolo1 alla Rivista
            
            Console.WriteLine("La rivista " + rivista.Nome + " costa " + rivista.costoRivista() + " euro.");
            Console.WriteLine("L'articolo più costoso della rivista " + rivista.Nome + " costa " + rivista.articoloPiuCostoso().Costo + " euro.");
        }
    }
}