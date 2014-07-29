using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab3B
{
    class Program
    {
        static void Main(string[] args)
        {
            double quantity, texture ;
            String str = null;
            double num = 0;
            double denom = 0;
            double min;
           
                Console.WriteLine("Input double value for quantity:");
                quantity= Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input double value for texture:");
                texture = Convert.ToDouble(Console.ReadLine());

                min=Math.Min(Controller.quantityDegree(quantity, "mica"), Controller.textureDegree(texture, "foartefina"));
                denom += Controller.cycleDegree(min, "delicat");
                num += Controller.cycleDegree(min, "delicat") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mica"), Controller.textureDegree(texture, "fina"));
                denom += Controller.cycleDegree(min, "usor");
                num += Controller.cycleDegree(min, "usor") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mica"), Controller.textureDegree(texture, "normala"));
                denom += Controller.cycleDegree(min, "usor");
                num += Controller.cycleDegree(min, "usor") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mica"), Controller.textureDegree(texture, "rezistenta"));
                denom += Controller.cycleDegree(min, "usor");
                num += Controller.cycleDegree(min, "usor") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "medie"), Controller.textureDegree(texture, "foartefina"));
                denom += Controller.cycleDegree(min, "usor");
                num += Controller.cycleDegree(min, "usor") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "medie"), Controller.textureDegree(texture, "fina"));
                denom += Controller.cycleDegree(min, "normal");
                num += Controller.cycleDegree(min, "normal") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "medie"), Controller.textureDegree(texture, "normala"));
                denom += Controller.cycleDegree(min, "normal");
                num += Controller.cycleDegree(min, "normal") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "medie"), Controller.textureDegree(texture, "rezistenta"));
                denom += Controller.cycleDegree(min, "normal");
                num += Controller.cycleDegree(min, "normal") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mare"), Controller.textureDegree(texture, "foartefina"));
                denom += Controller.cycleDegree(min, "normal");
                num += Controller.cycleDegree(min, "normal") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mare"), Controller.textureDegree(texture, "fina"));
                denom += Controller.cycleDegree(min, "normal");
                num += Controller.cycleDegree(min, "normal") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mare"), Controller.textureDegree(texture, "normala"));
                denom += Controller.cycleDegree(min, "intens");
                num += Controller.cycleDegree(min, "intens") * min;

                min = Math.Min(Controller.quantityDegree(quantity, "mare"), Controller.textureDegree(texture, "rezistenta"));
                denom += Controller.cycleDegree(min, "intens");
                num += Controller.cycleDegree(min, "intens") * min;


                Console.WriteLine(num / denom);

                Console.ReadKey();

                
            


        }
    }
}
