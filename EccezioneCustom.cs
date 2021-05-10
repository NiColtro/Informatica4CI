using System;

namespace ClassCheck {

    class myException : Exception {
        private static string msg = "myClass: valore di N non accettabile!";

        public myException() : base(msg) {}
        public myException(string cmsg) : base(cmsg) {}
    }

    class myClass {

        private int n;

        public int N
        {
            get { return n; }
            set
            {
                if (value != 0)
                    n = value;
                else
                    throw new myException();
            }
        }

        public myClass(int n) {
            N = n;
        }
    }

    class Program {
        static void Main(string[] args) {

            int input;
            Console.WriteLine("Inserisci l'input: ");
            input = int.Parse(Console.ReadLine());

            try {
                myClass mc = new myClass(input);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
