using ProjectTools;
using ProjectTools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Homework
{
    public class WorkProgram
    {
        private Dictionary<HomeworkTasks, IWorkTasks> tasks;
        public WorkProgram()
        {
            tasks = new Dictionary<HomeworkTasks, IWorkTasks>()
            {
             { HomeworkTasks.Factorial, new FactorialTask()},
             { HomeworkTasks.InvertedNumber, new InvertedNumberTask()},
             { HomeworkTasks.CyclicDisplacement, new CyclicDisplacementTask()},
             { HomeworkTasks.SumOfArrayElements, new SumOfArrayElementsTask()}
            };
        }
        public void Start()
        {
            if (tasks.Any())
            {
                foreach (var taskKey in tasks.Keys)
                {
                    ConsoleWorker.ShowMessage(EnumHelper.GetEnumDescription(taskKey));
                    tasks[taskKey].Execute();
                    ConsoleWorker.ShowMessage("_______________________________");
                }
            }
        }
    }
}
