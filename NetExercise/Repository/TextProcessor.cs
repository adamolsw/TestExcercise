using NetExercise.Models;
using System.Collections.Generic;

namespace NetExercise.Repository
{
    public class TextProcessor : IGetModel
    {
        public Text GetModel(string inputText)
        {
            Text text = new Text();
            Sentences sentence;
            TextHelper th = new TextHelper();

            string[] inputSentences;
            inputText = th.RemoveLastChar(inputText, '.');
            inputSentences = inputText.Split('.');
            foreach (string inputSentence in inputSentences)
            {
                sentence = new Sentences();
                List<string> word = new List<string>();
                word = th.GetSplittedString(inputSentence, ',');

                if (word.Count > 0)
                {
                    sentence.word = word;
                    text.sentence.Add(sentence);
                }
            }
            return text;
        }   
    }
}