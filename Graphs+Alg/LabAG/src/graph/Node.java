package graph;

public class Node {
	private int id;
	
	public Node(int id){
		this.id=id;
	}
	
	public int getId(){
		return id;
	}
	
	public String toString(){
		return String.valueOf(id);
	}
	
	
	@Override
	public boolean equals(Object other){
	    if (other == null) return false;
	    if (other == this) return true;
	    if (!(other instanceof Node))return false;
	    Node n = (Node)other;
	   if(n.getId()==this.getId()) return true;
	   return false;
	}
	
	  @Override
	  public int hashCode() {
	    final int prime = 31;
	    int result = 1;
	    result = prime * result + id;
	    return result;
	  }

}
