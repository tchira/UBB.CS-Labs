package graph;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Set;


public class Graph {
	
	private ArrayList<Node> vertices=new ArrayList<Node>();
	private HashMap<Node,Set<Edge>> inEdges=new HashMap<Node,Set<Edge>>();
	private HashMap<Node,Set<Edge>> outEdges=new HashMap<Node,Set<Edge>>();
	
	public ArrayList<Node> getVertices(){
		return vertices;
	}
	
	public ArrayList<Edge> getEdges(){
		ArrayList<Edge>	edges=new ArrayList<Edge>();
		for(Node n:vertices)
			for(Edge e:this.outEdges.get(n))
				edges.add(e);
		return edges;
	}
	
	
	//Aux functions to see all the edges
	public HashMap<Node,Set<Edge>> getOutboundEdges(){
		return outEdges;
	}
	
	public HashMap<Node,Set<Edge>> getInboundEdges(){
		return inEdges;
	}
	

	
	public Node getVertexById(int id){
		return this.vertices.get(id);
	}
	
	public void addVertex(Node vert){
		vertices.add(vert);
		HashSet inSet=new HashSet<Edge>();
		HashSet outSet=new HashSet<Edge>();
		inEdges.put(vert, inSet);
		outEdges.put(vert, outSet);
	}
	

	public void addEdge(Node st,Node end,int cost){
		Edge e=new Edge(st,end,cost);
		inEdges.get(end).add(e);
		outEdges.get(st).add(e);
		
	}
	
	public void removeEdge(int st,int end){
		if(this.containsEdge(st, end)){
			Edge e=this.getEdge(st, end);
			this.inEdges.get(new Node(end)).remove(e);
			this.outEdges.get(new Node(st)).remove(e);
		}
		
	}
	
	public int countVertices(){
		return vertices.size();
	}
	
	public String toString(){
		String outp=new String();
		for(Node vertex : vertices){
			outp+=vertex.toString()+" ";
		}
		return outp;
	}
	
	public boolean containsEdge(int st,int end){
		for (Edge e: this.outEdges.get(getVertexById(st)))
			if(e.getEnd().getId()==end)
				return true;
			return false;
			
		
	}
	
	public Edge getEdge(int st,int end){
		for (Edge e: this.outEdges.get(getVertexById(st)))
			if(e.getEnd().getId()==end)
				return e;
			return null;
		
	}
	
	
	public int[] getVertexDegree(int v){
		int deg[]=new int[2];
		if(getVertexById(v)==null)
			return null;
		deg[0]=this.inEdges.get(getVertexById(v)).size();
		deg[1]=this.outEdges.get(getVertexById(v)).size();
		return deg;
		
	}
	
	public HashSet<Edge> getOutboundForVertex(int id){
		HashSet<Edge> outv=new HashSet<Edge>();
		Iterator<Edge> itr=this.outEdges.get(getVertexById(id)).iterator();
		while(itr.hasNext())
			outv.add(itr.next());
		
		return outv;
	}
	
	public Iterator<Edge> getOutboundIterator(int id){
		Iterator<Edge> itr=this.outEdges.get(getVertexById(id)).iterator();
		return itr;
	}
	
	public void printMatrix(int[][] m,int size){
		for(int i=0;i<size;i++)
		{for(int j=0;j<size;j++)
			System.out.print(" "+m[i][j]);
		System.out.println();
		}
		System.out.println();
	}
	
	public HashSet<Edge> getInboundForVertex(int id){
		HashSet<Edge> inv=new HashSet<Edge>();
		Iterator<Edge> itr=this.inEdges.get(getVertexById(id)).iterator();
		while(itr.hasNext())
			inv.add(itr.next());
		
		return inv;
	}
	
	
	

	
}
