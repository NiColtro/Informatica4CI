/*

	Estrai casualmente un set di N carte caratterizzate da
	un Seme ed un valore numerico da 1 a 12.

*/

using System;

namespace MazzoCarte
{

    enum Seme { Cuori, Fiori, Picche, Quadri };

    class Carta
    {
        int valore;
        public int Valore
        {
            get { return valore; }
            set
            {
                if (value >= 1 && value <= 13) valore = value;
                else valore = -1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random casuale = new Random();
            Carta[] mazzo = new Carta[52];

            int v;
            Seme s;

            for (int i = 0; i < 52; i++)
            {
                v = (i % 13) + 1;
                s = (Seme)(i / 13);
                Console.WriteLine(i + "\t" + v + "\t" + s);
            }
        }
    }
}
