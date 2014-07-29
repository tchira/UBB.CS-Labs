using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace iquest3
{
    class Program
    {
        static void Main(string[] args)
        {
        String input=Console.ReadLine();
        String[] faces = input.Split(' ');
        Char[, ,] cube = new Char[3, 3, 3];
        int level = 0, column = 0, line = 2;
            foreach (string s in faces)
            {
                foreach (char c in s)
                {   int value = (int)char.GetNumericValue(c);
                    string binary = Convert.ToString(value, 2);
                    
                    while (binary.Length != 3)
                        binary = "0" + binary;
                    
                    foreach (char bin in binary)
                    {
                        cube[level,line,column] = bin;
                        column++;
                        if (column == 3)
                            column = 0;
                    }
                    line--;
                    if (line == -1)
                        line = 2;
                  }
                level++;
            }

       
          


                        //top view
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                                if ((cube[0, i, j] == '1') || (cube[1, i, j] == '1') || (cube[2, i, j] == '1'))
                                {
                                    Console.Write('X');
                                }
                                else Console.Write('O');
                            Console.WriteLine();
                        }
            Console.WriteLine();

            //front view
            for (int i = 2; i >=0; i--)
            {
                for (int j = 0; j < 3; j++)
                    if ((cube[i, 0, j] == '1') || (cube[i, 1, j] == '1') || (cube[i, 2, j] == '1'))
                    {
                        Console.Write('X');
                    }
                    else Console.Write('O');
                Console.WriteLine();
            }
            Console.WriteLine();


            //side view
            for (int i = 2; i>=0; i--)
            {
                for (int j = 0; j <3; j++)
                    if ((cube[i, j, 0] == '1') || (cube[i, j, 1] == '1') || (cube[i, j, 2] == '1'))
                    {
                        Console.Write('X');
                    }
                    else Console.Write('O');
                Console.WriteLine();
            }


          
            
            


           



                
        }

        
    }
}
