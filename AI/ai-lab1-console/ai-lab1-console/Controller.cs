using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_lab1_console
{
    class Controller
    {
        private Vertex root;
        private int aux;

        private Random randGen;

        public Controller()
        {
            root = new Vertex();
            randGen = new Random();
        }

        public void generateRandomList()
        {
            root = new Vertex();
            for (int i = 0; i < Vertex.getDefaultLength(); i++)
            {
                this.root.genes[i] = randGen.Next(1, 1000);
                
            }

        }

        public void setRoot(Vertex newRoot)
        {
            root = newRoot;
        }

        public Vertex getRoot()
        {
            return root;
        }

        public Vertex getDFSSolution(){
            DFS dfs = new DFS();
            Vertex zeroVertex = new Vertex();
            dfs.generateTree(root, zeroVertex, 0);
            return dfs.getSolution(zeroVertex);
           

        }

        public Vertex getGBFSSolution()
        {
            GBFS gbfs = new GBFS();
            return gbfs.selectBest(getRoot(), 0);
        }


      


    }
}
