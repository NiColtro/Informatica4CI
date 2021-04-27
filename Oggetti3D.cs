using System;

/*
    creare una classe astratta oggetto 3d e le classi derivate:
    -Cilindro
    -Sfera
    -Parallelepipedo

    delegare i metodi comuni come il calcolo del volume e la stampa delle caratteristiche alla classe astratta
    il nome dell'oggetto va conservato nella classe Oggetto3d
    prevedere anche all'interno delle classi un metodo per il confronto di due oggetti 
    es
        sfera1.confronta(sfera3) => bool
*/

namespace Oggetti3D {

    abstract class Oggetto3D {
        private string Nome { get; set; } // Nome del solido

        public Oggetto3D(string nome) { // Costruttore
            Nome = nome;
        }

        public virtual double calcVolume() { // Funzione per il calcolo del volume
            return 0;
        }
        
        public override string ToString() {
            return "Informazioni del solido " + Nome + "\n";
        }
        
        public bool confronta(Oggetto3D daConfrontare) {
            if (GetType() == daConfrontare.GetType())
                return Equals(daConfrontare);
            else
                return false;
        }
    }

    class Parallelepipedo : Oggetto3D {
        
        public int Base { get; set; }
        public int Altezza { get; set; }
        public int Profondita { get; set; }

        public Parallelepipedo(string nome, int @base, int altezza, int profondita) : base(nome) {
            Base = @base;
            Altezza = altezza;
            Profondita = profondita;
        }

        public override double calcVolume() {
            return Base * Altezza * Profondita;
        }

        public override string ToString() {
            return base.ToString() + "Volume: " + calcVolume();
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Parallelepipedo parallelepipedoDiTest = new Parallelepipedo("Parallelep test 1", 2, 3, 5);
            Console.WriteLine(parallelepipedoDiTest);

            // parallelepipedoDiTest.confronta(Oggetto Da Confrontare);
        }
    }
}