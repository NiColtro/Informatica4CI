using System;
using System.Collections.Generic;

/*
    
	Realizzare un programma per la gestione di una nave porta container. La nave è
	caratterizzata da un nome e una destinazione. La nave è in grado di caricare 100
	container ciascuno caratterizzato da un codice, dal nome del proprietario. Ciascun
	container può contenere 3 bancali caratterizzati da un codice e una descrizione. Il
	programma deve prevedere le seguenti operazioni:
	a. Carico dei bancali nel container.
	b. Carico dei container sulla nave
	c. Dato il codice di un container stampare il codice e la descrizione dei bancali contenuti.
	d. Dato il nome di un proprietario visualizzare i codici dei container di sua proprietà

*/

namespace NaveContainerList
{

    class Bancale {
        private int id;
        private string descrizione;

        public int Id => id;

        public Bancale(int id, string descrizione) {
            this.id = id;
            this.descrizione = descrizione;
        }

        public void infoBancale() {
            Console.WriteLine("Container #" + id + "\nDescrizione: " + descrizione + "\n");
        }
    }

    class Container {
        private int id;
        private string proprietario;
        private List<Bancale> bancali;

        public List<Bancale> Bancali => bancali;
        public string Proprietario => proprietario;

        public Container(int id, string proprietario) {
            this.id = id;
            this.proprietario = proprietario;
            bancali = new List<Bancale>();
        }

        public void aggiungiBancale(Bancale b) {
            bancali.Add(b);
        }

        public void infoContainer() {
            Console.WriteLine("Container #" + id + "\nProprietario: " + proprietario + "\n");
        }
    }

    class Nave {
        private string destinazione;
        private List<Container> containers;

        public Nave(string destinazione) {
            this.destinazione = destinazione;
            containers = new List<Container>();
        }

        public void aggiungiContainer(Container c) {
            containers.Add(c);
        }

        public void cercaContainer(int id) {
            Console.WriteLine("Cerco Container con Id " + id);
            containers.ForEach(x => x.Bancali.Find(x => x.Id == id).infoBancale());
        }
        
        public void cercaProprietario(string proprietario) {
            Console.WriteLine("Cerco Container con Proprietario " + proprietario);
            containers.Find(x => x.Proprietario == proprietario).infoContainer();
        }
    }

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }
}