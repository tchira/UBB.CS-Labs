using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.Domain;


namespace Csharp_lab2.Repository
{       [Serializable]
        public class RepositoryHashmap<T> where T:Identifiable{
		//Class implementing the repository using basic stack operations
		private IDictionary<int,T> maprepo;
		
		public RepositoryHashmap(){
			//Stack repository constructor
			//Preconditions:
			//Postcond: A new empty repository stack object is build
			maprepo=new Dictionary<int,T>();
		}
		
		public void addObject(T element){
			//Precondition : s= student object
			//Postcondition: Element on top of the stack is the input student object
			//this.maprepo.put(element.getId(),element);
            this.maprepo.Add(element.getId(), element);

		}
		
		public T getLastObject(){
			foreach(T el in this.maprepo.Values)
				return el;
			return default(T);
		}
		
        public void removeObject(T obj){
            this.maprepo.Remove(obj.getId());
		}

        public void removeObjectById(int id)
        {
            this.maprepo.Remove(id);
        }
		
		public bool isEmpty(){
			//Pre: -
			//post: true if stack contains no elements, false otherwise
            if (maprepo.Count == 0)
                return true;
            return false;
		}

  
		public int getSize(){
			//Pre: = 
			//Returns number of elements in the stack
            return this.maprepo.Count;
		}

        public List<T> toList()
        {
            return this.maprepo.Values.ToList();
        }

        public T getByKey(int key)
        {
            T obj;
            if (this.maprepo.ContainsKey(key))
            {
                this.maprepo.TryGetValue(key,out obj);
                return obj;
            }

            return default(T);
        }
		
	
		public int countElementsGreaterThan(T element) {
			int count=0;
            
			foreach(T comp in this.maprepo.Values){
                ComparableObject<T> comparable = (ComparableObject<T>)comp;
				if(comparable.isGreaterThan(element))
					count++;
			}
			return count;
		}
	
		
		
		
		
	}

	
	
}
