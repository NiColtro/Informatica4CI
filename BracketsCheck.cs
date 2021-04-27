/*

	Controlla se un'espressione è corretta valutando l'utilizzo delle parentesi e la loro gerarchia.

*/

using System;
using System.Collections;

namespace BracketsCheck {
    
    class Program {

        static int bracketPriority(char bracket) {
            switch (bracket) {
                case '(': case ')':
                    return 3;
                case '[': case ']':
                    return 2;
                case '{': case '}':
                    return 1;
                default:
                    return 0;
            }
        }
        
        static bool checkBrackets(string buffer) {
            Stack stack = new Stack();

            for (int i = 0; i < buffer.Length; i++) {
                switch (buffer[i]) {
                    case '(': case '[': case '{':
                        if (stack.Count > 0 && (bracketPriority((char) stack.Peek()) - bracketPriority(buffer[i])) != -1) // Controlla il delta con la precedente (= gerarchia errata)
                            return false;
                        else 
                            stack.Push(buffer[i]); // Se il controllo va a buon fine, inserisce la parentesi nello stack
                        break;
                    
                    case ')': case ']': case '}':
                        if (stack.Count > 0 && bracketPriority((char) stack.Peek()) == bracketPriority(buffer[i])) // Controlla la coppia di parentesi
                            stack.Pop(); // Se il controllo va a buon fine, rimuove la parentesi dallo stack
                        else
                            return false;
                        break;
                }
            }

            return stack.Count == 0;
        }
        
        static void Main(string[] args) {
            Console.WriteLine(checkBrackets("(2+2)+([1+2])"));
        }
    }
}