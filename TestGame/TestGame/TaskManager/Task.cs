using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class Task
    {
        public enum Type
        {
            Poop,
            Move
        }
        public enum Status
        {
            Wait,
            Exe,
            Done
        }
        public Type type
        {
            get { return type; }
            set { type = value; }
        }
        public Status status
        {
            get { return status; }
            set { status = value; }
        }
        public ArrayList paramaters = new ArrayList();

        public Task(Task.Type type, ArrayList paramaters)
        {
            this.status = Status.Wait;
            this.type = type;
            this.paramaters = paramaters;
        }
    }
}