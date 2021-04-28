using System;
using System.Collections.Generic;

namespace InterfacciaPersona {
    
    class Persona : IComparable {
        
        public string Nome { get; set; }    
        public string Cognome { get; set; }

        public Persona(string nome, string cognome) {
            Nome = nome;
            Cognome = cognome;
        }

        public int CompareTo(object obj) {
            if (Cognome.CompareTo((obj as Persona).Cognome) != 0)
                return Cognome.CompareTo((obj as Persona).Cognome);

            return Nome.CompareTo((obj as Persona).Nome);
        }

        public override string ToString() {
            return Nome + " " + Cognome;
        }
    }
    
    class Program {
        static void Main(string[] args) {

            List<Persona> p = new List<Persona>();
            p.Add(new Persona("Simone", "Pagani"));
            p.Add(new Persona("Lorenzo", "De Paoli"));
            p.Add(new Persona("Nicolò", "Coltro"));
            p.Add(new Persona("Marco", "Sperlinga"));
            p.Add(new Persona("Nadia", "Dotti"));
            p.Add(new Persona("Samuele", "Riva"));

            p.Sort();
            p.ForEach(Console.WriteLine);
        }
    }
}