using ProjectTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Homework
{
    public class SumOfArrayElementsTask : IWorkTasks
    {
        private int[,] twoDimensionalArray;
        public SumOfArrayElementsTask()
        {
            twoDimensionalArray = new int[5, 5];
            FillAraayRandomNumbers();
        }
        public void Execute()
        {
           var result = GetSumElemetsBetweenMinAndMaxElements();

            ConsoleWorker.ShowMessage(result.ToString());
        }

        private void FillAraayRandomNumbers()
        {
            var rnd = new Random();

            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    twoDimensionalArray[i, j] = rnd.Next(0, 101);
                }
            }
        }

        private int GetSumElemetsBetweenMinAndMaxElements()
        {
            var sum = 0;
            var minIndex = new int[2];
            var maxIndex = new int[2];

            var minValue = twoDimensionalArray[0, 0];
            var maxValue = twoDimensionalArray[0, 0];

            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    if (twoDimensionalArray[i, j] < minValue)
                    {
                        minValue = twoDimensionalArray[i, j];
                        minIndex = new int[2] { i, j };
                    }

                    if (twoDimensionalArray[i, j] > maxValue)
                    {
                        maxValue = twoDimensionalArray[i, j];
                        maxIndex = new int[2] { i, j };
                    }
                }
            }

            var useMinArraAsMin = true;

            if (minIndex[0] > maxIndex[0])
            {
                useMinArraAsMin = false;
            }

            if (minIndex[1] > maxIndex[1] && minIndex[0] > maxIndex[0] && useMinArraAsMin)
            {
                useMinArraAsMin = false;
            }

            var startSum = 0;

            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    var currentIndex = $"{i}{j}";

                    if (useMinArraAsMin)
                    {
                        var saveIndexMin = $"{minIndex[0]}{minIndex[1]}";
                        var saveIdexMax = $"{maxIndex[0]}{maxIndex[1]}";

                        if (startSum == 1)
                        {
                            if (currentIndex != saveIdexMax)
                            {
                                sum += twoDimensionalArray[i, j];
                            }
                            else
                            {
                                startSum = -1;
                            }
                        }

                        if (saveIndexMin == currentIndex && startSum == 0)
                        {
                            startSum++;
                        }
                    }
                    else
                    {
                        var saveIndexMax = $"{minIndex[0]}{minIndex[1]}";
                        var saveIndexMin = $"{maxIndex[0]}{maxIndex[1]}";

                        if (startSum == 1)
                        {
                            if (currentIndex != saveIndexMax)
                            {
                                sum += twoDimensionalArray[i, j];
                            }
                            else
                            {
                                startSum = -1;
                            }
                        }

                        if (saveIndexMin == currentIndex && startSum == 0)
                        {
                            startSum++;
                        }
                    }
                }
            }

            return sum;
        }
    }
}
