using System;
using System.Linq;

namespace MeanMedianModeRangeAndLiteralCount
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Please enter:\n1 to find mean, median, mode and range \n2 to count the occurence of charcters in string: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("Please enter numbers followed by space: ");
                            var numericStr = Console.ReadLine();

                            var strArray = numericStr.Split(' ');
                            var numericVal = 0;

                            if (strArray.Any(x => !int.TryParse(x, out numericVal)))
                            {
                                Console.WriteLine("Please enter valid numbers!");
                                break;
                            }

                            PrintMeanMedianModeRange(strArray);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Please enter a literal string: ");
                            var literalStr = Console.ReadLine();
                            PrintCharcterOccurenceCount(literalStr);
                            //PrintCharcterOccurenceCountDictionary(literalStr);

                            break;
                        }

                    case "quit":
                        return;
                }
            }

        }

        private static void PrintMeanMedianModeRange(string[] inputStrArr)
        {
            var numArray = inputStrArr.Select(n => Convert.ToInt32(n)).ToArray();
            Calculator calculate = new Calculator(numArray);

            Console.WriteLine("mean: {0}", calculate.Mean());
            Console.WriteLine("median: {0}", calculate.Median());
            var mode = calculate.Mode();
            Console.WriteLine("mode: {0}", mode > -1 ? mode.ToString() : "None");
            Console.WriteLine("range: {0}", calculate.Range());

        }

        private static void PrintCharcterOccurenceCount(string inputStr)
        {
            Calculator calculate = new Calculator();
            var wordCount = calculate.CountOccurrence(inputStr);

            for (int i = 0; i < wordCount.Length; i++)
            {
                //output character only the ones present in word
                if (wordCount[i] != 0)
                    Console.WriteLine("{0} : {1}", (char)(i + (int)'!'), wordCount[i]);
            }
        }

        private static void PrintCharcterOccurenceCountDictionary(string inputStr)
        {
            Calculator calculate = new Calculator();
            var wordCount = calculate.CountOccurrenceUsingDictionary(inputStr);

            foreach (var word in wordCount)
            {
                Console.WriteLine("{0} : {1}", word.Key, word.Value);
            }
        }
    }
}


