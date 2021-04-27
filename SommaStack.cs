/*

	Algoritmo per la somma di due stack
	(sintassi: notazione polacca).

*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace StackOp {
    class SommaPila {
        Stack op1 = new Stack();
        Stack op2 = new Stack();

        public SommaPila(int num1, int num2) {
            for (int i = 0; i < num1.ToString().Length; i++)
                op1.Push(num1.ToString()[i] - 48);
            
            for (int i = 0; i < num2.ToString().Length; i++)
                op2.Push(num2.ToString()[i] - 48);
        }

        public Stack solve() {
            int somma = 0;
            Stack ris = new Stack();
            
            while (op1.Count > 0 || op2.Count > 0) {
                if (op1.Count > 0) // Somma num1
                    somma += (int) op1.Pop();

                if (op2.Count > 0) // Somma num2
                    somma += (int) op2.Pop();

                ris.Push(somma % 10); // Salva cifra unità
                
                if (somma > 9) // Controllo doppia cifra
                    somma = 1; // Salva cifra decine
                else
                    somma = 0;
            }
            
            if (somma != 0)
                ris.Push(1);

            return ris; // Ritorna Stack risultato
        }
    }

    class Program {
        static void Main(string[] args) {
            
            SommaPila sommaPila = new SommaPila(592, 3784); // 592 + 3784
            Stack ris = sommaPila.solve();
            
            while (ris.Count > 0) {
                Console.Write(ris.Pop()); // = 4376
            }
        }
    }
}