/*
	
	Gestisci un Ristorante, caratterizzato dalla presenta di N
	tavoli e relativi menu. Permetti l'ordine delle portate e il
	calcolo dello scontrino.

*/

using System;

namespace Ristorante
{
    class Program
    {
        static void wait() { // Conferma per ritorno al menu
            Console.WriteLine("\nPremi invio per tornare al menu.");
            Console.ReadKey();
            Console.Clear();
        }
        
        static void Main(string[] args) {
            Tavolo tavolo = new Tavolo(0, 2); // Istanzia un nuovo tavolo con ID 0 e 2 posti a sedere
            Menu menu = new Menu(); // Istanzia un nuovo menu
            
            int selezione;
            int input;

            do {
                
                Console.WriteLine("1) Apri il menu dei cibi;\n2) Apri il menu delle bevande;\n3) Richiedi il conto;\n4) Esci.\nCosa vuoi fare?");
                selezione = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (selezione) {
                    
                    case 1:
                        menu.mostraPiatti();
                        Console.Write("\n\nInserisci l'ID del piatto che vuoi ordinare: ");
                        input = int.Parse(Console.ReadLine());
                        tavolo.aggiungiCibo(menu.getPiatto(input));
                        break;
                    
                    case 2:
                        menu.mostraBevande();
                        Console.Write("\n\nInserisci l'ID della bevanda che vuoi ordinare: ");
                        input = int.Parse(Console.ReadLine());
                        tavolo.aggiungiCibo(menu.getBevanda(input));
                        break;
                    case 3:
                        Console.WriteLine("Il conto ammonta a " + tavolo.conto() + " euro.");
                        tavolo.printConsumazioni();
                        wait();
                        break;
                    
                }
                
            } while (selezione != 4);
        }
    }
}
