using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab4.Model
{
    class Layer
    {
        public int noNeurons { get; set; }
        public List<Neuron> neurons { get; set; }

        public Layer(int noNeur, int noIn){
            noNeurons=noNeur;
            int inputs = noIn;
            neurons=new List<Neuron>();
            for(int i=0;i<noNeurons;i++){
                neurons.Add(new Neuron(inputs));
            }
        }
    }
}
