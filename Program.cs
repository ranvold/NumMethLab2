namespace NumMethLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double e = 0.001;

            Console.WriteLine("Choose your method:\n" +
                "1. Square root method\n" +
                "2. Jacobi method\n" +
                "3. Simple iteration method\n");

            string methodNum = Console.ReadLine();

            switch (methodNum)
            {
                case "1":
                    SquareRootMethod.RunSquareRootMethod(e);
                    break;
                case "2":
                {
                    if (!JacobiMethod.Check())
                    {
                        Console.WriteLine("The condition of diagonal advantage is not fulfilled.");
                        break;
                    }
                    JacobiMethod.RunJacobiMethod(e);
                }
                    break;
                case "3":
                    SimpleIterMethod.RunSimpleIterMethod(e);
                    break;
            }
            Console.WriteLine();
        }
    }
}