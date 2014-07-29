using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_lab1_console
{
    class GBFS
    {
        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
       

        public Vertex selectBest(Vertex parent, int level)
        {


            if (IsSorted(parent.genes))
               return parent;
              
            
            int i, j,minPos,aux;
            Vertex child = new Vertex(parent.genes);
            minPos = level;
            for (i = level + 1; i < Vertex.getDefaultLength(); i++)
                if (child.genes[i] < child.genes[minPos])
                    minPos = i;
            
            if (minPos != level)
            {
                aux = child.genes[minPos];
                child.genes[minPos] = child.genes[level];
                child.genes[level] = aux;
            }

            parent.children.Add(child);
            ;
            return selectBest(child, level + 1);
         

       
                   
                    


        }
    }
}
