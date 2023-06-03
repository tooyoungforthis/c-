//Определить площадь многоугольника методом Монте - Карло.
//Sм = Sпр * Nм / Nв N ребер M* K площадь


// для n = 5 и seed = 15
// S = 6
namespace NN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер области (n*n): n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            Figure figure = new Figure();
            figure.generate_values(n);
            figure.output_values();

            int totalDots = 1000000;
            int dotsInside = dots_inside(figure, n, totalDots);

            double square = calculate_square(n, totalDots, dotsInside);
            Console.WriteLine($"Площадь фигуры равна {square}");
        }

        static public int dots_inside(Figure figure, int n, int totalDots)
        {
            /// Подсчет количества точек внутри многоугольника
            int dots_inside_figure = 0;

            for (int i = 0; i < totalDots; i++)
            {
                (double x, double y) = generate_dots(n);

                int intersections = 0;
                for (int j = 0; j < figure.vertexes.Count - 1; j++)
                {
                    var ABDot1 = (figure.vertexes[j].Item1, figure.vertexes[j].Item2);
                    var ABDot2 = (figure.vertexes[j + 1].Item1, figure.vertexes[j + 1].Item2);
                    var Random_dot = (x, y);
                    if (check_intersection(ABDot1, ABDot2, Random_dot))
                    {
                        intersections += 1;
                    }
                }

                var abDot1 = (figure.vertexes[figure.vertexes.Count - 1].Item1, figure.vertexes[figure.vertexes.Count - 1].Item2);
                var abDot2 = (figure.vertexes[0].Item1, figure.vertexes[0].Item2);
                var random_dot = (x, y);

                if (check_intersection(abDot1, abDot2, random_dot))
                {
                    intersections += 1;
                }

                if (intersections % 2 == 1) { dots_inside_figure += 1; }
            }

            return dots_inside_figure;
        }

        static (double, double) generate_dots(int n)
        {
            /// Генерация случайных точек
            Random random = new Random();
            double x = random.NextDouble() * n;
            double y = random.NextDouble() * n;

            return (x, y);
        }

        static double calculate_square(int size, int total_dots, int dots_inside)
        {
            /// Расчет площади
            Console.WriteLine($"{dots_inside}, {total_dots}");
            return (size) * (size) * (dots_inside / (double)total_dots);
        }


        static bool check_intersection((double, double) abDot1, (double, double) abDot2, (double, double) random_dot)
        {
            if ((abDot1.Item2 < random_dot.Item2 && abDot2.Item2 >= random_dot.Item2 || abDot2.Item2 < random_dot.Item2 && abDot1.Item2 >= random_dot.Item2) &&
                (abDot1.Item1 + (random_dot.Item2 - abDot1.Item2) / (abDot2.Item2 - abDot1.Item2) * (abDot2.Item1 - abDot1.Item1) < random_dot.Item1) &&
                (abDot1.Item2 + (random_dot.Item1 - abDot1.Item1) / (abDot2.Item1 - abDot1.Item1) * (abDot2.Item2 - abDot1.Item2) > random_dot.Item2))
            { return true; }
            return false;
        }
    }

    public class Figure
    {
        public List<(int, int)> vertexes = new List<(int, int)>();

        public void generate_values(int size)
        {
            Random random = new Random(15);
            for (int i = 0; i < size; i++)
            {
                int x_value = i;
                int y_value = random.Next(0, size + 1);
                this.vertexes.Add((x_value, y_value));
            }

        }

        public void output_values()
        {
            foreach ((int, int) vertex in this.vertexes)
            {
                Console.WriteLine($"{vertex.Item1} {vertex.Item2}");
            }
        }
    }


}
