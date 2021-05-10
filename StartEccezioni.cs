using System;

namespace StartEccezioni {
    class Program {
        static void Main(string[] args) {
            int d, n;
            bool inputOk = true;

            do {
                try {
                    Console.WriteLine("Inserisci Divisiore: ");
                    d = int.Parse(Console.ReadLine());
                    n = 10 / d;

                    Console.WriteLine("= " + n);
                }
                catch (Exception e) {
                    inputOk = false;
                    Console.WriteLine(e.Message);
                }
            } while (inputOk);

            /*
                catch (DivideByZeroException e) {
                   Console.WriteLine("Divisione per 0 non ammessa.");
                }
            */

        }
    }
}
