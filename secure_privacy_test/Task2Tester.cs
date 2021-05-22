using System;

namespace secure_privacy_test
{
    class Task2Tester
    {
        static void Main(string[] args)
        {
            CheckString(null);
            CheckString("");
            CheckString("   ");
            CheckString("100");
            CheckString("101");
            CheckString("1");
            CheckString("10");
            CheckString("1100");
            CheckString("11 00");
            CheckString("11010");
            CheckString("110010");
            CheckString("110010110010");
            CheckString("110010011010");
        }
        private static void CheckString(string binaryString)
        {
            Console.Write(binaryString + " : ");

            if (Task2.Task2Solution.IsGoodBinaryString(binaryString))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Good");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not Good");
            }
            Console.ResetColor();
        }
    }
}
