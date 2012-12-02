using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class Task
    {
        public ArrayList[] listofParams;
        public enum status
        {
            waiting,
            executing,
            done
        }
        public enum internalPriorty
        {
            low,
            mid,
            high
        }
        public enum type
        {
            poop,
            food
        }

    }
}
