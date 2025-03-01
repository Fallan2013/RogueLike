using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RogueLike
{
    public class Map
    {
       public Map()
        {
            underfeet = floor;
        }
        private int awarness =5;
        private (int, int) housesize = (3, 3);
        public (int, int) heroPosition = (18, 18);
        private static int mapX = 40;
        private static int mapY = 40;
        public static Cage[,] map = new Cage[mapX,mapY];
        Cage border = new Cage("#", false,false);
        public static Cage floor = new Cage(".", true,false);
        Cage hero = new Cage("h", true,true);
        Cage monster = new Cage("m", false, false);
        Cage door = new Cage("d", true, false);
        Wall wall = new Wall("@", false, false, false);
        public Cage underfeet ;
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
            HouseCreator((18,18),(5,5));
           
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
                    doorpos != (hx,hy) & map[dx,dy]!=floor )
                {
                    dexist = false;
                    map[doorpos.Item1, doorpos.Item2] = door;
                }
            }
        }
        public void mapPrinter(int mapX, int mapY)
        {
            Console.CursorVisible = false;
            Console.Clear();
            for (int Y = 0; Y < mapY; Y++)
            {
                for (int X = 0; X < mapX; X++)
                {
                    
                    if ((X > heroPosition.Item1-awarness && Y > heroPosition.Item2-awarness)&&(X< heroPosition.Item1 + awarness&& Y < heroPosition.Item2 + awarness) )
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(map[X, Y].symbol);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Thread.Sleep(800);
        }

        

        public void Move()
        {   
            int x = heroPosition.Item1;
            int y = heroPosition.Item2;

            ConsoleKeyInfo moveKey = Console.ReadKey();

            int newX = x;
            int newY = y;

            switch (moveKey.Key)
            {
                case ConsoleKey.UpArrow:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                    newY++;
                    break;
                case ConsoleKey.LeftArrow:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    newX++;
                    break;
            }
            object stepTo = map[newX, newY];
            if (map[newX, newY].block == false)
            {
                
            }

            //else
            //{
            //    map[x, y] = underfeet;
            //    heroPosition = (newX, newY);

            //    map[newX, newY] = hero;
            //    return (heroPosition);
            //}
            Cage targetCell = map[newX,newY];
            if (newX < 0 || newX >= map.GetLength(0) || newY < 0 || newY >= map.GetLength(1))
            {
                return;
            }
            if (targetCell.block)
            {
                map[x, y] = underfeet;
                heroPosition = (newX, newY);
                underfeet = targetCell;
                map[newX, newY] = hero;

            }
        }

        public class Cage
        {
            
            public string symbol   { get; set; }
            public bool block      { get; set; }
            public bool player     { get; set; }
            public Cage(string CageSymbol, bool Block, bool Player)
            {
                symbol = CageSymbol;
                block = Block;
                player = Player;
            }

        }
        public class Wall : Cage
        {
            public bool visability { get; set; }
            public Wall(string CageSymbol, bool Block, bool Player , bool Vision)
                :base(CageSymbol, Block, Player)
            {
                visability = Vision;
            }
        }
       
    }
}

