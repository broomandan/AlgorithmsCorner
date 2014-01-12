using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    public class SentenceProcessorIterativeSimple
    {
        private IDictionary<string, string> _dictionary;

        public SentenceProcessorIterativeSimple(IDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }
        public string SentenceSpacer(string sentence)
        {
            string spacedSentence = string.Empty;

            string firstWord = ExtractWord(sentence, 0);
            string secondWord = ExtractWord(sentence, firstWord.Length);

            return string.Format("{0} {1}", firstWord, secondWord);
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
