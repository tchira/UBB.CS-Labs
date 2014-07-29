using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.Domain;
using Csharp_lab2.Repository;
using Csharp_lab2.Utils;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Csharp_lab2.controller
{
        public class Controller:IObservable<Controller>  {
        public RepositoryHashmap<Student> repo;
        private List<IObserver<Controller>> observers;

       
      
        public Controller(RepositoryHashmap<Student> rep)
        {
            //Controller constructor
            this.repo = rep;
            this.readFromFile();
            observers = new List<IObserver<Controller>>();
        }

        protected void Notify(Controller obj)
        {
            foreach (IObserver<Controller> observer in observers)
            {
                observer.OnNext(obj);
            }
        }

         public IDisposable Subscribe(IObserver<Controller> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }

        return new Unsubscriber(observers, observer);   
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<Controller>> observers;
        private IObserver<Controller> observer;

        public Unsubscriber(List<IObserver<Controller>> observers, IObserver<Controller> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }






        public bool isEmpty()
        {
            //Pre: -
            //Post: true if stack contains no elements, false otherwise
            return this.repo.isEmpty();
        }
        public void addStudent(Student s)
        {
            //Precondition : s= student object
            //Postcondition: Element on top of the stack is the input student object
            repo.addObject(s);
            this.serialize();
            this.deserialize();
            this.printToFile();
            Notify(this);
        }

        public void removeStudent(int id)
        {
            //Precondition: int id : id of existing student in repository
            //Postcondition: Student object having input id removed from repository/ data file
            repo.removeObjectById(id);
            this.printToFile();
        }


        public int getSize()
        {
            //Pre: = 
            //Returns number of elements in the stack
            return repo.getSize();
        }

        public static void copyElements(Utils.Stack<Student> src, Utils.Stack<Student> dest)
        {
            Utils.Stack<Student> aux = new Utils.Stack<Student>();
            while (!src.isEmpty())
            {
                try
                {
                    aux.push(src.pop());
                }
                catch (MyException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!aux.isEmpty())
            {
                try
                {
                    dest.push(aux.pop());
                }
                catch (MyException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void copyHashElements<T>(IDictionary<int, T> src, IDictionary<int, T> dest) where T:Identifiable
        {
            foreach(T element in src.Values)
                dest.Add(element.getId(),element);
        }

      	public void delete10(){
		Student del=(Student)this.repo.getLastObject();
		while(del.getAverage()!=10 && del!=null ){
			this.repo.removeObject(del);
			del=(Student)this.repo.getLastObject();
		}
        Notify(this);
	    }
        public List<Student> getAll()
        {
            return this.repo.toList();
        }

        public int countElementsGreaterThan(int id)
        {
            Student s = (Student)this.repo.getByKey(id);
            if (s == null)
                return -1;
            return this.repo.countElementsGreaterThan(s);
        }
        

        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("strepo.out", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, repo);
            stream.Close();
        }

        public void deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("strepo.out", FileMode.Open, FileAccess.Read);
            repo = (RepositoryHashmap<Student>)formatter.Deserialize(stream);
            stream.Close();
        }

        public void printToFile()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("studentlist.txt");
            List<Student> li=this.repo.toList();
            foreach (Student s in li)
            {
                file.WriteLine(s);
            }

            file.Close();
        }

        public void readFromFile()
        {
            String line;
            String[] tokens;
            int length;
            System.IO.StreamReader infile = new System.IO.StreamReader("studentlist.txt");
            while ((line = infile.ReadLine()) != null)
            {
                tokens = line.Split(' ');
                length = tokens.Length;
                switch (length)
                {
                    case 3:
                        Student s1 = new Student(Convert.ToInt32(tokens[0]), tokens[1], Convert.ToInt32(tokens[2]));
                        repo.addObject(s1);
                        break;
                    case 4:
                        UndergraduateStudent s2 = new UndergraduateStudent(Convert.ToInt32(tokens[0]), tokens[1], Convert.ToInt32(tokens[2]), Convert.ToInt32(tokens[3]));
                        repo.addObject(s2);
                        break;
                    case 6:
                        GraduateStudent s3 = new GraduateStudent(Convert.ToInt32(tokens[0]), tokens[1], tokens[2], Convert.ToInt32(tokens[3]), Convert.ToInt32(tokens[4]),Convert.ToInt32(tokens[5]));
                        repo.addObject(s3);
                        break;
                    case 7:
                        PhdStudent s4 = new PhdStudent(Convert.ToInt32(tokens[0]), tokens[1], tokens[2], tokens[3], Convert.ToInt32(tokens[4]), Convert.ToInt32(tokens[5]), Convert.ToInt32(tokens[6]));
                        repo.addObject(s4);
                        break;
                }
            }
            infile.Close();


        }

    

           

        }
    }	







