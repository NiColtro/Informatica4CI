using System;
using System.Collections.Generic;

namespace CompagniaNavale
{

    class IndirizzoResidenza {
        private string via, citta, provincia;
        private int civico, cap;
        
        public IndirizzoResidenza(string via, string citta, string provincia, int civico, int cap) {
            this.via = via;
            this.citta = citta;
            this.provincia = provincia;
            this.civico = civico;
            this.cap = cap;
        }
    }

    class Biglietto {
        private int id;
        private string nome, cognome;
        private DateTime dataEmissione;
        private IndirizzoResidenza indirizzo;

        public string Nome => nome;
        public string Cognome => cognome;

        public Biglietto(int id, string nome, string cognome, IndirizzoResidenza indirizzo) {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.indirizzo = indirizzo;

            dataEmissione = DateTime.Today;
        }

        public void printInfo() {
            Console.WriteLine("Biglietto #" + id + "\n" + nome + " " + cognome + "\nEmesso il " + dataEmissione.Day + "/" + dataEmissione.Month + "/" + dataEmissione.Year + "\n");
        }
    }

    class Program {
        static void Main(string[] args) {
            
            string menu, nome, cognome, via, citta, provincia, civico, cap;
            List<Biglietto> biglietti = new List<Biglietto>();

            do {
                Console.Write("\n\n1) Inserisci biglietto;\n2) Stampa tutti i biglietti;\n3) Ricerca biglietto;\n4) Ordina;\n5) Esci.\nCosa vuoi fare? ");
                menu = Console.ReadLine();

                switch (menu) {
                    case "1":
                        Console.Write("\n-- EMISSIONE BIGLIETTO --\nNome: ");
                        nome = Console.ReadLine();
                        Console.Write("Cognome: ");
                        cognome = Console.ReadLine();
                        Console.Write("Via: ");
                        via = Console.ReadLine();
                        Console.Write("Città: ");
                        citta = Console.ReadLine();
                        Console.Write("Provincia: ");
                        provincia = Console.ReadLine();
                        Console.Write("Civico: ");
                        civico = Console.ReadLine();
                        Console.Write("CAP: ");
                        cap = Console.ReadLine();
                        
                        biglietti.Add(new Biglietto(biglietti.Count, nome, cognome, new IndirizzoResidenza(via, citta, provincia, Int32.Parse(civico), Int32.Parse(cap))));
                        break;
                    
                    case "2":
                        Console.WriteLine("\n-- LISTA PASSEGGERI --\n");
                        biglietti.ForEach(c => c.printInfo());
                        break;
                    
                    case "3":
                        Console.WriteLine("\n-- RICERCA BIGLIETTI --\nInserisci la query per la ricerca: ");
                        cognome = Console.ReadLine();
                        biglietti.FindAll(c => (c.Cognome == cognome)).ForEach(c => c.printInfo());
                        break;
                    
                    case "4":
                        Console.WriteLine("-- ORDINA LISTA --\nOrdino la lista per Cognome.");
                        
                        biglietti.Sort((x, y) =>
                        {
                            if (x.Cognome.CompareTo(y.Cognome) == 0)
                                return x.Nome.CompareTo(y.Nome);
                            else
                                return x.Cognome.CompareTo(y.Cognome);
                        });
                        break;
                    
                    case "5":
                        Console.WriteLine("\nUscita.");
                        break;
                    
                    default:
                        Console.WriteLine("\nMetodo non riconosciuto.");
                        break;
                }
                
            } while (menu != "5");
        }
    }
}