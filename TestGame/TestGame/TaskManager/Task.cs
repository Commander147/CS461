using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class Task
    {
        ArrayList[] listofParams;
        status myStatus;
        internalPriorty myinternalPriorty;
        type myType;

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
        public Task(Task.status s, Task.type t, Task.internalPriorty i, ArrayList[] param)
        {
            this.myStatus = s;
            this.myType = t;
            this.myinternalPriorty = i;
            listofParams = param;
        }
    }
}