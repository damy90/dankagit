using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
                        {1,3,2,2,2,4},
                        {3,3,3,2,4,4},
                        {4,3,1,2,3,3},
                        {4,3,1,3,3,1},
                        {4,3,3,3,1,1}
        };
        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        int countMax = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int count = CountArea(matrix, visited, row, col, matrix[row, col]);
                if (countMax < count)
                    countMax = count;
            }
        Console.WriteLine(countMax);
    }
    //Count adjacent elements equal to matrix[row, col] starting from matrix[row, col]
    static int CountArea(int[,] matrix, bool[,] visited, int row, int col, int value)
    {
        //end the recursion if the index is outside the array or the element is != to the previois element or the element has already been added to an area
        if (col < 0 || row < 0 || col >= matrix.GetLength(1) || row >= matrix.GetLength(0) || matrix[row, col] != value || visited[row, col])
            return 0;
        visited[row,col] = true;//mark element as visited
        //count equal elements adjacent to the curent one + the curent one(+1)
        return CountArea(matrix, visited, row + 1, col, value) + CountArea(matrix, visited, row - 1, col, value)
            + CountArea(matrix, visited, row, col+1, value) + CountArea(matrix, visited, row , col-1, value) + 1;

    }
}
