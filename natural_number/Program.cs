//   а) количество цифр в нем;
//   б) сумму его цифр;
//   в) произведение его цифр;
//   г) среднее арифметическое его цифр;
//   д) сумму квадратов его цифр;
//   е) сумму кубов его цифр;
//   ж) его первую цифру;
//   з) сумму его первой и последней цифр.



namespace NaturalNumber
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите натуральное число: n = ");
                uint n = Convert.ToUInt32(Console.ReadLine());

                if (n == 0)
                {
                    throw new Exception("Введите число больше > 0");
                }

                int[] digits = n.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();

                int digitsCounter = Program.digits_counter(digits);
                int digitsSum = Program.digits_sum(digits);
                int digitsProduct = Program.digits_product(digits);
                int digitsAverage = digitsSum / digitsCounter;
                int digitsSquareSum = digits_square_sum(digits);
                int digitsCubeSum = digits_cube_sum(digits);
                int digit_first = digits[0];
                int first_plus_last_digits = digits[0] + digits[digits.Length - 1];

                Console.WriteLine($"Количетсво цифр =  {digitsCounter}");
                Console.WriteLine($"Сумма цифр =  {digitsSum}");
                Console.WriteLine($"Произведение цифр =  {digitsProduct}");
                Console.WriteLine($"Среднее арифметическое цифр =  {digitsAverage}");
                Console.WriteLine($"Сумма квадратов цифр =  {digitsSquareSum}");
                Console.WriteLine($"Сумма кубов цифр =  {digitsCubeSum}");
                Console.WriteLine($"Первая цифра =  {digit_first}");
                Console.WriteLine($"Сумма первой и второй цифры =  {first_plus_last_digits}");


            }
            catch
            {
                Console.WriteLine("Введите число больше > 0");
            }

        }

        public static int digits_counter(int[] digits)
        {
            return digits.Length;
        }

        public static int digits_sum(int[] digits)
        {
            return digits.Sum();
        }

        public static int digits_product(int[] digits)
        {
            int prod = 1;
            foreach (int value in digits)
            {
                prod *= value;
            }

            return prod;
        }

        public static int digits_square_sum(int[] digits)
        {
            int square_sum = 0;
            foreach (int value in digits)
            {
                square_sum += value * value;
            }

            return square_sum;
        }

        public static int digits_cube_sum(int[] digits)
        {
            int cube_sum = 0;
            foreach (int value in digits)
            {
                cube_sum += value * value * value;
            }

            return cube_sum;
        }

    }
}
