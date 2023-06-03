//Прочитать текстовый файл и посчитать количество гласных и согласных букв в файле
//Результат вывести на экран

using System;
using System.IO;

namespace Vowels
{
    class Program
    {
        static void Main()
        {
            string line;
            Dictionary<string, int> counter = new Dictionary<string, int>()
            {
                {"consonants", 0},
                {"vowels", 0}
            };
            // Считаем файл
            try
            {
                StreamReader sr = new StreamReader("text.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    // Подсчет количества гласных и согласных
                    counter = Program.count_consonants_and_vowels(line.ToLower(), counter);
                    line = sr.ReadLine();
                }
                sr.Close();

                foreach (KeyValuePair<string, int> kvp in counter)
                {
                    Console.WriteLine($"{kvp.Key}  = {kvp.Value}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static Dictionary<string, int> count_consonants_and_vowels(string line, Dictionary<string, int> counter)
        {
            /// Подсчет количества гласных и согласных
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            var consonants = new HashSet<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
            foreach (char i in line)
            {
                if (vowels.Contains(i)) { counter["vowels"] += 1; }
                else if (consonants.Contains(i)) { counter["consonants"] += 1; }
            }

            return counter;
        }


    }
}
