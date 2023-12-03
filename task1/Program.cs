// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.

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

//Метод поиска значения запрашиваемой позиции
int FindPosition(int[,] matrix, int[] position)
{
    int foundPosition = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (i == position[0])
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == position[1])
                {
                    foundPosition = matrix[i, j];
                    return foundPosition;
                }
            }
        }
    }
    return int.MinValue; 
}

Console.Clear();
Console.Write("Введите размер мартицы: ");
int[] size = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
int[,] matrix = new int[size[0], size[1]];
Console.Write("Введите позицию элемента: ");
int[] position = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
InputMatrix(matrix);
PrintMatrix(matrix);

//Вывод искомого значения
int foundPosition = FindPosition(matrix, position);
if (foundPosition != int.MinValue)
Console.WriteLine("Значение искомой позиции: " + foundPosition);
else
Console.WriteLine("Такой позиции нет.");