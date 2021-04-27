using System;
using System.Collections.Generic;
using System.Text;

namespace Ristorante
{
    public class Menu {
        
        Consumazione[] Piatti = new Consumazione[100]; // Array menu per i piatti
        Consumazione[] Bevande = new Consumazione[100]; // Array menu per le bevande

        public Menu() { // Popola il menu con dei cibi e bevande creati in modo randomico
            Random rnd = new Random();

            for (int i = 0; i < 100; i++) {
                Piatti[i] = new Consumazione(i, "Piatto-" + i, rnd.Next(10, 25));
                Bevande[i] = new Consumazione(i, "Bevanda-" + i, rnd.Next(1, 10));
            }
        }

        public Consumazione getPiatto(int i) { // Seleziona piatto dal menu tramite ID
            return Piatti[i];
        }

        public Consumazione getPiatto(String nome) { // Seleziona piatto dal menu tramite Nome
            foreach (Consumazione cons in Piatti) {
                if (cons.getNome() == nome)
                    return cons;
            }
            return null;
        }

        public Consumazione getBevanda(int i) { // Seleziona bevanda dal menu tramite ID
            return Bevande[i];
        }

        public Consumazione getBevanda(String nome) { // Seleziona bevanda dal menu tramite Nome
            foreach (Consumazione cons in Bevande) {
                if (cons.getNome() == nome)
                    return cons;
            }

            return null;
        }

        public void mostraPiatti() { // Printa tutti i piatti
            Console.WriteLine("\nMENU PIATTI:");
            Console.WriteLine("Nome: \t\tPrezzo:");
            foreach (Consumazione cons in Piatti) {
                Console.WriteLine(cons.getNome() + "\t" + cons.getPrezzo() + " euro");
            }
        }

        public void mostraBevande() { // Printa tutte le bevande
            Console.WriteLine("\nMENU BEVANDE:");
            Console.WriteLine("Nome: \t\tPrezzo:");
            foreach (Consumazione cons in Bevande) {
                Console.WriteLine(cons.getNome() + "\t" + cons.getPrezzo() + " euro");
            } 
        }
    }
}
