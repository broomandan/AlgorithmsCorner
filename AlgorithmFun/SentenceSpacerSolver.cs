using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    class SentenceSpacerSolver
    {
        private static IDictionary<string, string> dictionary =
            new Dictionary<string, string>() { 
                                                {"pea","pea"},
                                                {"nut","nut"},
                                                {"peanut","peanut"},
                                                {"butter","butter"},
                                                {"hello","hello"},
                                                {"robert","robert"},
                                                {"world","world"},
                                                {"people","people"}
                                              };

        //            var sentence = "HelloWorldRobert";
        private static string sentence = "peanutbutter";

        public static void Solve()
        {
            Console.WriteLine("Multiple Solutions for Sentence Spacer problem:\r\nInput Sentence:\"{0}\"\r\n", sentence);
            /*
            Console.Write("Simple Solution: ");
            SpaceSentenceIterativeSimple(sentence);
            Console.WriteLine();

            Console.Write("Iterative Solution: ");
            SpaceSentenceIterative(sentence);
            Console.WriteLine();

            Console.Write("Recursive Solution: ");
            SpaceSentenceRecursive(sentence);
            Console.WriteLine();
            */
            Console.Write("Recursive-Backtrack Solution: ");
            SpaceSentenceRecursiveBacktrack(sentence);
            Console.WriteLine();
        }

        private static void SpaceSentenceIterativeSimple(string sentence)
        {
            var processor = new SentenceProcessorIterativeSimple(dictionary);
            Console.WriteLine(processor.SentenceSpacer(sentence));
        }

        private static void SpaceSentenceIterative(string sentence)
        {
            var processor = new SentenceProcessorIterative(dictionary);
            processor.SentenceSpacer(sentence);
        }

        private static void SpaceSentenceRecursive(string sentence)
        {
            var processor = new SentenceProcessorRecursive(dictionary);
            processor.SentenceSpacer(sentence, 0);
        }

        private static void SpaceSentenceRecursiveBacktrack(string sentence)
        {
            var processor = new SentenceProcessorRecursiveBackTrack(dictionary);
            processor.SentenceSpacer(sentence, 0);
        }
    }
}
