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
        private Type _type;
        public Type type
        {
            get { return _type; }
            set { _type = value; }
        }
        private Status _status;
        public Status status
        {
            get { return _status; }
            set { _status = value; }
        }
        public ArrayList paramaters = new ArrayList();

        public Task(Task.Type type, ArrayList paramaters)
        {
            this._status = Status.Wait;
            this._type = type;
            this.paramaters = paramaters;
        }
    }
}