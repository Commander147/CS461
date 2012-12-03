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

        private ArrayList[] tasks = new ArrayList[3];
        private int total_size;
        private Sprite location;

        public TaskManager()
        {
            Console.WriteLine(tasks);   
        }

        public bool taskIsEmpty()
        {
            return (tasks[0].Count == 0 && tasks[1].Count == 0 && tasks[2].Count == 0);
        }

        public void taskAdd(int rank, Task task)
        {
            for (int i = 0; i < tasks[rank].Count; i++)
            {
                if (tasks[rank][i].internalPriorty <= task.internalPriorty)
                {
                    tasks[rank].Insert(i, task);
                    break;
                }
            }
        }

        public ArrayList getTask()
        {
            bool foundWaiting = false;
            List<int> destinationList = new List<int>();
            int rank = 0;
            for (int i = 0; i < tasks.Count(); i++)
            {
                if (foundWaiting == false)
                {
                    if (tasks[rank][i].currentStatus == Task.taskStatus.waiting)
                    {
                        foundWaiting = true;
                        destinationList.Add(rank);
                        destinationList.Add(i);
                    }
                    if (tasks[rank][i].currentStatus == Task.taskStatus.executing)
                    {
                        destinationList.Add(rank);
                        destinationList.Add(i);
                        break;
                    }
                    rank++;
                }
            }
            return destinationList;
        }

        //public void taskRemove(int rank, Task task)
        //{

        //}

        //public void getTaskforExe() { }

    }

}