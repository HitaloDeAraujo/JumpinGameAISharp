using System;
using System.Collections.Generic;
using System.Threading;

namespace JumpinGameAISharpUI
{
    public class UIEngine
    {
        private static int visibleC = 80;
        private static Random random = new Random();
        private static string[] cloud = new string[6];
        private static string[,] matrix;

        private static ConsoleColor defaultBackgroundColor = Console.BackgroundColor;
        private static ConsoleColor defaultForegroundColor = Console.ForegroundColor;

        public static void GameLoop()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            int l = 20;
            int c = 110;

            matrix = new string[l, c];

            setCloud();

            for (int i = 0; i < l; i++)
                for (int j = 0; j < c; j++)
                    matrix[i, j] = " ";

            for (int i = 0; i < c; i++)
            {
                int size = random.Next(0, 2);
                matrix[l - 1, i] = size == 1 ? "," : ".";
            }

            writeMatrix();

            insertBar(l, c);

            insertCloud();

            writeMatrix();

            int ticks = 0;
            int lastTickCloud = 0;
            int nextBar = 20;

            while (!matrixToString().Replace(",", "").Replace(".", "").Trim().Equals(""))
            {
                updateMatrix(ticks);

                writeMatrix();
                Thread.Sleep(70);

                ticks++;

                if (ticks - lastTickCloud == nextBar && !matrixToString().Contains("~"))
                    insertCloud();

                if (ticks - lastTickCloud == nextBar)
                {
                    insertBar(l, c);
                    lastTickCloud = ticks;

                    nextBar = new Random().Next(25, 60);
                }
            }
        }

        private static void insertCloud()
        {
            string[,] cloud = getCloud();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 30; j++)
                    matrix[i, j + 79] = cloud[i, j];
        }

        private static void insertBar(int l, int c)
        {
            int barH = new Random().Next(5, 15);
            int barW = 6;

            int pointX = c - barW;

            for (int i = pointX; i < pointX + barW; i++)
                for (int j = l - 2; j > barH; j--)
                    matrix[j, i - 1] = "(";
        }

        private static void setCloud()
        {
            cloud[0] = @"         .-~~~-.";
            cloud[1] = @"  .- ~~-/       \_ _";
            cloud[2] = @" /                   ~-.";
            cloud[3] = @"|                        \";
            cloud[4] = @" \                       .' ";
            cloud[5] = @"   ~- ._____________. - ~ ";

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

        private static string matrixToString()
        {
            string matrixString = string.Empty;

            int l = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < l; i++)
                for (int j = 0; j < c; j++)
                    matrixString += matrix[i, j];

            return matrixString;
        }

        private static string[,] updateMatrix(int tick)
        {
            int l = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            if (tick % 3 == 0)
            {
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < c - 1; j++)
                        matrix[i, j] = matrix[i, j + 1];
            }

            if (tick % 2 == 0)
                for (int i = 6; i < l - 1; i++)
                    for (int j = 0; j < c - 1; j++)
                        matrix[i, j] = matrix[i, j + 1];

            int indice = l - 1;
            for (int j = 0; j < c - 1; j++)
            {
                matrix[indice, j] = matrix[indice, j + 1];

                int size = random.Next(0, 2);
                matrix[l - 1, c - 1] = size == 1 ? "," : ".";
            }

            return matrix;
        }

        private static void writeMatrix()
        {
            Console.Clear();

            int l = matrix.GetLength(0);
            int c = visibleC;

            List<string> clouldChar = new List<string>() { "\\", "/", "_", "|", "~", "-", "'", "." };

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] == "(")
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    else if (i > l - 2)
                        Console.BackgroundColor = ConsoleColor.Green;
                    else if (clouldChar.Contains(matrix[i, j]))
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(matrix[i, j]);

                    Console.BackgroundColor = defaultBackgroundColor;
                    Console.ForegroundColor = defaultForegroundColor;
                }

                Console.BackgroundColor = defaultBackgroundColor;

                Console.Write("\n");
            }
        }
    }
}