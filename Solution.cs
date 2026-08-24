
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

public class Solution
{
    static public string RemoveKdigits(string num, int k)
    {
        if ((num.Length-num.Count(c => c == '0')) == k)
        {
            return "0";
        }
        int f = 1, s = 0, sameNum = f, startLength = num.Length;
        for (int i = 0; i < k && s < num.Length && f < num.Length; i++)
        {
            if (s == 0 && f == 1 && num[f] == '0' && num[s] == '1')
            {
                num = num.Remove(s, 1);
            }
            else if (num[s] >= num[f])
            {
                s++;
                f++;
                sameNum++;
                i--;
            }
            else
            {
                num = num.Remove(f, 1);
            }
        }
        while (num.Length != 0 && num[0] == '0')
        {
            num = num.Remove(0, 1);
        }
        if (sameNum == startLength)
        {
            num = num.Remove(0,1);
        }
        if (string.IsNullOrEmpty(num))
        {
            num = "0";
        }
        return num;
    }

    static public void Main()
    {
        Log("test:");
        Log($"Answer: {RemoveKdigits("1432219", 3)}");
        Log($"Answer: {RemoveKdigits("10200", 1)}");
        Log($"Answer: {RemoveKdigits("10", 1)}");
        Log($"Answer: {RemoveKdigits("1111", 1)}");
        Log($"Answer: {RemoveKdigits("33526221184202197273", 1)}");
    } //                              33526221184202197273
    static public void Log(dynamic var)
    {
        Console.WriteLine(var);
    }

}
