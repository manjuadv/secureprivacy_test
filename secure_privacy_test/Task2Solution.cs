using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public static class Task2Solution
    {
        public static bool IsGoodBinaryString(string binaryString)
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
}
