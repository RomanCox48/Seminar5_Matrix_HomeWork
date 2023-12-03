// Задайте двумерный массив. Напишите программу, которая поменяет местами 
// первую и последнюю строку массива.

// Процедура создания матрицы
using System.Numerics;

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

//Процедура перестановки 1-й и последней строк
void ReleaseMatrix(int[,] matrix)
{
    int[] temp = new int[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            temp[j] = matrix[0, j];
            matrix[0,j] = matrix[matrix.GetLength(1)-1, j];
            matrix[matrix.GetLength(1)-1, j]=temp[j];
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

Console.Clear();
Console.Write("Введите размер мартицы: ");
int[] size = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
int[,] matrix = new int[size[0], size[1]];
int[] temp = new int[size[1]];
InputMatrix(matrix);
PrintMatrix(matrix);
Console.WriteLine("Измененная матрица: ");
ReleaseMatrix(matrix);
