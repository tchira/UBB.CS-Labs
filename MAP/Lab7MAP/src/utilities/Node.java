package utilities;

import java.io.Serializable;

public class Node<T> implements Serializable {
	public T info;
	public Node<T> next;
	
	public Node(T info){
		this.info=info;
		this.next=null;
	}


}
