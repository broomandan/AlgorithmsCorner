using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    public class SentenceProcessorIterative
    {
        private IDictionary<string, string> _dictionary;
        private List<string> _words = new List<string>();

        public SentenceProcessorIterative(IDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }

        public void SentenceSpacer(string sentence)
        {
            string spacedSentence = string.Empty;
            int startPosition = 0;
            int wordLength = 0;

            do
            {

                string word = ExtractWord(sentence, startPosition);
                _words.Add(word);

                wordLength = word.Length;

                startPosition += wordLength;


            } while (wordLength < sentence.Length - startPosition);

            PrintSentence();
        }

        private void PrintSentence()
        {
            _words.ForEach(w => Console.Write(w + (_words.IndexOf(w) < _words.Count - 1 ? " " : "\r\n")));

        }
        private string ExtractWord(string sentence, int startPosition)
        {
            string word = string.Empty;
            var maxTokenSize = sentence.Length - startPosition;
            // robert
            for (int tokenSize = 1; tokenSize <= maxTokenSize; tokenSize++)
            {
                var token = sentence.Substring(startPosition, tokenSize);
                if (isWord(token))
                {
                    word = token;
                    break;
                }
            }

            return word;
        }

        private bool isWord(string token)
        {
            return _dictionary.ContainsKey(token.ToLower());
        }

    }
}
