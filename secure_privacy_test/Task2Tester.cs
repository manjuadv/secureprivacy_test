using System;

namespace secure_privacy_test
{
    class Task2Tester
    {
        static void Main(string[] args)
        {
            CheckString("100");
            CheckString("101");
            CheckString("1");
            CheckString("10");
            CheckString("1100");
            CheckString("11010");
            CheckString("110010");
        }
        private static void CheckString(string binaryString)
        {
            Console.WriteLine(binaryString + " : " + Task2.Task2Solution.IsGoodBinaryString(binaryString).ToYesNo());
        }
    }

    public static class Extentions
    {
        public static string ToYesNo(this bool result)
        {
            string yesOrNo = "NO";
            yesOrNo = result ? "YES" : "NO";

            return yesOrNo;
        }
    }
}
