using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab3
{
    class Controller
    {
        private List<Fact> facts;

        public Controller()
        {
           
            facts = new List<Fact>();
            this.InitialiseFactList();
        }
        
        private void InitialiseFactList(){
            for(int i=0;i<20;i++){
                Fact newFact=new Fact();
                this.facts.Add(newFact);
           }
            facts[0].desc="Urmeaza sarbatori";
            facts[1].desc="Se spala perdele";
            facts[2].desc="Se spala draperii";
            facts[3].desc="Se spala perdele pe rand";
            facts[4].desc="Ciclu delicat";
            facts[5].desc="Se spala draperii pe rand";
            facts[6].desc="Ciclu usor";
            facts[7].desc="Familia are mai mult de 5 membri";
            facts[8].desc="Se spala 5 kg de haine";
            facts[9].desc="Camasile se spala fara stoarcere";
            facts[10].desc="Georgica e mecanic";
            facts[11].desc="Georgica poarta salopeta";
            facts[12].desc="Se spala salopete";
            facts[13].desc="Ciclu intens";
            facts[14].desc="Ciclu normal";
            facts[15].desc="Se spala lenjerie";
            facts[16].desc="Lenjeria < 2 kg";
            facts[17].desc="Lenjeria > 2 kg";
            facts[18].desc = "Toate salopetele trebuie spalate";
            facts[19].desc = "Toate salopetele sunt spalate";
        }

        public void initValues(){
            for (int i = 0; i < 20; i++)
                facts[i].val = false;

            facts[7].val = true;
            facts[10].val=true;
        }

          

        private void printFacts(List<Fact> pFacts)
        {
            foreach(Fact f in pFacts){
                if(f.val)
                    Console.WriteLine(f.desc);
            }
            Console.WriteLine("___________________________________\n");
        }

        public List<Fact> forwardInference(List<Fact> xfacts)
        {
            List<Fact> rfacts = new List<Fact>(xfacts);
            
            if (xfacts[0].val)
            {
                rfacts[1].val = true;
                rfacts[2].val = true;
            }

            if (xfacts[1].val)
            {
                rfacts[3].val = true;
                rfacts[4].val = true;

            }

            if (xfacts[2].val)
            {
                rfacts[5].val = true;
                rfacts[6].val = true;
            }

            if (xfacts[7].val)
                rfacts[8].val = true;

            if (xfacts[11].val)
                rfacts[12].val = true;

            if (xfacts[12].val)
                rfacts[13].val = true;

            if (xfacts[15].val && xfacts[16].val)
                rfacts[14].val = true;

            if (xfacts[10].val)
                rfacts[11].val = true;

         

            if (xfacts[15].val && xfacts[17].val)
                rfacts[13].val = true;

            return rfacts;


        }

        public void initReverseValues()
        {
            for (int i = 0; i < 20; i++)
                facts[i].val = false;

            facts[13].val = true;
            facts[18].val = true;
            facts[8].val = true;

        }

        public List<Fact> reverseInference(List<Fact> xfacts)
        {
            List<Fact> rfacts = new List<Fact>(xfacts);
            
            if (xfacts[12].val == true && xfacts[18].val == true)
            {
                rfacts[17].val = false;
            }

            if (xfacts[13].val == true)
            {
                rfacts[17].val = true;
                rfacts[12].val = true;
            }

           
            if (xfacts[18].val && xfacts[8].val)
            {
                rfacts[19].val = true;
            }

            return rfacts;
        }


        public Fact findReverse()
        {
            while (!facts[19].val)
            {
                printFacts(facts);
                facts = reverseInference(facts);
            }

            printFacts(facts);

            return facts[19];
        }
        
        
        public Fact findCycle()
        {
            
            while (!facts[4].val && !facts[6].val && !facts[13].val && !facts[14].val)
            {
                printFacts(facts);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                facts = forwardInference(facts);
            }

            printFacts(facts);

            if (facts[4].val)
                return facts[4];
            if (facts[6].val)
                return facts[6];
            if (facts[13].val)
                return facts[13];
            if (facts[14].val)
                return facts[14];

            return null;


        }
    }
}
