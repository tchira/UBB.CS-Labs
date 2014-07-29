package repository;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map;

import domain.ComparableObject;
import domain.Identifiable;
import domain.MyException;
	
	public class RepositoryHashmap<T extends Identifiable> implements Serializable {
		//Class implementing the repository using basic stack operations
		private Map<Integer,T> maprepo;
		
		public RepositoryHashmap(){
			//Stack repository constructor
			//Preconditions:
			//Postcond: A new empty repository stack object is build
			maprepo=new LinkedHashMap<Integer,T>();
		}
		
		public void addObject(T element){
			//Precondition : s= student object
			//Postcondition: Element on top of the stack is the input student object
			this.maprepo.put(element.getId(),element);
		}
		
		
		
		public T getObjectForId(int id){
			return this.maprepo.get(id);
		}
		
		public boolean containsObject(T obj){
			if(this.maprepo.containsValue(obj))
				return true;
			return false;
			
		}
		
		public T getLastObject(){
			for(T el:this.maprepo.values())
				return el;
			return null;
		}
		
		
		public void removeObject(T object) throws MyException{
			this.maprepo.remove(object.getId());
		}
		
		public boolean isEmpty(){
			//Pre: -
			//post: true if stack contains no elements, false otherwise
			return this.maprepo.isEmpty();
		}
		
		public int getSize(){
			//Pre: = 
			//Returns number of elements in the stack
			return this.maprepo.size();
		}
		
		public ArrayList<T> getAll(){
			ArrayList<T> values=new ArrayList<T>();
			for(T obj:this.maprepo.values())
				values.add(obj);
			return values;
		}
		
		public int countElementsGreaterThan(T element){
			int count=0;
			for(T comp:this.maprepo.values()){
				ComparableObject<T> comparable=(ComparableObject<T>) comp;
				if(comparable.isGreaterThan(element))
					count++;
			}
			return count;
		}
	
		
		
		
		
	}

	
	

