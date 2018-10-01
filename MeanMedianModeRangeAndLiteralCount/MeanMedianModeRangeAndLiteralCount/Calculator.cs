using System;
using System.Linq;
using System.Collections.Generic;

namespace MeanMedianModeRangeAndLiteralCount
{
    public class Calculator
    {
        private readonly int[] array;

        public Calculator(int[] array)
        {
            this.array = array;
        }

        public Calculator()
        {
        }

        public int ArrLength
        {
            get { return this.array.Length; }
        }

        /// <summary>
        /// Mean of numbers
        /// </summary>
        /// <returns>The mean.</returns>
        public int Mean()
        {
            if (ArrLength == 0) return 0;
            if (ArrLength == 1) return array[0];

            return array.Sum() / array.Length;
        }

        /// <summary>
        /// Median of numbers.
        /// </summary>
        /// <returns>The median.</returns>
        public int Median()
        {
            if (ArrLength == 0) return 0;
            if (ArrLength == 1) return array[0];

            Array.Sort(array);
            int mid = array.Length / 2;

            //for even numbers, mid point is avg of mid and mid - 1;

            var mean = (array[mid - 1] + array[mid]) / 2;

            return array.Length % 2 != 0 ? array[mid] : mean;

        }

        /// <summary>
        /// Mode of numbers.
        /// </summary>
        /// <returns>The mode.</returns>
        public int Mode()
        {
            if (ArrLength == 0) return 0;
            if (ArrLength == 1) return array[0];

            Dictionary<int, int> map = new Dictionary<int, int>(array.Length);

            foreach (int num in array)
            {
                if (!map.ContainsKey(num))
                    map.Add(num, 1);
                else
                    map[num] = ++map[num];
            }

            //get the max value           
            var mode = map.OrderByDescending(k => k.Value).First();

            //return -1 if there is no number repeated more than once
            return mode.Value > 1 ? mode.Key : -1;
        }

        /// <summary>
        /// Range of numbers.
        /// </summary>
        /// <returns>The range.</returns>
        public int Range()
        {
            if (ArrLength == 0) return 0;
            if (ArrLength == 1) return array[0];

            Array.Sort(array);
            return array[ArrLength - 1] - array[0];
        }

        /// <summary>
        /// Counts the occurrence of character in a string.
        /// </summary>
        /// <returns>Count of the occurrence of character in a string.</returns>
        /// <param name="word">Word.</param>
        public int[] CountOccurrence(String word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;

            //Assuming ASCII character set for 128 characters
            int[] charSet = new int[128];

            foreach (char c in word)
            {
                if (c != ' ' && !int.TryParse(c.ToString(), out int result))
                {
                    //special charcter position in ascii table starst at '!'
                    var charIndex = c - '!';

                    //if character does not exists in our set, add 1, else count
                    if (charSet[charIndex] == 0)
                        charSet[charIndex] = 1;
                    else
                        charSet[charIndex]++;
                }
            }
            return charSet;
        }
               
        /// <summary>
        /// Counts the occurence of character in a string.
        /// </summary>
        /// <returns>Count of the occurence.</returns>
        /// <param name="word">Word.</param>
        public IDictionary<char, int> CountOccurrenceUsingDictionary(String word)
        {           
            if (string.IsNullOrWhiteSpace(word)) return null;

            SortedDictionary<char, int> charMap = new SortedDictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                var character = word[i];

                //check the word if it has character               
                if (character != ' ' && Char.TryParse(word[i].ToString(), out char result))
                {
                    if (!charMap.ContainsKey(character))
                        charMap.Add(character, 1);
                    else
                        charMap[character] = ++charMap[character];
                }
            }
            return charMap;
        }

    }
}
