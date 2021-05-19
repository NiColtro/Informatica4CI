using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Alunni_FS {
    class Studente {
        public string Nome { get; set; }
        public DateTime DataNascita { get; set; }
        public List<int> Voti;

        public Studente(string nome, DateTime dataNascita) {
            Nome = nome;
            DataNascita = dataNascita;
            Voti = new List<int>();
        }

        public float media() {
            float media = 0;
            Voti.ForEach(x => media += x);
            return media /= Voti.Count;
        }

        public override string ToString() {
            return "> Studente\nNome: " + Nome + "\nData di nascita: " + DataNascita.ToString("dd/MM/yyyy") + "\nMedia: " +
                   media() + "\n";
        }

        public string rawData() {
            string s = Nome + ";" + DataNascita + ";";
            Voti.ForEach(x => s += x + ",");
            return s;
        }
    }

    class Program {
        static void Main(string[] args) {

            List<Studente> studenti = new List<Studente>(); // Lista studenti

            StreamReader sr = new StreamReader(@"V:\\studenti.dat"); // Stream lettura
            string rawData = sr.ReadToEnd();

            for (int i = 0; i < Regex.Matches(rawData, "\n").Count; i++) {
                // Popola lista con dati da file
                string datiStudente = rawData.Split("\n")[i]; // Prende dati linea
                Studente newSt =
                    new Studente(datiStudente.Split(";")[0],
                        DateTime.Parse(datiStudente.Split(";")[1])); // Dati Nome e DataNascita

                foreach (string voto in datiStudente.Split(";")[2].Split(",")) {
                    // Popola array voti
                    int currentVoto;
                    bool tryParse = Int32.TryParse(voto, out currentVoto);
                    if (tryParse)
                        newSt.Voti.Add(currentVoto);
                }

                studenti.Add(newSt);
            }

            sr.Close(); // Chiude stream lettura

            string menu, inputA, inputB;

            do {

                Console.Write(
                    "\nSCUOLA\n1. Inserisci nuovo studente;\n2. Visualizza tutti gli studenti;\n3. Visualizza studenti con criteri specifici;\n4. Esci.\nCosa vuoi fare? ");
                menu = Console.ReadLine();

                switch (menu) {
                    case "1": // Aggiunge studente alla lista
                        Console.Write("\n--- AGGIUNTA STUDENTE ---\nNome: ");
                        inputA = Console.ReadLine();
                        Console.Write("Quanti voti vuoi aggiungere? ");
                        inputB = Console.ReadLine();

                        Studente s = new Studente(inputA, DateTime.Now);

                        for (int i = 0; i < int.Parse(inputB); i++) {
                            Console.Write("Inserisci voto #" + i + ": ");
                            inputA = Console.ReadLine();
                            s.Voti.Add(int.Parse(inputA));
                        }

                        studenti.Add(s);
                        break;

                    case "2": // Printa tutta la scuola
                        Console.Write("\n--- LISTA DI TUTTI GLI STUDENTI ---\n");
                        studenti.ForEach(Console.WriteLine);
                        break;

                    case "3": // Richieste di ricerca
                        Console.WriteLine("\n--- TUTTI GLI STUDENTI CON MEDIA SUFFICIENTE ---\n");
                        studenti.FindAll(x => x.media() > 6)
                            .ForEach(Console.WriteLine); // Trova tutti quelli con media sufficiente
                        Console.WriteLine("\n--- TUTTI GLI STUDENTI CON NESSUN VOTO < 6 ---\n");
                        studenti.FindAll(x => x.Voti.FindAll(y => y < 6).Count == 0)
                            .ForEach(Console.WriteLine); // Trova tutti quelli con almeno un voto insufficiente
                        break;
                }
            } while (menu != "4");

            // Salvataggio della lista su file
            StreamWriter sw = new StreamWriter(@"V:\\studenti.dat", false);
            studenti.ForEach(x => sw.WriteLine(x.rawData()));
            sw.Close();
            Console.WriteLine("\nUscita.");
        }
    }
}
