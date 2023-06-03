//За каждый месяц банк начисляет к сумме вклада N% от суммы. Напишите программу,
//в которую пользователь вводит сумму вклада, количество месяцев и процент начислений
//и вычисляет конечную сумму вклада с учетом начисления процентов за каждый месяц
//с капитализацией и без неё.

namespace Investment
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите сумму вклада investment = ");
                uint investment = Convert.ToUInt32(Console.ReadLine());

                Console.Write("Введите ежемесячные проценты n% = ");
                uint n_per = Convert.ToUInt32(Console.ReadLine());

                Console.Write("Введите кол-во месяцев n_months = ");
                uint n_months = Convert.ToUInt32(Console.ReadLine());


                double withCapitalization = with_capitalization((double)investment, (double)n_per, (double)n_months);
                Console.WriteLine($"Сумма вклада с капитализацией = {withCapitalization}");

                double withoutCapitalization = without_capitalization((double)investment, (double)n_per, (double)n_months);
                Console.Write($"Сумма вклада без капитализацией = {withoutCapitalization}");
            }
            catch
            {
                Console.WriteLine("Значения должны быть неотрицательными");
            }


        }

        static double with_capitalization(double investment, double n_per, double n_months)
        /// Сложные проценты
        {
            return investment * Math.Pow(1 + n_per / 100, n_months);
        }

        static double without_capitalization(double investment, double n_per, double n_months)
        /// Простые проценты
        {
            return investment * (1 + n_per * n_months / 100);
        }
    }
}
