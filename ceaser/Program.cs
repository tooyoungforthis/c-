//Алгоритм шифрования Цезаря заключается в замене каждого символа входящего сообщения на символ,
//который находится на некотором константном расстоянии с правой или левой стороны.
//Расстояние при этом называют – ключом.
//Например для ключа 5 получаем последовательность:
//Русский алфавит:
// Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я
//Шифр:
// Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я А Б В Г Д
//То есть А заменяем на Е, Б на Ё, и т. д.


using System.Text;

namespace Simple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о',
                'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            Console.WriteLine("Введите начальную строку: ");
            string start_string = Console.ReadLine();

            Console.WriteLine("Введите смещение: ");
            int N = Convert.ToInt32(Console.ReadLine());

            string result_string = create_new_string(alphabet, N, start_string);
            Console.WriteLine(result_string);

        }

        static string create_new_string(char[] letters, int bias, string start_string)
        {
            StringBuilder res = new StringBuilder();
            foreach (char letter in start_string)
            {
                int letter_index = Array.IndexOf(letters, letter);
                res.Append(letters[(letter_index + bias) % 33]);
            }

            return res.ToString();
        }
    }
}
