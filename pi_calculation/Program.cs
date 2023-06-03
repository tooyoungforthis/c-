/*
Определить число Пи методом Монте - Карло
*/


namespace Pi
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите кол-во случайных точек: N = ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите диаметр окружности: diameter = ");
            int diameter = Convert.ToInt32(Console.ReadLine());


            int total_dots_in_cirle = 0;
            for (int i = 0; i < N; i++)
            {
                (double x, double y) = generate_dots(diameter);

                if (is_inside_circle(x, y, diameter / 2)) { total_dots_in_cirle++; }

            }

            // Вычислим значение Pi
            double pi = 4 * total_dots_in_cirle / (double)N;
            Console.WriteLine($"Значение Pi = {pi}");


        }

        static (double, double) generate_dots(int diameter)
        {
            /// Генерирование случайныхъ точек
            Random random = new Random();
            double x = random.NextDouble() * diameter;
            double y = random.NextDouble() * diameter;

            return (x, y);
        }

        static bool is_inside_circle(double x, double y, int Radius)
        {
            /// Подсчет точек, попавших в круг
            double radius_vector = Math.Pow(Math.Pow(Radius - x, 2) + Math.Pow(Radius - y, 2), 0.5);
            if (radius_vector < Radius) { return true; }
            else { return false; }
        }
    }
}
