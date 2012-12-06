using System;

using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TestGame
{
    class TaskManager
    {
        private ArrayList TaskQueue = new ArrayList();

        public TaskManager()
        {
        }

        public bool taskIsEmpty()
        {
            return (TaskQueue.Count == 0 );
        }

        public void AddTask(Task newTask)
        {
            TaskQueue.Add(newTask);
        }

        public void RemoveTask()
        {
            //Console.WriteLine("Remove");
            if (taskIsEmpty() == false)
            {
                TaskQueue.RemoveAt(0);
            }
        }

        public Task GetTask()
        {
            if (taskIsEmpty() == false)
                return (Task)TaskQueue[0];
            else
            {
                return null;
            }
        }
    }

}