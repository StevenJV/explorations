using System;
using System.Collections.Generic;

namespace LambdaExplorations
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("Fun With Lambdas");
            TraditionalDelegateSyntax();
            Console.ReadKey();
        }

        private static void TraditionalDelegateSyntax(){
            List<int> list = new List<int>();
            list.AddRange(new int[] {20, 1, 4, 8, 9, 44});
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            PrintEvenNumbers(evenNumbers);
        }

        private static bool IsEvenNumber(int i){
            return i % 2 == 0;
        }


        private static void AnonymousMethodSyntax(){
            List<int> list = new List<int>();
            list.AddRange(new int[] {20, 1, 4, 8, 9, 44});

            List<int> evenNumbers = list.FindAll(delegate(int i) { return (i%2) == 0; });

            PrintEvenNumbers(evenNumbers);
        }

        private static void PrintEvenNumbers(List<int> evenNumbers){
            Console.WriteLine("even numbers:");
            foreach (int evenNumber in evenNumbers) {
                Console.Write($"{evenNumber} \t");
            }
            Console.WriteLine();
        }
    }
}