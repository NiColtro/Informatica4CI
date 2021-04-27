using System;
using System.Collections.Generic;

namespace Veicoli {

    enum TipoVeicolo {
        Auto,
        Moto,
        Camper
    }
    
    enum CategoriaCamper {
        Mansardato,
        SemiIntegale,
        MotorHome
    }

    abstract class Veicolo {
        
        public string Marca { get; set; }
        public string Modello { get; set; }
        public int AnnoImmatricolazione { get; set; }
        public int Cilindrata { get; set; }
        public TipoVeicolo Tipo { get; set; }

        protected Veicolo(string marca, string modello, int annoImmatricolazione, int cilindrata, TipoVeicolo tipo) {
            Marca = marca;
            Modello = modello;
            AnnoImmatricolazione = annoImmatricolazione;
            Cilindrata = cilindrata;
            Tipo = tipo;
        }

        public abstract double Tariffa();
        public abstract bool Confronta(Veicolo v);
    }

    class Auto : Veicolo {
        
        public int Lunghezza { get; set; }
        public int Altezza { get; set; }

        public Auto(string marca, string modello, int annoImmatricolazione, int cilindrata, int lunghezza, int altezza) : base(marca, modello, annoImmatricolazione, cilindrata, Veicoli.TipoVeicolo.Auto) {
            Lunghezza = lunghezza;
            Altezza = altezza;
        }

        public override double Tariffa() {
            return Lunghezza * Altezza * 12;
        }

        public override bool Confronta(Veicolo v) {
            if (v.GetType() != typeof(Auto))
                return false;

            if ((v as Auto).Marca == Marca && (v as Auto).Modello == Modello)
                return true;

            return false;
        }
    }
    
    class Moto : Veicolo {

        public Moto(string marca, string modello, int annoImmatricolazione, int cilindrata) : base(marca, modello, annoImmatricolazione, cilindrata, TipoVeicolo.Moto) {}

        public override double Tariffa() {
            return Cilindrata / 30;
        }
        
        public override bool Confronta(Veicolo v) {
            if (v.GetType() != typeof(Moto))
                return false;

            if ((v as Moto).Marca == Marca && (v as Moto).Modello == Modello)
                return true;

            return false;
        }
    }
    
    class Camper : Veicolo {
        
        public int NumeroPosti { get; set; }
        public CategoriaCamper Categoria { get; set; }

        public Camper(string marca, string modello, int annoImmatricolazione, int cilindrata, int numeroPosti, CategoriaCamper categoria) : base(marca, modello, annoImmatricolazione, cilindrata, TipoVeicolo.Camper) {
            NumeroPosti = numeroPosti;
            Categoria = categoria;
        }

        public override double Tariffa() {
            if (Categoria == CategoriaCamper.Mansardato)
                return 150;
            if (Categoria == CategoriaCamper.SemiIntegale)
                return 110;
            return 360;
        }
        
        public override bool Confronta(Veicolo v) {
            if (v.GetType() != typeof(Camper))
                return false;

            if ((v as Camper).Marca == Marca && (v as Camper).Modello == Modello && (v as Camper).Categoria == Categoria)
                return true;

            return false;
        }
    }
    
    class Program {
        static void Main(string[] args) {

            List<Veicolo> veicoli = new List<Veicolo>();
            
            // Aggiungi Veicoli... ( veicoli.Add(T) )

            Console.WriteLine("--- TUTTA LA LISTA ---");
            veicoli.ForEach(Console.WriteLine);
            
            // Confronta due Veicoli UGUALI ( v1.Confronta(v2) )

            Console.WriteLine("--- MOTO CON ANNO IMM. PRIMA DEL 2010 ---");
            veicoli.FindAll(x => x.GetType() == typeof(Moto) && (x as Moto).AnnoImmatricolazione <= 2010);
        }
    }
}