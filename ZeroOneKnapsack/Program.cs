namespace ZeroOneKnapsack
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] profit = new int[] { 2, 3, 3, 4, 4, 5, 7, 8, 8 };
            int[] weight = new int[] { 3, 5, 7, 4, 3, 9, 2, 11, 5 };
            int capacity = 12;
            int n = profit.Length;


            var theSolutionIsOptimum = Knapsack(capacity, weight, profit, n);
            Console.WriteLine(theSolutionIsOptimum);

            Console.ReadKey();
        }

        //Returns the maximum value that can be put in a knapsack of capacity
        static int Knapsack(int capacity, int[] weight, int[] profit, int n)
        {
            //Base Case
            if (n == 0 || capacity == 0)
                return 0;

            //If weight of the nth item is more than Knapsack capacity, then this item cannot be included in the optimal solution
            if (weight[n - 1] > capacity)
                return Knapsack(capacity, weight, profit, n - 1);

            // Return the maximum of two cases: (1) nth item included (2) not included
            else
                return Max(profit[n - 1] + Knapsack(capacity - weight[n - 1], weight, profit, n - 1), Knapsack(capacity, weight, profit, n - 1));
        }

        //Maximum of two integers
        static int Max(int a, int b) { return (a > b) ? a : b; }
    }
}