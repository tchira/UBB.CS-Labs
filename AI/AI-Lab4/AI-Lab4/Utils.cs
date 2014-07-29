using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI_Lab4
{
    public class Utils
    {
        public List<List<double>> inData { get; set; }
        public List<List<double>> outData { get; set; }
        public List<List<double>> inTestData { get; set; }
        public List<List<double>> outTestData { get; set; }

        public Utils()
        {
            inData = new List<List<double>>();
            outData = new List<List<double>>();
            inTestData = new List<List<double>>();
            outTestData = new List<List<double>>();

        }
        
        public void readData(String filename)
        {
            String inLine;
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    sr.ReadLine();

                    while ((inLine = sr.ReadLine()) != null)
                    //for (int j = 0; j < 20;j++ )
                    {
                        
                      
                        String[] tokens = inLine.Split(',');
                        List<double> inList = new List<double>();
                        List<double> outList = new List<double>();
                        outList.Add(Convert.ToDouble(tokens[4]));
                        outList.Add(Convert.ToDouble(tokens[5]));
                       

                        for (int i = 6; i < tokens.Length; i++)
                        {
                            inList.Add(Convert.ToDouble(tokens[i]));
                        }

                        inData.Add(inList);
                        outData.Add(outList);

                    }
                    Console.WriteLine("Read all data\n");

                }


            }

            catch (Exception e)
            {
                Console.WriteLine("Cannot read file");
                Console.WriteLine(e.Message);
            }
        }

        public List<List<double>> getOutTestData()
        {   
            outTestData.Clear();
            for (int i = 0; i < 100; i++)
                outTestData.Add(outData[i]);
            return outTestData;

        }

        public List<List<double>> getInTestData()
        {
            inTestData.Clear();
            for (int i = 0; i < 100; i++)
                inTestData.Add(inData[i]);
            return inTestData;

        }

        public List<List<double>> normaliseData(List<List<double>> data)
        {
            for (int j = 0; j < 16; j++)
            {
                double sum = 0.0;
                double mean, squareSum, deviation;
                for (int i = 0; i < data.Count; i++)
                {
                    sum += data[i][j];
                }
                mean = sum / ((double)data.Count);
                squareSum = 0.0;
                for (int i = 0; i < data.Count; i++)
                {
                    squareSum += (data[i][j] - mean) * (data[i][j] - mean);
                }
                deviation = Math.Sqrt(squareSum / ((double)data.Count));
                for (int i = 0; i < data.Count; i++)
                {
                    data[i][j] = (data[i][j] - mean) / deviation;
                }

                

            }
            return data;
        }
    }
}
