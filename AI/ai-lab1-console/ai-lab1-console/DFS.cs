using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_lab1_console
{
    class DFS
    {
        

        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if ((arr[i - 1] > arr[i])||(arr[i-1]==0))
                {
                    return false;
                }
            }
            return true;
        }

        public void generateTree(Vertex root, Vertex parent, int level)
        {
            if (level == Vertex.getDefaultLength())
                return;

            for (int i = 0; i < Vertex.getDefaultLength(); i++)
                if (parent.genes[i] == 0)
                {
                    Vertex child = new Vertex(parent.genes);
                    child.genes[i] = root.genes[level];
                    parent.children.Add(child);
                    generateTree(root, child, level + 1);
                }
        }

        public Vertex getSolution(Vertex zeroVertex)
        {
            Stack<Vertex> stack = new Stack<Vertex>();
            stack.Push(zeroVertex);
            while (stack.Count != 0)
            {
                Vertex currentNode = stack.Pop();
                if (IsSorted(currentNode.genes))
                {

                    return currentNode;
                }

                foreach(Vertex child in currentNode.children)
                {
                    stack.Push(child);
                }

            }
            return null;
        }
    }
}
