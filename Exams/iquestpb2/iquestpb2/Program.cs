using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace iquestpb2
{
    class Program
    {
        static void Main(string[] args)
        {   char[] vowels={'a','e','i','o','u','A','E','I','O','U'};
            string input = Console.ReadLine();
            StringBuilder shifted = new StringBuilder();
            StringBuilder cons = new StringBuilder();
            StringBuilder result = new StringBuilder();
            int shift = (int)Char.GetNumericValue(input[0]);
             for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    if (vowels.Contains(input[i]))
                    {

                        if (char.IsLower(input[i])) result.Append(char.ToUpper(input[i]));
                        else result.Append(char.ToLower(input[i]));
                    }
                    else
                    {
                        result.Append("-");
                        cons.Append(input[i]);
                    }
               }
            }

             int index, k = 0;
             for (int i = 0; i < cons.Length; i++)
             {
                 index = (i + shift) % cons.Length;
                 shifted.Append(cons[index]);
             }



             for (int i = 0; i < result.Length; i++)
                 if (result[i] == '-')
                     result[i] = shifted[k++];

             
             Console.WriteLine(result);
         
     }
   }
}
