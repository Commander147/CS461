using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class MonsterStats
    {

        public int hunger
        {
            set { hunger = value; }
            get { return hunger; }
        }
        public int thirst
        {
            set { thirst = value; }
            get { return thirst; }
        }
        public int exp
        {
            set { exp = value; }
            get { return exp; }
        }
        public int hp
        {
            set { hp = value; }
            get { return hp; }
        }
        public string name
        {
            set { name = value; }
            get { return name; }
        }

        public MonsterStats(int hung, int t, int xp, int hp, string name)
        {
            this.hunger = hung;
            this.thirst = t;
            this.exp = xp;
            this.hp = hp;
            this.name = name;
        }
    }
}
