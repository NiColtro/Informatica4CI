using System;
using System.Collections.Generic;

namespace EsercizioInterfaccia {

    interface IPrezzo {
        double CalcolaPrezzo();
    }
    
    abstract class Pianta {
        
        public string Nome { get; set; }

        protected Pianta(string nome) {
            Nome = nome;
        }
    }
    
    class Esterno : Pianta, IPrezzo, IComparable {
        
        public int Altezza { get; set; }

        public Esterno(string nome, int altezza) : base(nome) {
            Altezza = altezza;
        }

        public double CalcolaPrezzo() {
            return 0.5 * Altezza;
        }
        
        public int CompareTo(Object o) {
            
            double prezzo;
            if (o.GetType() == typeof(Interno))
                prezzo = (o as Interno).CalcolaPrezzo();
            else
                prezzo = (o as Esterno).CalcolaPrezzo();
            
            if (CalcolaPrezzo() == prezzo)
                return Nome.CompareTo((o as Pianta).Nome);

            return CalcolaPrezzo().CompareTo(prezzo);
        }

        public override string ToString() {
            return "Pianta da Esterno\nNome: " + Nome + "\nPrezzo: " + CalcolaPrezzo() + "\n\n";
        }
    }
    
    class Interno : Pianta, IPrezzo, IComparable {
        
        public bool Fiori { get; set; }

        public Interno(string nome, bool fiori) : base(nome) {
            Fiori = fiori;
        }

        public double CalcolaPrezzo() {
            if (Fiori)
                return 10;
            return 5;
        }
        
        public int CompareTo(Object o) {
            
            double prezzo;
            if (o.GetType() == typeof(Interno))
                prezzo = (o as Interno).CalcolaPrezzo();
            else
                prezzo = (o as Esterno).CalcolaPrezzo();
            
            if (CalcolaPrezzo() == prezzo)
                return Nome.CompareTo((o as Pianta).Nome);

            return CalcolaPrezzo().CompareTo(prezzo);
        }
        
        public override string ToString() {
            return "Pianta da Interno\nNome: " + Nome + "\nPrezzo: " + CalcolaPrezzo() + "\n\n";
        }
    }
    
    class Program {
        static void Main(string[] args) {
            List<Pianta> piante = new List<Pianta>();
            
            piante.Add(new Interno("PiantaA", true));
            piante.Add(new Esterno("PiantaB", 100000));
            
            piante.Sort();
            piante.ForEach(Console.WriteLine);

        }
    }
}
