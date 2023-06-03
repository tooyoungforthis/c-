// Вычитание матриц

public class Program
{
    static void Main()
    {

        int rows = 3;
        int columns = 4;

        var matrix_1 = new Matrix(rows, columns);
        matrix_1.generate_values();
        matrix_1.output_matrix();

        Console.WriteLine("------------------------------------");

        var matrix_2 = new Matrix(rows, columns);
        matrix_2.generate_values();
        matrix_2.output_matrix();

        Console.WriteLine("------------------------------------\n result:");

        matrix_1.substract_matrix(matrix_2);
        matrix_1.output_matrix();
    }
}


public class Matrix
{
    public int rows;
    public int columns;

    public int[,] values;

    Random random = new Random();

    public Matrix(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        this.values = new int[this.rows, this.columns];
    }


    public void generate_values()
    {
        /// Генерация значений для матрицы
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                this.values[i, j] = random.Next(0, 10);
            }
        }
    }


    public void output_matrix()
    {
        /// Вывод матрицы в консоль
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                Console.Write($"{this.values[i, j]} ");
            }
            Console.WriteLine();
        }

    }


    public void substract_matrix(Matrix sub_matrix)
    {
        /// Вычитание матриц
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                this.values[i, j] -= sub_matrix.values[i, j];
            }
        }
    }



}