using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab3B
{
    public static class Controller
    {
       private static double minim(double a, double b, double c)
        {
            if (a < b && a < c)
                return a;
            else
                if (b < a && b < c)
                    return b;
                else return c;
        }

        public static double quantityDegree(double val, String bracket)
        {
            //val = double value between 0 and 5
            //bracket = string ( mica/medie/mare)

            switch (bracket)
            {
                case "mica":
                    if (val <= 1)
                        return 1;
                    else if (val <= 2)
                        return 2 - val;
                    else return 0;

                case "medie":
                    return Math.Max(0, minim(((val - 1) / (2.5 - 1)), 1, (4 - val) / (4 - 2.5)));

                case "mare":
                    if (val < 3)
                        return 0;
                    else if (val < 4)
                        return val - 3;
                    else return 1;

                default:
                    return 0;
            }
        }


        public static double textureDegree(double val, String bracket)
        {
            switch (bracket)
            {
                case "foartefina":
                    if (val <= 0.2)
                        return 1;
                    else if (val <= 0.4)
                        return Math.Max(0, minim(((val - 0.2) / (0.4 - 0.2)), 1, ((0.4 - val) / (0.4 - 0.2))));
                    else return 0;

                case "fina":
                    return Math.Max(0, minim(((val - 0.2) / (0.4 - 0.2)), 1, ((0.8 - val) / (0.8 - 0.4))));
                case "normala":
                    return Math.Max(0, minim(((val - 0.3) / (0.7 - 0.3)), 1, ((0.9 - val) / (0.9 - 0.7))));

                case "rezistenta":
                    if (val < 0.7)
                        return 0;
                    else if (val <= 0.9)
                        return Math.Max(0, Math.Min((val - 0.7) / (0.9 - 0.7), 1));
                    else return 1;

                default:
                    return 0;

            }
        }

        public static double cycleDegree(double val, string bracket)
        {
            switch (bracket)
            {
                case "delicat":
                    if (val <= 0.2)
                        return 1;
                    else if (val < 0.4)
                        return Math.Max(0, Math.Min((val - 0.2) / (0.4 - 0.2), 1));
                    else
                        return 0;

                

                case "usor":
                    return Math.Max(0, minim(((val - 0.2) / (0.5 - 0.2)), 1, ((0.8 - val) / (0.8 - 0.5))));


                case "normal":
                   
                    return Math.Max(0, minim(((val - 0.2) / (0.5 - 0.2)), 1, ((0.8 - val) / (0.8 - 0.5))));
                case "intens":

                    if (val >= 0.9)
                        return 1;
                    else if (val > 0.7)
                        return Math.Max(0, Math.Min((val - 0.7) / (0.9 - 0.7), 1));
                    else
                        return 0;

                default:
                    return 0;

            }
        }


    }
}
