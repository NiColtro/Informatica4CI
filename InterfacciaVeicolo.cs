using System;

namespace InterfacciaVeicolo {
    interface IConfronta {
        bool confronta(object o);
    }

    interface IStampa {
        void stampaInfo();
    }

    class Veicolo {
        public Veicolo() {
        }

        public virtual void avanti() {
            Console.WriteLine("Il veicolo è andato avanti...");
        }
    }

    class Auto : Veicolo, IConfronta, IStampa {
        public int NumeroPosti { get; set; }

        public Auto(int numeroPosti) {
            NumeroPosti = numeroPosti;
        }

        public bool confronta(object o) {
            if (o.GetType() == typeof(Auto))
                if ((o as Auto).NumeroPosti == NumeroPosti)
                    return true;
            return false;
        }

        public override void avanti() {
            base.avanti();
        }

        public void stampaInfo() {
            Console.WriteLine("Tipo: Auto\nNumero posti: " + NumeroPosti);
        }
    }

    class Camion : Veicolo, IConfronta, IStampa {
        public int Carico { get; set; }

        public Camion(int carico) {
            Carico = carico;
        }

        public bool confronta(object o) {
            if (o.GetType() == typeof(Camion))
                if ((o as Camion).Carico == Carico)
                    return true;
            return false;
        }

        public override void avanti() {
            base.avanti();
        }

        public void stampaInfo() {
            Console.WriteLine("Tipo: Camion\nCarico: " + Carico);
        }
    }

    class Program {
        static void Main(string[] args) {
            
        }
    }
}
