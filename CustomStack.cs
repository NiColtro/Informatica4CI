/*

	Implementa una classe Stack custom e sviluppane i relativi metodi.

*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StackQueue
{
    class ClassStack {
        private Stack<int> stack;

        public ClassStack() {
            stack = new Stack<int>();
        }

        public int pop() {
            return stack.Pop();
        }
        
        public int top() {
            return stack.Peek();
        }
        
        public void push(int i) {
            stack.Push(i);
        }

        public bool isEmpty()
        {
            if (stack.Count == 0)
                return true;
            else
                return false;
        }
    }
    
    class ClassQueue {
        private Queue<int> queue;

        public ClassQueue() {
            queue = new Queue<int>();
        }

        public int deQueue() {
            return queue.Dequeue();
        }
        
        public int front() {
            return queue.Peek();
        }
        
        public int rear() {
            return queue.ToArray()[queue.Count-1];
        }
        
        public void enQueue(int i) {
            queue.Enqueue(i);
        }

        public bool isEmpty()
        {
            if (queue.Count == 0)
                return true;
            else
                return false;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Stack
            ClassStack myStack = new ClassStack();
            
            myStack.push(2);
            Console.WriteLine(myStack.top());

            
            // Queue
            ClassQueue myQueue = new ClassQueue();
            
            myQueue.enQueue(1);
            myQueue.enQueue(2);
            Console.WriteLine(myQueue.rear());
        }
    }
}
