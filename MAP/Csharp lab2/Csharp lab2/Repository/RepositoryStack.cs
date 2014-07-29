using Csharp_lab2.Domain;
using Csharp_lab2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Csharp_lab2.Repository
{
    [Serializable]
    public class RepositoryStack<T>{
	//Class implementing the repository using basic stack operations
	private Utils.Stack<T> studentlist;
	
	public RepositoryStack(){
		//Stack repository constructor
		//Preconditions:
		//Postcond: A new empty repository stack object is build
		studentlist=new Utils.Stack<T>();
	}
	
	public void addObject(T obj){
		//Precondition : s= student object
		//Postcondition: Element on top of the stack is the input student object
		this.studentlist.push(obj);
	}
	
	public Utils.Stack<T> getAll(){
		return this.studentlist.getAll();
	}
	
	public T getLastStudent() {
		
		return this.studentlist.peek();
	}
	
	public void removeStudent(Object s) {
		Utils.Stack<T> aux=new Utils.Stack<T>();
		while(true){
			T ss=this.studentlist.pop();
			if(ss.Equals(s)) break;
			aux.push(ss);
		}
		while(aux.getSize()!=0){
			this.studentlist.push(aux.pop());
		}
		
	}

    public List<T> toArray()
    {   List<T> crepo=new List<T>();
        Utils.Stack<T> stackcopy = this.getAll();
        int i=0;
        while (!stackcopy.isEmpty())
           crepo.Add(stackcopy.pop());
        return crepo;
        
    }
	
	public bool isEmpty(){
		//Pre: -
		//post: true if stack contains no elements, false otherwise
		return (this.studentlist.isEmpty());
	}
	
	public int getSize(){
		//Pre: = 
		//Returns number of elements in the stack
		return this.studentlist.getSize();
	}
	

	
}
}
