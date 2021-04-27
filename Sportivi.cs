using System;
using System.Collections.Generic;

namespace Sportivi {

    enum Sport {
        Calcio, Basket, Scherma, Tennis, Pallavolo, Ciclismo, Nuoto
    }

    abstract class Sportivo {
        
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoNascita { get; set; }
        public Sport Sport { get; set; }
        
        protected Sportivo(string nome, string cognome, int annoNascita, Sport sport) {
            Nome = nome;
            Cognome = cognome;
            AnnoNascita = annoNascita;
            Sport = sport;
        }

        public abstract bool Anzianita();

        public override string ToString() {
            return Nome + " " + Cognome + "\nNato nel " + AnnoNascita + "\nPraticante lo sport " + Sport + "\n";
        }

        public abstract int calcolaStipendio();
    }

    class Professionista : Sportivo {
        
        public string SocietaSportiva { get; set; }

        public Professionista(string nome, string cognome, int annoNascita, Sport sport, string societaSportiva) : base(nome, cognome, annoNascita, sport) {
            SocietaSportiva = societaSportiva;
        }

        public override string ToString() {
            return base.ToString() + "Tipo: Professionista\nSocietà sportiva: " + SocietaSportiva + "\n";
        }

        public override bool Anzianita() {
            if (2021 - AnnoNascita >= 36)
                return true;
            else
                return false;
        }

        public override int calcolaStipendio() {
            if (Anzianita())
                return 1500 * AnnoNascita; // Anziano
            else
                return 1000 * AnnoNascita; // Non anziano
        }
    }

    class Dilettante : Sportivo {
        
        public int Premi { get; set; }

        public Dilettante(string nome, string cognome, int annoNascita, Sport sport, int premi) : base(nome, cognome, annoNascita, sport) {
            Premi = premi;
        }

        public override string ToString() {
            return base.ToString() + "Tipo: Dilettante\nPremi vinti: " + Premi + "\n";
        }

        public override bool Anzianita() {
            return false;
        }

        public override int calcolaStipendio() {
            return 0;
        }
    }

    class Program {
        static void Main(string[] args) {

            List<Sportivo> sportivi = new List<Sportivo>();
            
            sportivi.Add(new Dilettante("Nicolò", "Coltro", 2003, Sport.Basket, 10));
            sportivi.Add(new Professionista("Nadia", "Dotti", 2002, Sport.Nuoto, "SocietaA"));
            sportivi.Add(new Professionista("Lorenzo", "De Paoli", 2003, Sport.Pallavolo, "SocietaB"));
            
            // Stampa tutta la lista
            Console.WriteLine("\n\nTUTTI GLI SPORTIVI\n");
            sportivi.ForEach(Console.WriteLine);
            
            // Stampa i dilettanti con premi > 5
            Console.WriteLine("\n\nDILETTANTI CON PREMI > 5\n");
            sportivi.FindAll(x => x.GetType() == typeof(Dilettante) && (x as Dilettante).Premi > 5).ForEach(Console.WriteLine);

        }
    }
}