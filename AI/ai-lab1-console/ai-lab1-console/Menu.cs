using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ai_lab1_console
{
    class Menu
    {
        private Controller cont;
        private Stopwatch sw, sw2;

        public Menu(Controller c)
        {
            cont = c;
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
        }

        public void showSolutions()
        {
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Console.WriteLine("Initial state:");
            Console.WriteLine(cont.getRoot() + "\n\n");
            

            Console.WriteLine("GBFS Solution:");
            sw2.Start();
            Console.WriteLine(cont.getGBFSSolution());
            sw2.Stop();
            Console.WriteLine("Elapsed:" + sw2.Elapsed);

            Console.WriteLine("DFS Solution:");
            sw.Start();
            Console.WriteLine(cont.getDFSSolution());
            sw.Stop();
            Console.WriteLine("Elapsed:" + sw.Elapsed + "\n\n");
        }

        public void runConsole(){
            int option=-1;
           
            while(option!=0){
                Console.WriteLine("_________________________________________");
                Console.WriteLine("[1] Find solution for randomly generated list:");
                Console.WriteLine("[2] Input list to find solutions for:");
                Console.WriteLine("[0] Exit program:");
                option=Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("Input length of generated list:");
                    int newLength = Convert.ToInt32(Console.ReadLine());
                    Vertex.setDefaultLength(newLength);
                    cont.generateRandomList();
                    showSolutions();
                    
                
                   
                }

                else if (option==2){
                    int length;
                    
                    Console.WriteLine("Length of list:");
                    length=Convert.ToInt32(Console.ReadLine());
                    int[] array = new int[length];
                    Vertex.setDefaultLength(length);
                    Console.WriteLine(Vertex.getDefaultLength()+" Input list elements:");
                    for(int j=0;j<length;j++)
                        array[j]=Convert.ToInt32(Console.ReadLine());
                    cont.setRoot(new Vertex(array));
                    showSolutions();


                }

                else
                    Console.WriteLine("Wrong option");

            

                




            }
                

            }
            
            }
        }

    

