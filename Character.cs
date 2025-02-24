using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{

    internal class Character
    {
        public int chDmg;
        public int chHp;
        
        public Character(int ChDmg, int ChHp )
        {
            this.chDmg = ChDmg ;
            this.chHp = ChHp ;

        }

        public void Print()
        {
            Console.WriteLine($"Урон персонажа: {chDmg}\nЗдоровье: {chHp}"); 
        }
    }
}
