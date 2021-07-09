using System;
using System.Threading;

namespace JumpinGameAISharpUI
{
    class Program
    {
        //static Stack st = new Stack();
        static int visibleC = 80;
        static Random random = new Random();
        static string[] cloud = new string[6];
        static string[,] matrix;

        static void Main(string[] args)
        {
            int l = 20;
            int c = 110;
           
            matrix = new string[l, c];

            setCloud();

            for (int i = 0; i < l; i++)
                for (int j = 0; j < c; j++)
                    matrix[i, j] = " ";

            int barH = 10;
            int barW = 5;

            int pointX = c - barW;

           
            for (int i = 0; i < c; i++)
            {
                int size = random.Next(0, 2);
                matrix[l - 1, i] = size == 1 ? "," : ".";
            }

            SaveMatrix(matrix);

            WriteMatrix();

            for (int i = pointX; i < pointX + barW; i++)
                for (int j = l - 1; j > barH; j--)
                    matrix[j, i - 1] = "(";

            string[,] cloud = getCloud();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 30; j++)
                    matrix[i , j +  79] = cloud[i, j];

            SaveMatrix(matrix);

            WriteMatrix();

            int ticks = 0;

            while (MatrixToString().Contains("("))
            {
                SaveMatrix(UpdateMatrix());

                WriteMatrix();
                Thread.Sleep(250);

                ticks++;

                //SaveMatrix(matrix);
            }
        }

        private static void setCloud()
        {
            cloud[0] = @"         .-~~~-.";
            cloud[1] = @"  .- ~~-(       )_ _";
            cloud[2] = @" /                   ~-.";
            cloud[3] = @"|                        \";
            cloud[4] = @" \                       .'";
            cloud[5] = @"   ~- ._____________. - ~";

            string[,] cloudMatrix = new string[6, 30];

            for (int i = 0; i < cloud.Length; i++)
            {
                char[] lineSplit = cloud[i].ToCharArray();

                for (int j = 0; j < lineSplit.Length; j++)
                    cloudMatrix[i, j] = lineSplit[j].ToString();
            }
        }

        private static string[,] getCloud()
        {
            string[,] cloudMatrix = new string[6, 30];

            for (int i = 0; i < cloud.Length; i++)
            {
                char[] lineSplit = cloud[i].ToCharArray();

                for (int j = 0; j < lineSplit.Length; j++)
                    cloudMatrix[i, j] = lineSplit[j].ToString();
            }

            return cloudMatrix;
        }

        private static string MatrixToString()
        {
            string matrixString = string.Empty;

            //string[,] matrix = GetMatrix();

            int l = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < l; i++)
                for (int j = 0; j < c; j++)
                    matrixString += matrix[i, j];

            return matrixString;
        }

        private static string[,] UpdateMatrix()
        {
            //string[,] matrix = GetMatrix();

            int l = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < l; i++)
                for (int j = 0; j < c - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];

                    int size = random.Next(0, 2);
                    matrix[l - 1, c - 1] = size == 1 ? "," : ".";
                }

            return matrix;
        }

        //private static void CleanFrameMatrix()
        //{
        //    if (st.Count > 1)
        //        st.Pop();
        //}

        //private static string[,] GetMatrix()
        //{
        //   return (string[,])st.Peek();
        //}

        private static void SaveMatrix(string[,] matrix)
        {
            //int l = matrix.GetLength(0);
            //int c = matrix.GetLength(1);

            //string[,] newMatrix = new string[l, c];

            //for (int i = 0; i < l; i++)
            //    for (int j = 0; j < c; j++)
            //        newMatrix[i, j] = matrix[i, j];

            //st.Push(newMatrix);
        }

        private static void WriteMatrix()
        {
            Console.Clear();

            //string[,] matrix = GetMatrix();
            int l = matrix.GetLength(0);
            int c = visibleC;

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                    Console.Write(matrix[i, j]);

                Console.Write("\n");
            }
        }
    }
}