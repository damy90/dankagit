using System;
//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
class Program
{
    static void Main()
    {
        int fromBase = 16;//s
        //Number to be converted (input number).
        //Single didgits can be larger than 9 and even 15 depending on its base.
        int[] didgits = { 1, 15 };
        int toBase=10;//d

        if (ErrorCheck(didgits, fromBase, toBase))//call function to check if the conditions are valid
        {
            int intNumber = ToInt(didgits, fromBase);
            Console.WriteLine(ToBase(intNumber, toBase));
        }
    }
    //convert input number from any numeral system to int
    static int ToInt(int[] didgits, int fromBase)
    {
        int result = 0;
        for (int i = 0; i < didgits.Length; i++)
            result += didgits[i] * (int)(Math.Pow(fromBase, didgits.Length - 1 - i));
        return result;
    }
    //convert int to any numeral system
    static string ToBase(int number, int toBase)
    {
        string result = "";
        for (int remainder = 0; number > 0; number /= toBase)
        {
            remainder = number % toBase;
            result = DidgitMap(remainder) + result;
        }
        return result;
    }
    //map didgits to their hexadecimal representation
    static char DidgitMap(int didgit)
    {
        char[] hexMap = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        return hexMap[didgit];
    }
    //error check
    static bool ErrorCheck(int[] number, int fromBase, int toBase)
    {
        if (fromBase < 2 || toBase < 2)
        {
            Console.WriteLine("The numeral system doesn't exist! Please check if fromBase and toBase are larger than 2");
            return false;
        }
        if (toBase > 16)
        {
            Console.WriteLine("Conversion up to base 16 is supported. Please enter a number <= 16 fot toBase");
            return false;
        }
        for (int i = 0; i < number.Length; i++)
            if (number[i] >= fromBase)
            {
                Console.WriteLine("The input number contains 1 or more didgits that are greater than the base of the numeral system. Please check the didgits of the input number");
                return false;
            }
        return true;
    }
}
