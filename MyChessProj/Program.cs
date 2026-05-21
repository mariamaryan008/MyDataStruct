using MyChessProj;

//PrintMatrixMainDiagonal(8);

//PrintMatrixAuxiliaryDiagonal(5);

//MyPointer p1 = new MyPointer(1, 3);
//MyPointer p2 = new MyPointer(1, 6);
//Console.WriteLine(CheckTheRook(p1, p2));

//MyPointer p3 = new MyPointer(1, 3);
//MyPointer p4 = new MyPointer(1, 6);
//Console.WriteLine(CheckTheKnight(p3, p4));

//void PrintMatrixMainDiagonal(int matrixSize)
//{
//	char[,] matrix = new char[matrixSize, matrixSize];
//	for (int i = 0; i < matrixSize; i++)
//	{
//		for (int j = 0;	j< matrixSize; j++)
//		{
//            if (i == j)
//                matrix[i, j] = '#';
//            else
//                matrix[i, j] = '*';
//            Console.Write(matrix[i, j].ToString() + '\t');
//        }
//        Console.WriteLine();
//	}
//    char[] newarr = new char[matrixSize];
//	for (int i = 0; i < matrixSize; i++)
//	{
//		newarr[i] = matrix[i,i];
//	}
//    Console.WriteLine(newarr);
//}



//void PrintMatrixAuxiliaryDiagonal(int matrixSize)
//{
//    char[,] matrix = new char[matrixSize, matrixSize];
//    for (int i = 0; i < matrixSize; i++)
//    {
//        for (int j = 0; j < matrixSize; j++)
//        {
//            if (i + j == matrixSize - 1)
//                matrix[i, j] = '#';
//            else
//                matrix[i, j] = '*';
//            Console.Write(matrix[i, j].ToString() + '\t');
//        }
//        Console.WriteLine();
//    }
//    char[] newarr = new char[matrixSize];
//    for (int i = 0; i < matrixSize; i++)
//    {
//        for(int j = 0;j < matrixSize; j++)
//        {
//            if (i+j==matrixSize-1)
//            {
//                newarr[i]=matrix[i,j];
//            }
//        }
//    }
//    Console.WriteLine(newarr);
//}

//bool CheckTheRook(MyPointer p1, MyPointer p2)
//{
//    if (p1.x == p2.x || p1.y == p2.y)
//        return true;
//    return false;
//}

//bool CheckTheKnight(MyPointer p1, MyPointer p2)
//{
//    int a = Math.Abs(p1.x - p2.x);
//    int b = Math.Abs(p1.y - p2.y);
//    if ((a==2 && b==1) || (a==1 && b==2))
//        return true;
//    return false;
//}


MyPointer p7 = new MyPointer(4, 2);
MyPointer p8 = new MyPointer(5, 3);

Console.WriteLine(CheckTheBishop(p7, p8));




int[,] matrix = new int[8, 8];


for (int i = 0; i < 8; i++)
    for (int j = 0; j < 8; j++)
        matrix[i, j] = -1;

MyPointer p5 = new MyPointer(4, 2);
MyPointer p6 = new MyPointer(5, 7);

CountTheSteps(p5, p6, matrix);


static void printMatrix(int[,] matrix)
{
    Console.WriteLine();
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
            Console.Write(matrix[i, j] + "\t");
        Console.WriteLine();
    }
}


static void CountTheSteps(MyPointer start, MyPointer target, int[,] matrix)
{
    matrix[start.x, start.y] = 0;

    bool changed = true;

    while (changed)
    {
        changed = false;

        int[,] moves =
        {
            {-2, -1}, {-2, 1},
            { 2, -1}, { 2, 1},
            {-1, -2}, {-1, 2},
            { 1, -2}, { 1, 2}
        };

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (matrix[x, y] != -1)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int newX = x + moves[i, 0];
                        int newY = y + moves[i, 1];

                        if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8 && matrix[newX, newY] == -1)
                        {
                            matrix[newX, newY] = matrix[x, y] + 1;
                            changed = true;
                        }
                    }
                }
            }
        }
    }
    printMatrix(matrix);
    Console.WriteLine(matrix[target.x, target.y]);
}



bool CheckTheBishop(MyPointer p1, MyPointer p2)
{
    int a = Math.Abs(p1.x - p2.x);
    int b = Math.Abs(p1.y - p2.y);
    if (a == b)
        return true;
    return false;
}


Console.WriteLine(CheckTheBishopWithEx(new MyPointer(1, 1), new MyPointer(4,4), new MyPointer(5,5)));

bool IsBetween(MyPointer start, MyPointer end, MyPointer ex)
{
    if (!CheckTheBishop(start, end))
        return false;

    if (!CheckTheBishop(start, ex))
        return false;

    if (!CheckTheBishop(ex, end))
        return false;

    return
        (ex.x - start.x) * (end.x - start.x) >= 0 &&
        (ex.y - start.y) * (end.y - start.y) >= 0 &&
        Math.Abs(ex.x - start.x) <= Math.Abs(end.x - start.x);
}
bool CheckTheBishopWithEx(MyPointer start, MyPointer end, MyPointer ex)
{
    if (!CheckTheBishop(start, end))
        return false;

    if (IsBetween(start, end, ex))
        return false;

    return true;
}