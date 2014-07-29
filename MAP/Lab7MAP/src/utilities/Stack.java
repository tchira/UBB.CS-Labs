package utilities;
import java.io.Serializable;

import domain.MyException;

public class Stack<T> implements Serializable{
	private LinkedList<T> list;
	private int size=0;
	
	
	public Stack() {
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
	
	public T pop() throws MyException{
		if(this.size==0)
			throw new MyException("Empty stack");
		Node<T> last=this.list.getLastNode();
		this.list.deleteNode(last);
		size--;
		return last.info;
	}
	
	public T peek() throws MyException{
		if(this.size==0)
			throw new MyException("Empty stack");
		return (this.list.getLastNode().info);
	}
	
	public boolean isEmpty(){
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
