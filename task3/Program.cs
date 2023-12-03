// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

// Процедура создания матрицы

void InputMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = new Random().Next(0, 10);
}

//Процедура вывода матрицы
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write(matrix[i, j] + "\t");
        Console.WriteLine();
    }
}

//Процедура поиска строки с минимальной суммой элементов
void FindLine(int[,] matrix)
{
    int sum = 0;
    int minSum = int.MaxValue;
    int minIndex = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            minIndex = i;
        }
    }
    Console.WriteLine("Минимальная сумма в строке с индексом " + minIndex);
    Console.WriteLine("Минимальная сумма равна " + minSum);
}

Console.Clear();
Console.Write("Введите размер мартицы: ");
int[] size = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
int[,] matrix = new int[size[0], size[1]];
int[] array = new int[size[0]];
InputMatrix(matrix);
PrintMatrix(matrix);
FindLine(matrix);
