using ProjectTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Homework
{
    public class FactorialTask : IWorkTasks
    {
        public void Execute()
        {
            int inputValue = 0;
            ConsoleWorker.ShowMessage("Write number for recurtion: ");
            var inputValueIsInt = ConsoleWorker.GetIntFromConsoleInput(ref inputValue);

            if (inputValueIsInt)
            {
                var recurtionResult = FactorialRecursion(inputValue);
                ConsoleWorker.ShowMessage(recurtionResult.ToString());
            }
            else
            {
                ConsoleWorker.ShowMessage("Input value is not recurtion: ");
            }
        }

        private double FactorialRecursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * FactorialRecursion(number - 1);
        }
    }
}
