package repository;
import java.io.Serializable;
import java.util.ArrayList;

import utilities.Stack;
import domain.MyException;

public class RepositoryStack<T> implements Serializable {
	//Class implementing the repository using basic stack operations
	private Stack<T> stacklist;
	
	public RepositoryStack(){
		//Stack repository constructor
		//Preconditions:
		//Postcond: A new empty repository stack object is build
		stacklist=new Stack<T>();
	}
	
	public void addObject(T element){
		//Precondition : s= student object
		//Postcondition: Element on top of the stack is the input student object
		this.stacklist.push(element);
	}
	
	public Stack<T> getAll(){
		return this.stacklist.getAll();
	}
	
	public T getLastStudent() throws MyException{
		try{
		return this.stacklist.peek();
		}
		catch (MyException e){
			throw new MyException(e.getMessage());
		}
		}
	
	public void removeStudent(T object) throws MyException{
		Stack<T> aux=new Stack<T>();
		while(true){
			T auxobj=this.stacklist.pop();
			if(auxobj.equals(object)) break;
			aux.push(auxobj);
		}
		while(aux.getSize()!=0){
			this.stacklist.push(aux.pop());
		}
		
	}
	
	public boolean isEmpty(){
		//Pre: -
		//post: true if stack contains no elements, false otherwise
		return (this.stacklist.isEmpty());
	}
	
	public int getSize(){
		//Pre: = 
		//Returns number of elements in the stack
		return this.stacklist.getSize();
	}
	
	public ArrayList<T> toArray(){
		Stack<T> stackcopy=this.getAll();
		ArrayList<T> crepo=new ArrayList<T>();
		while(!stackcopy.isEmpty())
			try {
				crepo.add(stackcopy.pop());
			} catch (MyException e) {
				// TODO Auto-generated catch block
				return crepo;
			}
		return crepo;
	}
	
	
	
}
