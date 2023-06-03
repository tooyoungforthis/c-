//Сделать сортировку массива с помощью быстрой сортировки
class Program
{
    static void Main()
    {
        int[] values = RandomArray.generate_array(10);

        Console.WriteLine($"Несортированный массив\t: {string.Join(", ", values)}");

        values = QuickSort(values, 0, values.Length - 1);

        Console.WriteLine($"Отсортированный массив\t: {string.Join(", ", values)}");
    }


    static int FindPivot(int[] numbers, int minIndex, int maxIndex)
    {
        ///Нахождение элементов относительно опорного
        int pivot = minIndex - 1;
        int temp = 0;
        for (int i = minIndex; i < maxIndex; i++)
        {
            if (numbers[i] < numbers[maxIndex])
            {
                pivot++;
                temp = numbers[pivot];
                numbers[pivot] = numbers[i];
                numbers[i] = temp;
            }
        }

        // Ставимм опорный элемент на нужное место
        pivot++;
        temp = numbers[pivot];
        numbers[pivot] = numbers[maxIndex];
        numbers[maxIndex] = temp;

        return pivot;
    }


    static int[] QuickSort(int[] numbers, int minIndex, int maxIndex)
    {
        /// Реализация сортировки quicksort
        if (minIndex >= maxIndex)
        {
            return numbers;
        }

        int pivot = FindPivot(numbers, minIndex, maxIndex);
        QuickSort(numbers, minIndex, pivot - 1);
        QuickSort(numbers, pivot + 1, maxIndex);

        return numbers;
    }


}
public static class RandomArray
{
    /// генерация массива случайных чисел в диапазоне от 0 до 10
    public static int[] generate_array(int count)
    {
        Random random = new Random();
        int[] values = new int[count];

        for (int i = 0; i < count; i++)
        {
            values[i] = random.Next(0, 11);
        }

        return values;
    }
}


