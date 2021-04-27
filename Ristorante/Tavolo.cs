using System;
using System.Collections.Generic;
using System.Text;

namespace Ristorante
{
    public class Tavolo {
        
        int id, nCoperti, numeroConsumazioni;
        double saldo;
        Consumazione[] consumazioni = new Consumazione[100];

        public Tavolo(int id, int nCoperti) {
            this.id = id;
            this.nCoperti = nCoperti;
            saldo = 0;
            numeroConsumazioni = 0;
        }

        public void aggiungiCibo(Consumazione consumazione) { // Aggiunge una nuova consumazione all'array di consumazioni
            consumazioni[numeroConsumazioni] = new Consumazione(consumazione);
            numeroConsumazioni++;
            saldo += consumazione.getPrezzo();
        }

        public double conto() { // Restituisce il saldo del tavolo
            saldo = 0;
            for (int i = 0; i < numeroConsumazioni; i++) {
                saldo += consumazioni[i].getPrezzo();
            }
            return saldo;
        }
        
        public void printConsumazioni() { // Restituisce il saldo del tavolo
            Console.WriteLine("Elenco delle consumazioni: ");
            for (int i = 0; i < numeroConsumazioni; i++) {
                Console.Write(consumazioni[i].getNome() + ", ");
            }
        }
    }
}
