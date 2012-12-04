using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace TestGame
{
    class MonsterStatus
    {
        private int _Thirst;
        public int Thirst
        {
            get { return _Thirst; }
            set { _Thirst = value; }
            
        }
        private int _exp;
        public int exp
        {
            get { return _exp; }
            set { _exp = value; }

        }
        private int _hp;
        public int hp
        {
            get { return _hp; }
            set { _hp = value; }

        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }

        }

        public MonsterStatus( int t, int xp, int hp, string name)
        {
            this._Thirst = t;
            this._exp = xp;
            this._hp = hp;
            this._name = name;
        }
    }
}
