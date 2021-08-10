using System;

namespace MinStackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                //Object - Methods input            
                string inFunctionString = string.Empty;

                //Object Methods input             
                string inValueString = string.Empty;

                //Parenthesis expression input
                string testExpression = string.Empty;

                //Exit parameter
                string exitValue = string.Empty;

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                            MinStack Implementation Testing                                ");
                Console.WriteLine("                            ===============================                                ");
                Console.WriteLine();
                Console.WriteLine(@"Enter Object/Methods input list, eg: [""MinStack"",""push"", ""push"", ""push"", ""getMin, ""pop""]");
                inFunctionString = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter input values list, eg: [[],[4], [-100], [55],[],[]]");
                inValueString = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                //Process MinStack
                Console.WriteLine("Processing output: " + Utility.processMinStackMethods(inFunctionString, inValueString));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                       Parenthesis Expression validation Testing                                ");
                Console.WriteLine("                       =========================================                                ");
                Console.WriteLine();

                Console.WriteLine("Enter an parenthesis expression input string, eg: {{}}[]]](([]{})");
                testExpression = Console.ReadLine();
                Console.WriteLine();

                //Test parenthesis expression for validity
                Console.WriteLine("Is the expression valid? " + Utility.isValidParensExpression(testExpression));
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Press any key to continue testing or Exit to quit: ");

                exitValue = Console.ReadLine();
                if (exitValue.ToLower() == "exit") break;
            } while (true);
        }
    }
}
