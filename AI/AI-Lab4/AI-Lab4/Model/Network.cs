using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI_Lab4.Model
{
    class Network
    {
        public int noInputs { get; set; }
        public int noOutputs { get; set; }
        public int noHiddenLayers { get; set; }
        public int noNeuronsPerHidden { get; set; }
        public List<Layer> layers { get; set; } //size = noHiddenLayers+2
        public static double LEARN_RATE {get; set;}
        public static double EPSILON { get; set; }
        public static double EPOCH_LIMIT { get; set; }

        public Network(int m, int r, int p, int h)
        {
            noInputs = m;
            noOutputs = r;
            noHiddenLayers = p;
            noNeuronsPerHidden = h;
            layers = new List<Layer>();
            layers.Add(new Layer(noInputs, 0));
            //layers[1] = new Layer(noNeuronsPerHidden, noInputs);
            layers.Add(new Layer(noNeuronsPerHidden, noInputs));
            for (int i = 1; i < noHiddenLayers; i++)
            {
                //layers[i + 1] = new Layer(noNeuronsPerHidden, noNeuronsPerHidden);
                layers.Add(new Layer(noNeuronsPerHidden, noNeuronsPerHidden));
            }
            //layers[noHiddenLayers + 1] = new Layer(noOutputs, noNeuronsPerHidden);
            layers.Add(new Layer(noOutputs, noNeuronsPerHidden));

        }

        public void activate(List<double> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                this.layers[0].neurons[i].output = inputs[i];
            }

            for (int l = 1; l < noHiddenLayers + 1; l++)
            {
                foreach (Neuron n in layers[l].neurons)
                {
                    double[] info = new double[n.noInputs];
                    for (int i = 0; i < n.noInputs; i++)
                    {
                        info[i] = layers[l - 1].neurons[i].output;
                        
                    }
                    n.fire(info);
                }
            }
        }

        public void errorsBackPropagate(List<double> err)
        {
            int i;
            double sumErr = 0.0;
            for (int l = noHiddenLayers + 1; l >= 1; l--)
            {
                i = 0;
                foreach (Neuron n1 in layers[l].neurons)
                {
                    if (l == noHiddenLayers + 1)
                    {
                        n1.setErr(err[i]);
                    }
                    else
                    {
                        sumErr = 0.0;
                        foreach (Neuron n2 in layers[l + 1].neurons)
                        {
                            sumErr += n2.weights[i] * n2.err;
                        }
                        n1.setErr(sumErr);
                        
                    }
                    for (int j = 0; j < n1.noInputs; j++)
                    {
                        double netWeight = n1.weights[j] + LEARN_RATE * n1.err * layers[l - 1].neurons[j].output;
                        n1.weights[j] = netWeight;
                    }
                    i++;
                }
            }
        }

        double errorComputationRegression(List<double> target,List<double> err)
        {
            double globalErr = 0.0;
            for (int i = 0; i < layers[noHiddenLayers + 1].noNeurons; i++)
            {
                err[i] = target[i] - layers[noHiddenLayers + 1].neurons[i].output;
                globalErr += err[i] * err[i];
            }
            return globalErr;
        }

        public bool checkGlobalErr(List<double> err)
        {
            double error = 0.0;
            for (int i = 0; i < err.Count; i++)
                error += err[i];
            Console.WriteLine(error);
            if (Math.Abs(error - 0.1) < EPSILON)
                return true;
            return false;
        }


        public void learning(List<List<double>> inData, List<List<double>> outData)
        {
            bool stopCond = false;
            int epoch = 0;
            List<double> globalErr;
            while ((!stopCond)) //|| (epoch < EPOCH_LIMIT))
            {
                Console.ReadKey();
                globalErr = new List<double>();
                for (int d = 0; d < inData.Count; d++)
                {
                    activate(inData[d]);
                    List<double> err = new List<double>();
                    globalErr[d] = errorComputationRegression(outData[d],err);

                    Console.WriteLine(globalErr[d]);
                    errorsBackPropagate(err);
                }
                stopCond = checkGlobalErr(globalErr);
                
                epoch++;
                Console.WriteLine("Epoch " + epoch + " completed\n");
            }
        }

        public void testing(List<List<double>> inData, List<List<double>> outData)
        {
            List<double> globalErr = new List<double>();
            for (int d = 0; d < inData.Count; d++)
            {
                activate(inData[d]);
                List<double> err = new List<double>();
                globalErr[d] = errorComputationRegression(outData[d],err);
            }
        }
        

   






    }
}
