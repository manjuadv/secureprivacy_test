using System;

namespace secure_privacy_test
{
    class Program
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
            Console.WriteLine(binaryString + " : " + IsGoodBinaryString(binaryString).ToYesNo());
        }
        private static bool IsGoodBinaryString(string binaryString)
        {
            char[] digits = binaryString.ToCharArray();
            int counter = 0;
            foreach (var digit in digits)
            {
                if (digit == '1')
                {
                    counter++;
                }
                else if (digit == '0')
                {
                    counter--;
                }
                else
                {
                    return false;
                }
                if (counter < 0)
                {
                    return false;
                }
            }
            if (counter == 0)
                return true;
            return false;
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
