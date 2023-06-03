//Введённую строку разбить на подстроки, где разделителем является пробел и вывести список на экран и результаты записать в файл.
namespace Substrings_to_file
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите исходную строку");
            string s = Console.ReadLine().Trim();


            // Удалим все смежные пробелы
            while (s.Contains("  "))
            {
                s = s.Replace("  ", " ");
            }

            string[] substrings = s.Split(" ");

            // Запишем в файл file.txt подстроки
            File.WriteAllLines("file.txt", substrings);

            // Выведем построчно записи из файла file.txt
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string res = sr.ReadToEnd();
                Console.WriteLine(res);
            }
        }
    }
}