/*

	Sviluppa un programma che permetta la gestione dei contatti
	in una rubrica. Implementa la ricerca del contatto per nome
	e numero di telefono.
	
*/

using System;

namespace Rubrica
{
    class Contatto {
        int id;
        String nome, cognome;
        double numeroTelefonico;

        public Contatto(int id, String nome, String cognome, double numeroTelefonico) {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.numeroTelefonico = numeroTelefonico;
        }

        public int getId() {
            return id;
        }

        public String getNome() {
            return nome;
        }
        
        public String getCognome() {
            return cognome;
        }

        public double getNumero() {
            return numeroTelefonico;
        }
    }

    class Rubrica {
        Contatto[] contatti = new Contatto[100];
        int contaContatti = 0;

        public void inserisciContatto(String nome, String cognome, double numeroTelefonico)
        {
            if (numeroTelefonico.ToString().Length == 10) {
                contatti[contaContatti] = new Contatto(contaContatti, nome, cognome, numeroTelefonico);
                contaContatti++;
                Console.WriteLine("[!] Contatto inserito con successo.\n");
            } else Console.WriteLine("[!] Il formato del numero è errato.");
        }

        public void cercaNome(String nome) {
            bool trovato = false;

            for (int i = 0; i < contaContatti; i++) {
                if (contatti[i].getNome() == nome || contatti[i].getCognome() == nome) {
                    Console.WriteLine("┌ Contatto #" + contatti[i].getId() + "\n├ Nome: " + contatti[i].getNome() + "\n├ Cognome: " + contatti[i].getCognome() + "\n└ Numero di telefono: " + contatti[i].getNumero() + "\n");
                    trovato = true;
                }
            }

            if (!trovato)
                Console.WriteLine("[!] Nessun contatto trovato dalla ricerca per nome \"" + nome + "\".");
        }
        
        public void cercaNumero(double numeroTelefonico) {
            bool trovato = false;

            for (int i = 0; i < contaContatti; i++) {
                if (contatti[i].getNumero() == numeroTelefonico) {
                    Console.WriteLine("┌ Contatto #" + contatti[i].getId() + "\n├ Nome: " + contatti[i].getNome() + "\n├ Cognome: " + contatti[i].getCognome() + "\n└ Numero di telefono: " + contatti[i].getNumero() + "\n");
                    trovato = true;
                }
            }

            if (!trovato)
                Console.WriteLine("[!] Nessun contatto trovato dalla ricerca per numero telefonico \"" + numeroTelefonico + "\".");
        }
    }

    class Program {
        static void Main(string[] args) {
            Rubrica rubrica = new Rubrica();

            rubrica.inserisciContatto("NomeA", "CognomeA", 1000000000);
            rubrica.inserisciContatto("NomeB", "CognomeB", 2000000000);
            rubrica.inserisciContatto("NomeC", "CognomeC", 3000000000);

            rubrica.cercaNome("NomeB");
            rubrica.cercaNumero(4000000000);
        }
    }
}