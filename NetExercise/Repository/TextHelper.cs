using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetExercise.Repository
{
    public class TextHelper
    {
        public List<string> GetSplittedString(string inputText, char splitCharacter)
        {
            inputText = Regex.Replace(inputText, "[^0-9a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+", ",");
            inputText = RemoveFirstChar(inputText, ',');
            inputText = RemoveLastChar(inputText, ',');
            List<string> words = new List<string>();

            if (!string.IsNullOrEmpty(inputText))
            {
                words = inputText.Split(splitCharacter).ToList();
            }
            return words.OrderBy(w => w).ToList();
        }

        public string RemoveLastChar(string inputText, char charToRemove)
        {
            if (!string.IsNullOrEmpty(inputText))
            {
                int indexOfLastDot = inputText.LastIndexOf(charToRemove);
                int textLength = inputText.Length - 1;

                return indexOfLastDot == textLength ? inputText.Substring(0, indexOfLastDot) : inputText;
            }
            return "";
        }
        public string RemoveFirstChar(string inputText, char charToRemove)
        {
            if (!string.IsNullOrEmpty(inputText))
            {
                int indexOfFirstComma = inputText.IndexOf(charToRemove);
                return indexOfFirstComma == 0 ? inputText.Substring(1, inputText.Length - 1) : inputText;
            }
            return "";
        }
    }
}