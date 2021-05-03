using System;
using System.Collections.Generic;

namespace InterfacciaPersona {

    interface IUguaglianza { // Interfaccia per controllo uguaglianza
        bool Uguale(Persona p);
    }
    
    class Persona : IUguaglianza, IComparable {
        
        public string Nome { get; set; }    
        public string Cognome { get; set; }

        public Persona(string nome, string cognome) {
            Nome = nome;
            Cognome = cognome;
        }

        public bool Uguale(Persona p) { // Definisce metodo da interfaccia
            if (Cognome == (p as Persona).Cognome)
                if (Cognome == (p as Persona).Cognome)
                    return true;
            
            return false;
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

            List<Persona> p = new List<Persona>(); // Lista di persone
            Persona p1 = new Persona("Simone", "Pagani");
            Persona p2 = new Persona("Lorenzo", "De Paoli");
            
            p.Add(p1);
            p.Add(p2);
            p.Add(new Persona("Nicolò", "Coltro"));
            p.Add(new Persona("Marco", "Sperlinga"));
            p.Add(new Persona("Nadia", "Dotti"));
            p.Add(new Persona("Samuele", "Riva"));

            p.Sort();
            p.ForEach(Console.WriteLine); // Stampa tutta la lista
            Console.WriteLine("\nConfronto: " + p1.Uguale(p2)); // Compara due oggetti
        }
    }
}
