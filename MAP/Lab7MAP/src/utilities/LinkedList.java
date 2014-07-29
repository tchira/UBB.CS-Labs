package utilities;

import java.io.Serializable;

public class LinkedList<T> implements Serializable {
	public Node<T> first;
	
	public Node<T> getLastNode(){
		if (this.first==null)
			return null;
		else{
			Node<T> n=this.first;
			while (n.next!=null)
				n=n.next;
			return n;
		}
	}
		
	
		
public void deleteNode(Node<T> n){
		Node<T> current=first;
		Node<T> next=current.next;
		
		if(n==this.first){
			this.first=next;
			return;
		}
		
		while(next!=null){
			if(next==n){
				current.next=next.next;
				current=next;
				next=next.next;
			}
			else{
				current=next;
				next=next.next;
			}
		}
		
	}
		
		
public LinkedList<T> getAll(){
	LinkedList<T> all=new LinkedList<T>();
	Node<T> cNode=null;
	Node<T> cNodeAll=null;
	Node<T> nNode=null;
	Node<T> nNodeAll=null;
	//Initialise the first node in the copied list
	if(this.first!=null){
		cNodeAll=new Node(this.first.info);
		all.first=cNodeAll;
		cNode=this.first;
		cNodeAll=all.first;
		nNode=this.first.next;
		
		//parses both lists node by node, copying data from the old list into the new one
		while(nNode!=null){
			nNodeAll=new Node<T>(nNode.info);
			cNodeAll.next=nNodeAll;
			cNode=nNode;
			cNodeAll=nNodeAll;
			nNode=nNode.next;
		}
	}
	return all;
	
}
			
	

}
