using System;
using System.IO;

namespace FileInfo {
    class Program {
        static void Main(string[] args) {

            int rowCounter = 0, charCounter = 0, wordCounter = 0;

            if (!File.Exists(@"C:\users\coltr\Desktop\test.txt"))
                return;

            StreamReader sr = new StreamReader(@"C:\users\coltr\Desktop\test.txt");

            while (!sr.EndOfStream) {
                string currentLine = sr.ReadLine();
                
                charCounter += currentLine.Length;
                wordCounter += currentLine.Split(" ").Length;
                rowCounter++;
            }

            sr.Close();
            Console.WriteLine("Contatore righe: " + rowCounter + "\nContatore caratteri: " + charCounter + "\nContatore parole: " + wordCounter);
        }
    }
}
