using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab_2
{
    class Population
    {
        Individual[] individuals;

        public Population(int popSize, bool init, List<Cube> clist)
        {
            individuals = new Individual[popSize];
            if (init)
            {
                for (int i = 0; i < size(); i++)
                {
                    Individual newIndiv = new Individual();
                    newIndiv.generateIndividual(clist);
                    saveIndividual(i, newIndiv);
                }
            }
        }

        public Individual getIndividual(int index)
        {
            return individuals[index];

        }

        public Individual getFittest()
        {
            Individual fittest = individuals[0];
            for(int i=0;i<size();i++){
                if(fittest.getFitness() <= this.getIndividual(i).getFitness()){
                    fittest=getIndividual(i);
                }
            }
            return fittest;
        }

        public int size()
        {
            return individuals.Length;
        }

        public void saveIndividual(int index, Individual indiv)
        {
            individuals[index] = indiv;
        }
    }
}
