/*

	Implementa un parser di espressioni,
	Infix -> Postfix -> resolve().
	
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PostfixParser {
    class Program {
        // Metodo privato per calcolare la priorità di un operatore
        private static int priority(char i) { 
            switch (i) {
                case '^':
                    return 3;
                
                case '*': case '/':
                    return 2;
                
                case '+': case '-':
                    return 1;
                
                default:
                    return 0;
            }
        }

        // Metodo per "tradurre" espressione infix in postfix
        public static string infix2postfix(string buffer) {
            Stack<char> stack = new Stack<char>();
            String output = "";

            for (int i = 0; i < buffer.Length; i++) {
                switch (buffer[i]) {
                    case '(': // Parentesi aperta, pusha nello stack
                        stack.Push('(');
                        break;
                    
                    case ')': // Parentesi chiusa, mette nell'output tutti gli operatori precedenti
                        while (stack.Count > 0 && stack.Peek() != '(') {
                            output += stack.Pop();
                        }
                        if (stack.Peek() == '(') { // Rimuove la parentesi se rimasta nello stack (!!!)
                            stack.Pop(); 
                        }
                        break;
                    
                    case '+': case '-': case '*': case '/': case '^': // Operatori, mette nell'output finché sono di priorità maggiore dell'op. attuale
                        while (stack.Count > 0 && priority(stack.Peek()) >= priority(buffer[i])) {
                            output += stack.Pop();
                        }
                        stack.Push(buffer[i]); // Pusha nello stack l'operatore attuale
                        break;
                    
                    default: // Cifra, aggiunge all'output direttamente
                        output += (buffer[i] - 48);
                        break;
                }
            }

            while (stack.Count > 0) { // Svuota gli eventuali op. rimasti nello stack
                output += stack.Pop();
            }

            return output;
        }
        
        // Risolvi stringa formattata in postfix
        public static double solvePostfix(string buffer) {
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < buffer.Length; i++) {
                if (buffer[i] != '+' && buffer[i] != '-' && buffer[i] != '*' && buffer[i] != '/' && buffer[i] != '^') {
                    stack.Push(buffer[i] - 48);
                    // Console.WriteLine("[+] Aggiungo " + (buffer[i] - 48) + " allo stack");
                } else {
                    double opB = stack.Pop();
                    double opA = stack.Pop();

                    switch (buffer[i]) {
                        case '+':
                            stack.Push(opA + opB);
                            // Console.WriteLine("[=] Risolvo " + opA + " + " + opB + " nello stack");
                            break;
                        case '-':
                            stack.Push(opA - opB);
                            // Console.WriteLine("[=] Risolvo " + opA + " - " + opB + " nello stack");
                            break;
                        case '*':
                            stack.Push(opA * opB);
                            // Console.WriteLine("[=] Risolvo " + opA + " * " + opB + " nello stack");
                            break;
                        case '/':
                            stack.Push(opA / opB);
                            // Console.WriteLine("[=] Risolvo " + opA + " / " + opB + " nello stack");
                            break;
                        case '^':
                            stack.Push(Math.Pow(opA, opB));
                            // Console.WriteLine("[=] Risolvo " + opA + " ^ " + opB + " nello stack");
                            break;
                    }
                }
            }

            return stack.Pop();
        }

        static void Main(string[] args) {
            
            string buffer = "3+(3-4-5+6+7)+9^9*(4-4)*5";
            Console.WriteLine("Buffer infix: " + buffer);
            Console.WriteLine("Buffer postfix: " + infix2postfix(buffer));
            Console.WriteLine("Risoluzione = " + solvePostfix(infix2postfix(buffer)));
        }
    }
}