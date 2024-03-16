using ProjectTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Homework
{
    public class CyclicDisplacementTask : IWorkTasks
    {
        public void Execute()
        {
           var result = CyclicDisplacementToTheLeft(12345, 3);

            ConsoleWorker.ShowMessage(result.ToString());
        }

        private int CyclicDisplacementToTheLeft(int value, int count)
        {
            string sign = value < 0 ? "-" : "";
            string digits = value.ToString().TrimStart('-');

            count %= digits.Length;

            if (count == 0)
                return value;

            if (count < 0)
                count += digits.Length;

            return int.Parse(
                sign +
                digits.Substring(count, digits.Length - count) +
                digits.Substring(0, count)
            );
        }
    }
}
