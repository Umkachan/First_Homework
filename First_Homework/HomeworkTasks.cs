using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Homework
{
    public enum HomeworkTasks
    {
        None = 0,
        [Description("Factorial.")]
        Factorial = 1,
        [Description("Inverted number.")]
        InvertedNumber = 2,
        [Description("Cyclical movement to the left.")]
        CyclicDisplacement = 3,
        [Description("Summing array elements.")]
        SumOfArrayElements = 4
    }
}
