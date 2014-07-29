using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_lab1_console
{
    class Vertex
    {
        public int[] genes;
        public List<Vertex> children;
        private static int DEFAULT_LENGTH = 5;

        public static int getDefaultLength()
        {
            return DEFAULT_LENGTH;
        }

        public static void setDefaultLength(int newLength)
        {
            DEFAULT_LENGTH = newLength;
        }

        public Vertex()
        {
            genes = new int[DEFAULT_LENGTH];
            for (int i = 0; i < DEFAULT_LENGTH; i++)
                genes[i] = 0;        
            children = new List<Vertex>();
        }

        public Vertex(int[] state)
        {
            genes = new int[DEFAULT_LENGTH];
            for (int i = 0; i < state.Length; i++)
                genes[i] = state[i];
            children = new List<Vertex>();
        }

        public override string ToString()
        {
            String output = "";
            foreach (int i in this.genes)
                output += i.ToString() + " ";
            return output;
        }

    }
}
