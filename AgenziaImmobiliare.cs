using System;
using System.Collections.Generic;

namespace AgenziaImmobiliare {

    class Immobile : IComparable {

        public string Codice { get; set; }
        public string Indirizzo { get; set; }
        public string CAP { get; set; }
        public string Citta { get; set; }

        public int Superficie
        {
            get { return Superficie; }
            set
            {
                if (value <= 0)
                    Superficie = value;
                else
                    throw new Exception("Proprietà SUPERFICIE non valida.");
            }
        }

        public Immobile(string codice, string indirizzo, string cap, string citta, int superficie) {
            Codice = codice;
            Indirizzo = indirizzo;
            CAP = cap;
            Citta = citta;
            Superficie = superficie;
        }

        private static int calcPriority(object o) {
            if (o.GetType() == typeof(Box))
                return 1;
            if (o.GetType() == typeof(Appartamento))
                return 2;
            return 3;
        }

        public int CompareTo(object obj) {
            return calcPriority(this).CompareTo(calcPriority(obj));
        }

        public override string ToString() {
            return "\n\nCodice: " + Codice + "\nIndirizzo: " + Indirizzo + ", " + CAP + ", " + Citta + "\nSuperficie: " +
                   Superficie;
        }
    }

    class Box : Immobile {

        public int PostiAuto
        {
            get { return PostiAuto; }
            set
            {
                if (value <= 0)
                    PostiAuto = value;
                else
                    throw new Exception("Proprietà POSTI AUTO non valida.");
            }
        }

        public Box(string codice, string indirizzo, string cap, string citta, int superficie, int postiAuto) : base(codice,
            indirizzo, cap, citta, superficie) {
            PostiAuto = postiAuto;
        }

        public int CompareTo(object obj) {
            if (obj.GetType() == typeof(Box))
                return PostiAuto.CompareTo((obj as Box).PostiAuto);
            return -1;
        }

        public override string ToString() {
            return base.ToString() + "\nPosti auto: " + PostiAuto;
        }
    }

    class Appartamento : Immobile {

        public int NumeroVani
        {
            get { return NumeroVani; }
            set
            {
                if (value <= 0)
                    NumeroVani = value;
                else
                    throw new Exception("Proprietà NUM. VANI non valida.");
            }
        }

        public int NumeroBagni
        {
            get { return NumeroBagni; }
            set
            {
                if (value <= 0)
                    NumeroBagni = value;
                else
                    throw new Exception("Proprietà NUM. BAGNI non valida.");
            }
        }

        public Appartamento(string codice, string indirizzo, string cap, string citta, int superficie, int numeroVani,
            int numeroBagni) : base(codice, indirizzo, cap, citta, superficie) {
            NumeroVani = numeroVani;
            NumeroBagni = numeroBagni;
        }

        public int CompareTo(object obj) {
            if (obj.GetType() == typeof(Appartamento))
                return Superficie.CompareTo((obj as Appartamento).Superficie);
            return -1;
        }

        public override string ToString() {
            return base.ToString() + "\nNumero vani: " + NumeroVani + "\nNumero bagni: " + NumeroBagni;
        }
    }

    class Villa : Appartamento {

        public int SuperficieGiardino
        {
            get { return SuperficieGiardino; }
            set
            {
                if (value <= 0)
                    SuperficieGiardino = value;
                else
                    throw new Exception("Proprietà SUP. GIARDINO non valida.");
            }
        }

        public Villa(string codice, string indirizzo, string cap, string citta, int superficie, int numeroVani,
            int numeroBagni, int superficieGiardino) : base(codice, indirizzo, cap, citta, superficie, numeroVani,
            numeroBagni) {
            SuperficieGiardino = superficieGiardino;
        }

        public int CompareTo(object obj) {
            if (obj.GetType() == typeof(Villa)) {
                if (Superficie != (obj as Villa).Superficie)
                    return Superficie.CompareTo((obj as Villa).Superficie);

                if (NumeroVani != (obj as Villa).NumeroVani)
                    return NumeroVani.CompareTo((obj as Villa).NumeroVani);

                if (SuperficieGiardino != (obj as Villa).SuperficieGiardino)
                    return SuperficieGiardino.CompareTo((obj as Villa).SuperficieGiardino);
            }

            return -1;
        }

        public override string ToString() {
            return base.ToString() + "\nSuperficie giardino: " + SuperficieGiardino;
        }
    }

    class Program {
        static void Main(string[] args) {

            List<Immobile> immobili = new List<Immobile>();

            immobili.FindAll(x => x.ToString().Contains("Query di ricerca"));
        }
    }
}
