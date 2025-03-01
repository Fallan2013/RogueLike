using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RogueLike
{
    internal class Map
    { private (int, int) housesize = (3, 3);
        public (int, int) heroPosition = (18, 18);
        private static int mapX = 40;
        private static int mapY = 40;
        Cage[,] map = new Cage[mapX,mapY];
        Cage border = new Cage("#", true);
        Cage floor = new Cage(".", false);
        Cage hero = new Cage("h", false);
        Cage monster = new Cage("m", false);
        Cage door = new Cage("d", false);
        Wall wall = new Wall("@", false, false);
        public void mapCreater(int mapX, int mapY)
        {
            for (int Y = 0; Y < mapY; Y++)
            {
                for (int X = 0; X < mapX; X++)
                {
                    if (X == 0 || X == mapX - 1 || (Y == 0 || Y == mapY - 1))
                    {
                        map[X, Y] = border;
                    }
                    else
                    {
                        map[X, Y] = floor;
                    }
                }
            }

            map[heroPosition.Item1, heroPosition.Item2] = hero;
            map[2, 2] = monster;
            HouseCreator((10,10),(5,5));
        }

        public void HouseCreator((int,int) houseCenter,(int,int)houseSize)
        {
            int h1 = houseSize.Item1 / 2;
            int h11 = houseSize.Item1 - h1 - 1;
            int h2 = houseSize.Item2 / 2;
            int h22 = houseSize.Item2-h2-1;
            int hx = houseCenter.Item1;
            int hy = houseCenter.Item2;
            Random rand = new Random();
            bool dexist = true;
            int dx;
            int dy;
            int doorX = rand.Next(hx - h1, hx + h11 + 1); 
            int doorY = rand.Next(hy - h2, hy + h22 + 1);
            for (int x = hx - h1; x <= hx + h11; x++)
            {
                for (int y = hy - h2; y <= hy + h22; y++)
                {
                    if (x == hx - h1 || x == hx + h11 || y == hy - h2 || y == hy + h22 )
                    {
                        map[x, y] = wall;
                    }
                }
            }
            while (dexist)
            {   
                dx = rand.Next(hx -h1, hx + h11+1);
                dy = rand.Next(hy - h2, hy + h22+1);
                (int, int) doorpos = (dx, dy);
                if (doorpos != (hx - h1, hy - h2) &
                    doorpos != (hx - h1, hy + h22) &
                    doorpos != (hx + h11, hy - h2) &
                    doorpos != (hx + h11, hy + h22) &
                    doorpos != (hx,hy))
                {
                    dexist = false;
                    map[doorpos.Item1, doorpos.Item2] = door;
                }
            }



        }
        public void mapPrinter()
        { while (true)
            {
               
                Console.Clear();
                for (int Y = 0; Y < mapY; Y++)
                {
                    for (int X = 0; X < mapX; X++)
                    {
                        Console.Write(map[X, Y].symbol);
                    }
                    Console.WriteLine();
                }
                Move();
               
                Thread.Sleep(1000);
            }


        }
        
        public (int, int) Move()
        {
            int x = heroPosition.Item1;
            int y = heroPosition.Item2;
            int X =x;
            int Y =y;
            Console.SetCursorPosition(X, Y);
            ConsoleKeyInfo moveKey = Console.ReadKey();
          
            switch (moveKey.Key)
            {
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
            }
            object underfeet = map[x,y];
            object stepTo = map[X, Y];
            if (map[X,Y].block == false)
            {
               
            }
            else
            {
                heroPosition = (X, Y);
                underfeet = stepTo;
                map[X, Y] = hero;
            }


            return (heroPosition);
        }

        public class Cage
        {
            
            public string symbol { get; set; }
            public bool block { get; set; }
            public Cage(string CageSymbol, bool Block)
            {
                symbol = CageSymbol;
                block = block;
            }

        }
        public class Wall : Cage
        {
            public bool visability { get; set; }
            public Wall(string CageSymbol, bool Block, bool Vision)
                :base(CageSymbol, Block)
            {
                visability = Vision;
            }
        }
       
    }
}

