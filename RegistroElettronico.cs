using System;
using System.Collections.Generic;

namespace RegistroElettronico {

    class Studente {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Studente(string nome, string cognome) {
            Nome = nome;
            Cognome = cognome;
        }
    }
    
    abstract class Valutazione {

        public double Voto { get; set; }
        public string Materia { get; set; }
        public Studente Studente { get; set; }

        protected Valutazione(double voto, Studente studente, string materia) {
            Voto = voto;
            Studente = studente;
            Materia = materia;
        }
    }

    sealed class ProvaScritta : Valutazione {
        
        public int NumeroQuesiti { get; set; }
        public int NumeroQuesitiCorretti { get; set; }

        public ProvaScritta(double voto, Studente studente, string materia, int numeroQuesiti, int numeroQuesitiCorretti) : base(voto, studente, materia) {
            NumeroQuesiti = numeroQuesiti;
            NumeroQuesitiCorretti = numeroQuesitiCorretti;
        }
    }

    sealed class Interrogazione : Valutazione {
        
        public int Durata { get; set; }

        public Interrogazione(double voto, Studente studente, string materia, int durata) : base(voto, studente, materia) {
            Durata = durata;
        }
    }

    sealed class Registro {

        private List<Valutazione> valutazioni;
        
        private Valutazione[] arrayTest;

        public Registro() {
            valutazioni = new List<Valutazione>();
        }

        public void aggiungiVoto(Valutazione v) {
            valutazioni.Add(v);
        }

        public void ordinaPerVoti() {
            valutazioni.Sort((x, y) => x.Voto.CompareTo(y.Voto));
        }

        public Valutazione[] insufficienti() {
            return valutazioni.FindAll(x => x.Voto < 6).ToArray();
        }
    }

    class Program {
        static void Main(string[] args) {

            Studente s = new Studente("Nicolò", "Coltro");

            ProvaScritta p1 = new ProvaScritta(8, s, "Informatica", 10, 8);
            Interrogazione i = new Interrogazione(6, s, "Italiano", 25);
            
            Console.WriteLine("Hello World!");
        }
    }
}