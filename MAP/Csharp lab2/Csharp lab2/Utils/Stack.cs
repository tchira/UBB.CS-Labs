using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.Domain;

namespace Csharp_lab2.Utils
{   [Serializable]
    public class Stack<T>
    {
        private LinkedList<T> list;
	private int size=0;
	
	
	public Stack(){
		list=new LinkedList<T>();
	}
	
	public void push(T newelement){
		Node<T> n=new Node<T>(newelement);
		if(list.getLastNode()==null)
			list.first=n;
		else
			list.getLastNode().next=n;
		size++;
	}
	
	public T pop(){
		if(this.size==0)
			throw new MyException("Empty stack");
		Node<T> last=this.list.getLastNode();
		this.list.deleteNode(last);
		size--;
		return last.info;
	}
	
	public T peek(){
		if(this.size==0)
			throw new MyException("Empty stack");
		return (this.list.getLastNode().info);
	}
	
	public bool isEmpty(){
		return(this.getSize()==0);
	}
	
	public Stack<T> getAll(){
		Stack<T> all=new Stack<T>();
		all.list=this.list.getAll();
		all.size=this.getSize();
		return all;
		
	}
	
	
	public int getSize(){
		return this.size;
	}
    }
}
