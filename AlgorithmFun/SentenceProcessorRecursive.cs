using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    public class SentenceProcessorRecursive
    {
        private IDictionary<string, string> _dictionary;
        private List<string> _words = new List<string>();

        public SentenceProcessorRecursive(IDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }
        public void SentenceSpacer(string sentence, int startPosition)
        {
            var word = ExtractWord(sentence, startPosition, 1);

            _words.Add(word);

            if (!string.IsNullOrEmpty(word) && word.Length < sentence.Length - startPosition)
            {
                SentenceSpacer(sentence, startPosition + word.Length);
            }
            else
            {
                PrintSentence();
            }
        }

        private void PrintSentence()
        {
            _words.ForEach(w => Console.Write(w + (_words.IndexOf(w) < _words.Count - 1 ? " " : "\r\n")));
        }

        private string ExtractWord(string sentence, int startPosition, int tokenSize)
        {
            if (tokenSize > sentence.Length - startPosition)
            {
                return "";
            }

            var token = sentence.Substring(startPosition, tokenSize);

            if (isTokenAWord(token))
            {
                return token;
            }

            return ExtractWord(sentence, startPosition, tokenSize + 1);
        }

        private bool isTokenAWord(string token)
        {
            return _dictionary.ContainsKey(token.ToLower());
        }

    }
}
