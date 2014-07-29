package graph;

public class Edge {
	private int cost;
	private Node startp;
	private Node endp;
	
	public Edge(Node stp,Node ep,int c){
		this.startp=stp;
		this.endp=ep;
		this.cost=c;
	}
	
	public int getCost(){
		return this.cost;
	}
	
	public void setCost(int newc){
		this.cost=newc;
	}
	
	public Node getStart(){
		return this.startp;
	}
	
	public Node getEnd(){
		return this.endp;
	}
	
	public String toString(){
		return "["+startp+","+endp+"]("+cost+")";
	}
}
