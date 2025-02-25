using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class Map
    {
        public string[,] mapString = new string[10, 10] {
                { "#", "#","#","#", "#","#","#","#","#", "#" },
                { "#", ".",".",".", ".",".",".",".","m", "#" },
                { "#", ".",".",".", ".",".",".",".",".", "#" },
                { "#", ".",".",".", ".",".",".",".",".", "#" },
                { "#", ".",".",".", ".","h",".",".",".", "#" },
                { "#", ".",".",".", ".",".",".",".",".", "#" },
                { "#", ".",".",".", ".",".",".",".",".", "#" },
                { "#", ".",".",".", ".",".",".",".",".", "#" },
                { "#", ".",".",".", ".",".",".",".",".", "#" },
                { "#", "#","#","#", "#","#","#","#","#", "#" },
            };
        public string Hero = "h";
        public string Monster = "m";
        public string Wall = "#";
        public string Floor = ".";
        public int x = 5;
        public int y = 4;
        public Map()
        {  //Здесь создаётся карта 10х10
            while (true)
            {
                Console.Clear();
                int rows = mapString.GetUpperBound(0) + 1;
                int columns = mapString.Length / rows;

                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Console.Write(mapString[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }

        public static void  MapMove(int visota, int shirina, out int resultX, out int resultY)
        {
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "w": resultX = visota + 1;
                    break;
                case "s":
                    resultX = visota -1;
                    break;
                case "a":
                    resultY = shirina -1;
                    break;
                case "d":
                    resultY = shirina + 1;
                    break;

            }
        }

        //public static void PrintMap<T>(T[,] matrix)
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            Console.Write(matrix[i, j] + "\t");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}

