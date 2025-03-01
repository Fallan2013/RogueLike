using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RogueLike
{

    internal class Character
    {
        public int chDmg;
        public int chHp;
        public int chFov;
        public Character(int ChDmg, int ChHp, int hFov)
        {
            this.chDmg = ChDmg;
            this.chHp = ChHp;
            this.chFov = hFov;   
        }

        public void Print()
        {
            Console.WriteLine($"Урон персонажа: {chDmg}\nЗдоровье: {chHp}\n Внимательность: {chFov}");
        }


    }

}
