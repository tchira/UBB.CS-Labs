using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {      List<Cube> cubelist=new List<Cube>();
        int cubeNumber, popSize, generationCount,tsize;
        double uniformRate, mutationRate;
            Console.WriteLine("Population size:");
            popSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Generation count:");
            generationCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Uniform rate(default 0.5):");
            uniformRate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Mutation rate(default 0.025):");
            mutationRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Tournament size (default 3):");
            tsize = Convert.ToInt32(Console.ReadLine());

            Algorithm.setMutationRate(mutationRate);
            Algorithm.setUniformRate(uniformRate);
            Algorithm.setTournamentSize(tsize);
            
            cubelist.Add(new Cube(4, 4));
            cubelist.Add(new Cube(3, 2));
            cubelist.Add(new Cube(2, 1));
            cubelist.Add(new Cube(2, 2));
            cubelist.Add(new Cube(1, 1)); 
            cubelist.Add(new Cube(7, 1));
            cubelist.Add(new Cube(10, 1));
            cubelist.Add(new Cube(10, 2));
            cubelist.Add(new Cube(9, 3));
            cubelist.Add(new Cube(8, 2));
            cubelist.Add(new Cube(11, 5));
            cubelist.Add(new Cube(12, 2));
            Individual.setDefaultLength(cubelist.Count);
          

            Population pop = new Population(popSize, true, cubelist);
            for (int i = 0; i < generationCount; i++)
            {
                pop = Algorithm.evolvePopulation(pop);
                Console.WriteLine(pop.getFittest());

            }

            Console.WriteLine(pop.getFittest());
            Console.ReadKey();
            


        }
    }
}
