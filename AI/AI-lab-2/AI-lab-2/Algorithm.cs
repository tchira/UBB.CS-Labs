using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab_2
{
    class Algorithm
    {   private static Random rng=new Random();
        private static double uniformRate = 0.5;
        private static double mutationRate = 0.025;
        private static int tournamentSize = 3;
        private static bool elitism = true;

        public static void setUniformRate(double newRate)
        {
            uniformRate = newRate;
        }

        public static void setMutationRate(double newRate)
        {
            mutationRate = newRate;
        }

        public static void setTournamentSize(int newSize){
            tournamentSize = newSize;
        }

        public static Population evolvePopulation(Population pop)
        {
            Population newPop = new Population(pop.size(), false, null);

            if (elitism)
            {
                newPop.saveIndividual(0, pop.getFittest());
            }

            int elitismOffset;
            if (elitism)
            {
                elitismOffset = 1;
            }
            else
            {
                elitismOffset = 0;
            }

            for (int i = elitismOffset; i < pop.size(); i++)
            {
                Individual ind1 = tournamentSelection(pop);
                Individual ind2 = tournamentSelection(pop);
                Individual newInd = crossover(ind1, ind2);
                newPop.saveIndividual(i, newInd);
            }

            return newPop;


        }

        private static Individual crossover(Individual ind1, Individual ind2)
        {
            Individual offspring = new Individual();
            int j = 0;
            for (int i = 0; i < ind1.size(); i++)
            {
                if (rng.NextDouble() <= uniformRate)
                {
                    offspring.setGene(i, ind1.getGene(i));
                }
            }

            for (j = 0; j < ind2.size(); j++)
            {
                if (!offspring.containsGene(ind2.getGene(j)))
                {
                    for (int jj = 0; jj < offspring.size(); jj++)
                    {
                        if (offspring.getGene(jj) == null)
                        {
                            offspring.setGene(jj, ind2.getGene(j));
                            break;
                        }
                    }
                }
            }

            return offspring;

        }
        

        private static void mutate(Individual ind){
            for(int i=0;i<ind.size();i++){
                if(rng.NextDouble()<=mutationRate){
                    int j=(int)(ind.size()*rng.NextDouble());

                    Cube c1=ind.getGene(i);
                    Cube c2=ind.getGene(2);

                    ind.setGene(i,c2);
                    ind.setGene(j,c1);
                }
            }
            

        }

        private static Individual tournamentSelection(Population pop){
            Population tournament=new Population(tournamentSize,false,null);

                for(int i=0;i<tournamentSize;i++){
                    int rand=(int)(rng.NextDouble()*pop.size());
                    tournament.saveIndividual(i,pop.getIndividual(rand));

                }
            Individual fittest=tournament.getFittest();
            return fittest;
        }


       
    
    
    
    }


}
