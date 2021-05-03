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
    
    class Esterno : Pianta, IPrezzo {
        
        public int Altezza { get; set; }

        public Esterno(string nome, int altezza) : base(nome) {
            Altezza = altezza;
        }

        public double CalcolaPrezzo() {
            return 0.5 * Altezza;
        }
    }
    
    class Interno : Pianta, IPrezzo {
        
        public bool Fiori { get; set; }

        public Interno(string nome, bool fiori) : base(nome) {
            Fiori = fiori;
        }

        public double CalcolaPrezzo() {
            if (Fiori)
                return 10;
            return 5;
        }
    }
    
    class Program {
        static void Main(string[] args) {
            List<Pianta> piante = new List<Pianta>();
            
            // Add lista
            
        }
    }
}
