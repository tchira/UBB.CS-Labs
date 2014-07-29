using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab_2
{
    class FitnessCalc
    {
        public static int getFitness(Individual ind)
        {
            int fitness = 0;
            for (int i = 0; i < ind.size() - 1; i++)
            {
                for (int j = i + 1; j < ind.size(); j++)
                {
                    if (ind.getGene(i).size >= ind.getGene(j).size)
                        fitness += 2;
                }
                if (ind.getGene(i).color != ind.getGene(i + 1).color)
                    fitness += 1;
            }

            return fitness;
               
        }


        public static int getMaxFitness()
        {
            int maxFitness = 0;
            for (int i = 1; i < Individual.getDefaultLength(); i++)
                maxFitness += (int)Math.Pow(2, i);
            maxFitness += Individual.getDefaultLength() - 1;
            return maxFitness;
        }
    }
}
