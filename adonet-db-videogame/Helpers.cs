using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
static class Helpers
{
    public static bool isNullEmptyWhiteSpace(string? text)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
        {
            return true;
        }

        return false;
    }
    public static DateTime checkValidDate(string prompt, string message)
    {
        bool isDate = false;
        DateTime output;
        do
        {
            Console.Write(prompt);
            isDate = DateTime.TryParse(Console.ReadLine(), out output);

            if (!isDate)
            {
                Console.WriteLine(message);
            }
        } while (!isDate);

        return output;
    }

    public static string checkValidString(string prompt, string message)
    {
        string output = "";
        do
        {
            Console.Write(prompt);
            output = Console.ReadLine();

            if (isNullEmptyWhiteSpace(output))
            {
                Console.WriteLine(message);
            }
        } while (isNullEmptyWhiteSpace(output));

        return output;
    }

    public static int checkValidInt(string prompt, string message)
    {
        bool isNumber = false;
        int output = 0;

        do
        {
            Console.Write(prompt);
            isNumber = Int32.TryParse(Console.ReadLine(), out output);

            if (!isNumber)
            {
                Console.WriteLine(message);
            }
        } while (!isNumber || output == 0);

        return output;
    }
}
