using ProjectTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Homework
{
    public class InvertedNumberTask : IWorkTasks
    {
        public void Execute()
        {
            ConsoleWorker.ShowMessage("Enter number for invertion:\n");
            var consoleInputResult = 0;
            var isIntValue = ConsoleWorker.GetIntFromConsoleInput(ref consoleInputResult);

            if (isIntValue)
            {
                var res = int.Parse(string.Join("", consoleInputResult.ToString().Reverse()));
                ConsoleWorker.ShowMessage(res.ToString());
            }
        }
    }
}
