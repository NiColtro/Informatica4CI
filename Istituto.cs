/*

	Gestisci un Istituto scolastico, composto da Alunni e Classi.
	Implementa l'inserimento di nuovi alunni e voti.

*/

using System;

namespace Istituto {

    class Alunno {
        string nome, cognome;
        int eta, contVoti;
        double[] voti = new double[100];

        public Alunno (string nome, string cognome, int eta) {
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
        }
        
        public void interrogato(double voto) {
            voti[contVoti] = voto;
            contVoti++;
        }

        public void stampaDati() {
            Console.WriteLine("Nome: " + nome + "\nCognome: " + cognome + "\nEtà: " + eta + "\nVoti: ");
            for (int i=0; i<contVoti; i++)
                Console.Write(voti[i] + "; ");
            Console.WriteLine("\n");
        }
    }

    class Classe {
        int idClasse, contAlunni;
        Alunno[] alunni = new Alunno[100];

        public Classe(int idClasse) {
            contAlunni = 0;
            this.idClasse = idClasse;
        }
        
        public void InserimentoAlunno(Alunno alunno) {
            alunni[contAlunni] = alunno;
            contAlunni++;
        }
        
        public void InserimentoAlunno(string nome, string cognome, int eta) {
            alunni[contAlunni] = new Alunno(nome, cognome, eta);
            contAlunni++;
        }

        public Alunno getAlunno(int idAlunno) {
            return alunni[idAlunno];
        }

        public void stampaDati() {
            Console.WriteLine("CLASSE " + idClasse);
            for (int i = 0; i < contAlunni; i++)
                alunni[i].stampaDati();
            Console.WriteLine("\n");
        }
    }

    class Scuola {
        int codice, contClassi;
        string nome, preside;
        Classe[] classi = new Classe[25];

        public Scuola(int codice, string nome, string preside) {
            contClassi = 0;
            this.codice = codice;
            this.nome = nome;
            this.preside = preside;
        }

        public void aggiungiClasse(Classe classe) {
            classi[contClassi] = classe;
            contClassi++;
        }

        public void aggiungiClasse(int idClasse, int idAula) {
            classi[contClassi] = new Classe(idClasse);
            contClassi++;
        }

        public Classe getAula(int idClasse) {
            return classi[idClasse];
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Scuola scuola = new Scuola(0, "ISIS Keynes", "Zibetti");

            Classe classe = new Classe(0);
            scuola.aggiungiClasse(classe);
            classe = new Classe(1);
            scuola.aggiungiClasse(classe);

            scuola.getAula(0).InserimentoAlunno("Nicolò", "Coltro", 17);
            scuola.getAula(1).InserimentoAlunno("Mario", "Rossi", 18);
            
            scuola.getAula(0).getAlunno(0).interrogato(10);
            scuola.getAula(1).getAlunno(0).interrogato(4);
            
            scuola.getAula(0).stampaDati();
            scuola.getAula(1).stampaDati();

        }
    }
}
