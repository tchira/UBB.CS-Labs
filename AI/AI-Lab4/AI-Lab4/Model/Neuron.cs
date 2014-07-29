using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab4.Model
{
    class Neuron
    {
        public int noInputs { get;set; }
        public double[] weights { get; set; }
        public double output{get;set;}
        public double err{get;set;}

        public const double MIN = -0.5;
        public const double MAX = 0.5;
        private Random rand;

        public Neuron(int n){
            //Neuron initialiser, n= number of inputs
            rand=new Random();
            noInputs = n;
            weights = new double[noInputs];
            for (int i = 0; i < n; i++)
                weights[i] = MIN + rand.NextDouble() * (MAX - MIN);
            output = 0.0;
            err = 0.0;
                
        }

        public void fire( double[] info){
            //get output for data
            double net=0.0;
            for(int i=0;i<noInputs;i++){
                net+=info[i]*weights[i];
            }

            this.output=1/(1.0+Math.Exp(-1*net));
        }

        public void setErr(double val)
        {
            //sets error for sigmoidal activation
            this.err = output * (1 - output) * val;
        }
    


    }

    
}
