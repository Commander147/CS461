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

        private ArrayList[] prioityQueue = new ArrayList[3];
        private int total_size;
        private Vector2 currentTask = new Vector2();

        public TaskManager()
        {
            prioityQueue[0] = new ArrayList();

        }

        public bool taskIsEmpty()
        {
            return (prioityQueue[0].Count == 0 && prioityQueue[1].Count == 0 && prioityQueue[2].Count == 0);
        }

        public void taskAdd(int rank, Task task)
        {
            for (int i = 0; i < prioityQueue[rank].Count; i++)
            {
                if (prioityQueue[rank][i].internalPriority <= task.internalPriority)
                {
                    prioityQueue[rank].Insert(i, task);
                    break;
                }
            }
        }

        public ArrayList getTask()
        {
            bool foundWaiting = false;
            List<int> destinationList = new List<int>();
            int rank = 0;
            for (int i = 0; i < prioityQueue.Count(); i++)
            {
                if (foundWaiting == false)
                {
                    if (prioityQueue[rank][i].currentStatus == Task.taskStatus.waiting)
                    {
                        foundWaiting = true;
                        destinationList.Add(rank);
                        destinationList.Add(i);
                    }
                    if (prioityQueue[rank][i].currentStatus == Task.taskStatus.executing)
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