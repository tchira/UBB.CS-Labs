using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab_2
{
    class Individual
    {
        private static int defaultLength = 12;
        private Cube[] genes = new Cube[defaultLength];
        private int fitness = 0;


        public Individual()
        {
            for (int i = 0; i < defaultLength; i++)
                this.genes[i] = null;
        }

        public static int getDefaultLength()
        {
            return defaultLength;
        }

        public static List<Cube> Shuffle(List<Cube> clist)
        {
            Random rng = new Random();
            Cube aux;
            int n = clist.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                aux = clist[k];
                clist[k] = clist[n];
                clist[n] = aux;
                
            }
            return clist;
        }

        public void generateIndividual(List<Cube> clist)
        {
            for (int i = 0; i < clist.Count; i++)
                genes[i] = clist[i];
            clist=Individual.Shuffle(clist);
        }

        public static void setDefaultLength(int length)
        {
          defaultLength = length;

        }

        public Cube getGene(int index)
        {
            return genes[index];
        }

        public void setGene(int index, Cube value)
        {
            genes[index] = value;
            fitness = 0;
        }

        public int size()
        {
            return genes.Length;
        }

        public int getFitness()
        {
            if (fitness == 0)
            {
                fitness = FitnessCalc.getFitness(this);
            }
            return fitness;

        }

        public override string ToString()
        {
            string geneString = "";
            for (int i = 0; i < size(); i++)
            {
                geneString += getGene(i);
                
            }
            return geneString;
        }

         public bool containsGene(Cube c){
             return genes.Contains(c);
                
        }
       


    }
}
