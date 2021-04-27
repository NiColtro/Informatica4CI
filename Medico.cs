using System;
using System.Collections.Generic;

namespace Ospedale {

    enum Reparti {
        Cardiologia,
        Neurologia,
        Pneumologia
    }
    
    class Dottorato {
        private string universita, luogo;
        private int voto;
        private DateTime dataConseguimento;

        public string Universita => universita;
        public int Voto => voto;

        public Dottorato(string universita, string luogo, int voto, DateTime dataConseguimento) {
            this.universita = universita;
            this.luogo = luogo;
            this.voto = voto;
            this.dataConseguimento = dataConseguimento;
        }
    }
    
    class Medico {
        private string nome, cognome;
        private DateTime annoNascita, annoAssunzione;
        private Reparti reparto;
        private Dottorato dottorato;
  
        public string Nome => nome;
        public string Cognome => cognome;
        public Dottorato Dottorato => dottorato;
        public Reparti Reparto => reparto;
        public DateTime AnnoAssunzione => annoAssunzione;

        public Medico(string nome, string cognome, DateTime annoNascita, DateTime annoAssunzione, Dottorato dottorato, Reparti reparto) {
            this.nome = nome;
            this.cognome = cognome;
            this.annoNascita = annoNascita;
            this.annoAssunzione = annoAssunzione;
            this.dottorato = dottorato;
            this.reparto = reparto;
        }
    }
    
    class Program {
        static void Main(string[] args) {

            List<Medico> medici = new List<Medico>();
            Medico medicoA = new Medico("Nico", "Coltro", DateTime.Now, DateTime.Now, new Dottorato("NomeUni", "LuogoUni", 100, DateTime.Now), Reparti.Cardiologia);
            
            medici.Add(medicoA);
            
            // Elimina con voto < 90
            medici.RemoveAll(x => x.Dottorato.Voto < 90);
            
            // Trova cardiologia
            medici.FindAll(x => x.Reparto == Reparti.Cardiologia).ForEach(Console.WriteLine);
            
            // Ordina per Cognome, Nome o AnnoAssunzione
            medici.Sort((x, y) =>
            {
                if (x.Cognome == y.Cognome)
                    if (x.Nome == y.Nome)
                        return x.AnnoAssunzione.CompareTo(y.AnnoAssunzione);
                    else
                        return x.Nome.CompareTo(y.Nome);
                else
                    return x.Cognome.CompareTo(y.Cognome);
            });
            
            // UniInsubria
            List<Medico> mediciInsubria = new List<Medico>(medici.FindAll(x => x.Dottorato.Universita == "UniInsubria"));
            
            
        }
    }
}