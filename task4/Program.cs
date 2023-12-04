// Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец,
// на пересечении которых расположен наименьший элемент массива.
// Под удалением понимается создание нового
// двумерного массива без строки и столбца


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

//Процедура поиска индексов строки и столбца с минимальным элементом
void FindMin(int[,] matrix, out int foundMinRow, out int foundMinColumn)
{
    int minElement = int.MaxValue;
    foundMinRow = 0;
    foundMinColumn = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minElement)
            {
                minElement = matrix[i, j];
                foundMinRow = i;
                foundMinColumn = j;
            }
        }
    }
    Console.Write("Строка " + foundMinRow + " ");
    Console.WriteLine("Столбец " + foundMinColumn);
    return;
}

//Процедура создания новой матрицы без строки и столбца найденного минимального элемента
void RemoveRowColumn(int[,] matrix, int minRow, int minColumn, out int[,] resultMatrix)
{
    int numRows = matrix.GetLength(0);
    int numColumns = matrix.GetLength(1);
    resultMatrix = new int[numRows - 1, numColumns - 1];

    for (int i = 0, newRow = 0; i < numRows; i++)
    {
        if (i == minRow)
            continue;

        for (int j = 0, newColumn = 0; j < numColumns; j++)
        {
            if (j == minColumn)
                continue;
            resultMatrix[newRow, newColumn] = matrix[i, j];
            newColumn++;
        }
        newRow++;
    }
}

Console.Clear();
Console.Write("Введите размер мартицы: ");
int[] size = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
int[,] matrix = new int[size[0], size[1]];
int minRow, minColumn;
InputMatrix(matrix);
PrintMatrix(matrix);
FindMin(matrix, out minRow, out minColumn);
Console.WriteLine("Минимальный элемент: " + matrix[minRow, minColumn]);
int[,] newMatrix;
RemoveRowColumn(matrix, minRow, minColumn, out newMatrix);
Console.WriteLine("Новая матрица без минимальной строки и столбца:");
PrintMatrix(newMatrix);
