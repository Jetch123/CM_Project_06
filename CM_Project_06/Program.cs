using System;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide 3 tasks");
            Console.WriteLine("Task | Worst Scenario | Average | Best Scenario");

            int worst = 0, best = 0, average = 0, examples = 13;

            //Set range of bruckets
            int range = 5;

            int[,] intNumbers = Menu.MainMenu();
            int[,] rangeMatrix = new int[2, range];

            Output.DisplayMatrix(rangeMatrix, 2, range);

            examples = Output.SetExamples();

            //Monte Carlo
            int[] inum = RandomP.GenerateRandomPlan(examples, intNumbers);
            //RandomPlan.estimationDisplay();

            best = ArrayOps.ArrayAverage(RandomP.best);
            worst = ArrayOps.ArrayAverage(RandomP.worst);

            average = ArrayOps.ArrayAverage(inum);

            Output.DisplayResults(best, worst, average, examples);

            Output.DisplayMatrix(intNumbers, intNumbers.GetLength(0), intNumbers.GetLength(1));



            rangeMatrix = Array_Buckets.Buckets(inum, range, best, worst);

            Console.WriteLine("Ranges: ");
            Output.DisplayMatrix(rangeMatrix, 2, range);


            Console.WriteLine("Probability of finishing the plan in: ");
            Output.DisplayProbability(ArrayOps.Percentage(rangeMatrix), range);

            Console.WriteLine("Accumulated probability of finishing the plan in or before: ");
            Output.DisplayProbability(ArrayOps.PercentageSum(ArrayOps.Percentage(rangeMatrix)), range);

        }
    }
}
