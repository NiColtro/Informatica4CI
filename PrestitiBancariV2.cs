using System;
using System.Collections.Generic;

namespace PrestitiBancari {

    class Prestito {
        private double ammontare, rata;
        private DateTime dataInizio, dataFine;

        public double Ammontare => ammontare;

        public Prestito(double ammontare, double rata, DateTime dataInizio, DateTime dataFine) {
            this.ammontare = ammontare;
            this.rata = rata;
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
        }
    }

    class Cliente {
        private string nome, cognome, codiceFiscale;
        private List<Prestito> prestiti;

        public string CodiceFiscale => codiceFiscale;
        public List<Prestito> Prestiti => prestiti;

        public Cliente(string nome, string cognome, string codiceFiscale) {
            this.nome = nome;
            this.cognome = cognome;
            this.codiceFiscale = codiceFiscale;
            prestiti = new List<Prestito>();
        }

        public void aggiungiPrestito(Prestito p) {
            prestiti.Add(p);
        }
    }

    class Banca {
        private string nome;
        private List<Cliente> clienti;

        public Banca(string nome) {
            this.nome = nome;
            clienti = new List<Cliente>();
        }

        public void aggiungiCliente(Cliente c) {
            clienti.Add(c);
        }
        
        public void rimuoviCliente(Cliente c) {
            clienti.Remove(c);
        }

        public void modificaCliente(Cliente cOld, Cliente cNew) {
            clienti.Remove(cOld);
            clienti.Add(cNew);
        }

        public void aggiungiPrestito(string codiceFiscale, Prestito p) {
            if (clienti.Find(x => x.CodiceFiscale == codiceFiscale) == null)
                return;
            
            clienti.Find(x => x.CodiceFiscale == codiceFiscale).aggiungiPrestito(p);
        }

        public double totalePrestiti(string codiceFiscale) {
            double somma = 0;

            if (clienti.Find(x => x.CodiceFiscale == codiceFiscale) == null)
                return -1;
            
            clienti.Find(x => x.CodiceFiscale == codiceFiscale).Prestiti.ForEach(x => somma += x.Ammontare);
            return somma;
        }

        public List<Prestito> listaPrestiti(string codiceFiscale) {
            if (clienti.Find(x => x.CodiceFiscale == codiceFiscale) == null)
                return null;
            
            return clienti.Find(x => x.CodiceFiscale == codiceFiscale).Prestiti;
        }
        
        public void prospettoBanca() {
            clienti.ForEach(x => Console.WriteLine("Cliente: " + x.CodiceFiscale));
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Banca banca = new Banca("NomeBanca"); // Istanzio Banca
            banca.aggiungiCliente(new Cliente("NomeA", "CognomeA", "CFA")); // Creo ClienteA
            banca.aggiungiCliente(new Cliente("NomeB", "CognomeB", "CFB")); // Creo ClienteB
            
            banca.aggiungiPrestito("CFA", new Prestito(100, 100, DateTime.Now, DateTime.Now)); // Nuovo prestito di 100??? a ClienteA

            banca.listaPrestiti("CFA").ForEach(x => Console.WriteLine("> " + x.Ammontare + " euro")); // Stampa tutti i prestiti di ClienteA da CF = "CFA"
        }
    }
}