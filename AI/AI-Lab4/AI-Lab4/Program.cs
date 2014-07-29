using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_Lab4.Model;

namespace AI_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Network.EPOCH_LIMIT = 10;
            Network.EPSILON = 1.0E-8;
            Network.LEARN_RATE = 0.5;
            Network neuralNet = new Network(18, 2, 4, 4);
            
            Utils data=new Utils();
            data.readData("parkinsonData.txt");
            data.inData = data.normaliseData(data.inData);
            
            neuralNet.learning(data.inData, data.outData);
            neuralNet.testing(data.inTestData, data.outTestData);
            
            
            
           
            Console.ReadKey();
            
        }
    }
}
