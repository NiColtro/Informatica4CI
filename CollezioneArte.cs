using System;
using System.Collections.Generic;

/*
 
    Realizza una opportuna gerarchia di classi per modellare una collezione (C)
    identificata da un nome, da un luogo, da un insieme di opere d'arte e dalle
    informazioni relative al loro ingombro. Radice della gerarchia è la classe astratta
    opera d’arte (OD) contenente :
    a. i campi protetti titolo artista
    b. il costruttore
    c. il metodo public abstract double printingombro() che restituisce l'ingombro
    dell'opera
    d. il metodo public boolean equals(Object o) che verifica se due opere d'arte
    sono uguali
    e. ed altri metodi di interesse.
    La sottoclasse quadro (Q) ha due variabili aggiuntive: altezza e larghezza che
    identificano la misura del quadro.
    La sottoclasse scultura (S) ha 3 variabili aggiuntive altezza larghezza e profondità
    che identificano le misure della scultura.
    Implementare le due classi concretizzando il metodo ingombro().
    Realizzare poi, una classe collezione identificata da un nome e da un insieme di
    opere d'arte scrivere i seguenti metodi: inserire un opera d'arte, stampare la
    collezione , stampare l'occupazione di una data opera .
 
 */

namespace CollezioneArte {

    abstract class Opera {
        
        protected string Titolo { get; set; }
        protected string Autore { get; set; }

        public Opera(string titolo, string autore) {
            Titolo = titolo;
            Autore = autore;
        }

        public abstract double Ingombro();

        public bool Uguale(Object obj) {

            if (obj.GetType() != this.GetType())
                return false;

            if (this is Quadro)
                return Ingombro().Equals((obj as Quadro).Ingombro());
            else if (this is Scultura)
                return Ingombro().Equals((obj as Scultura).Ingombro());
            else
                return false;
        }

        public override string ToString() {
            return "Titolo: " + Titolo + "\nLuogo: " + Autore;
        }
    }

    class Quadro : Opera {
        
        public double Altezza { get; set; }
        public double Larghezza { get; set; }

        public Quadro(string titolo, string autore, double altezza, double larghezza) : base(titolo, autore) {
            Altezza = altezza;
            Larghezza = larghezza;
        }

        public override double Ingombro() {
            return Altezza * Larghezza;
        }

        public override string ToString() {
            return "Tipologia: Quadro\n" + base.ToString() + "\nAltezza: " + Altezza + " cm\nLarghezza: " + Larghezza + "cm \nIngombro: " + Ingombro() + " cm2";
        }
    }

    class Scultura : Opera {
        
        public double Altezza { get; set; }
        public double Larghezza { get; set; }
        public double Profondita { get; set; }
        
        public Scultura(string titolo, string autore, double altezza, double larghezza, double profondita) : base(titolo, autore) {
            Altezza = altezza;
            Larghezza = larghezza;
            Profondita = profondita;
        }

        public override double Ingombro() {
            return Altezza * Larghezza * Profondita;
        }

        public override string ToString() {
            return "Tipologia: Scultura\n" + base.ToString() + "\nAltezza: " + Altezza + " cm\nLarghezza: " + Larghezza + " cm\nProfondità: " + Profondita + " cm\nIngombro: " + Ingombro() + " cm3";
        }
    }

    class Collezione {
        
        public string Nome { get; set; }
        public string Luogo { get; set; }
        List<Opera> collezione;

        public Collezione(string nome, string luogo) {
            collezione = new List<Opera>();
            Nome = nome;
            Luogo = luogo;
        }

        public void aggiungiOpera(Opera o) {
            collezione.Add(o);
        }
        
        public void aggiungiOpera(params Opera[] o) {
            collezione.AddRange(o);
        }

        public string getColl() {
            
            string s = "";
            collezione.ForEach(x => s += x + "\n\n");

            return s;
        }
    }

    class Program {
        static void Main(string[] args) {
            
            // Crea due quadri e stampa le loro informazioni
            Quadro q1 = new Quadro("Guernica", "Picasso", 280, 130);
            //Console.WriteLine(q1);
            Quadro q2 = new Quadro("Il mare d'inverno", "Bojoux", 130, 280);
            //Console.WriteLine("\n\n" + q2);

            // Compara ingombro di due quadri
            Console.WriteLine("\n\nQuadro1 = Quadro2 ? " + q1.Uguale(q2));

            // Crea una scultura
            Scultura s1 = new Scultura("David", "Donatello", 100, 30, 50);
            //Console.WriteLine("\n\n" + s1);

            // Crea una collezione e la popola con gli oggetti creati
            Collezione c = new Collezione("Artisti del 1800", "Milano");
            c.aggiungiOpera(q1, q2, s1);
            Console.WriteLine(c.getColl());
        }
    }
}