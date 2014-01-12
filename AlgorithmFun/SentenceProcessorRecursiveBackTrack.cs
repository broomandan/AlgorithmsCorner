using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    class SentenceProcessorRecursiveBackTrack
    {

        private IDictionary<string, string> _dictionary;
        private Stack<string> _wordsStack = new Stack<string>();

        public SentenceProcessorRecursiveBackTrack(IDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }
        public void SentenceSpacer(string sentence, int startPosition)
        {
            var word = ExtractWord(sentence, startPosition, 1);
            while (string.IsNullOrEmpty(word) && _wordsStack.Count > 0)
            {
                var lastWord = _wordsStack.Pop();
                startPosition = startPosition - lastWord.Length;
                word = ExtractWord(sentence, startPosition, lastWord.Length + 1);
            }
            _wordsStack.Push(word);

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
            var words = _wordsStack.Reverse().ToList();
            words.ToList().ForEach(w => Console.Write(w + (words.IndexOf(w) < words.Count - 1 ? " " : "")));
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

