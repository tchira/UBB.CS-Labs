package graph;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.Queue;

public class Controller {
	
	public Graph _graph;
	
	Controller(Graph newg){
		this._graph=newg;
	}
	
	public ArrayList<Node> getVertices(){
		return _graph.getVertices();
	}
	
	public int count(){
		return _graph.countVertices();
	}
	
	public boolean addVertex(int id){
		if(_graph.getVertexById(id)!=null)
			return false;
		Node n=new Node(id);
		_graph.addVertex(n);
		return true;
	}
	
	public boolean addEdge(int st,int end,int cost){
		Node startv=_graph.getVertexById(st);
		Node endv=_graph.getVertexById(end);
		if(startv!=null && endv!=null){
			_graph.addEdge(startv, endv, cost);
			return true;}
		return false;
		
	}
	
	//aux functions to see all the edges
	public void printOutbound(){
		System.out.println("Outbound edges");
		for (Node n:_graph.getVertices()){
			System.out.println("For node "+n);
			for(Edge e:_graph.getOutboundEdges().get(n))
				System.out.println(e);
			
		}
		System.out.println("\n\n\n");
	}
		
	public void printInbound(){
		System.out.println("Inbound edges");
		for (Node n:_graph.getVertices()){
			System.out.println("For node "+n);
			for(Edge e:_graph.getInboundEdges().get(n))
				System.out.println(e);
		
		}
		System.out.println("\n");
	}
	
	public boolean containsEdge(int st,int end){
		if (this._graph.containsEdge(st,end)) 
			return true;
		else 
			return false;
		
	}
	
	
	
	public Edge getEdge(int st,int end){
		return this._graph.getEdge(st, end);
	}
	
	public int[] getVertexDegree(int v){
		return this._graph.getVertexDegree(v);
	}
	
	public void initVertices(int nr){
		for (int i=0;i<nr;i++)
			this._graph.addVertex(new Node(i));
	}
	
	public HashSet<Edge> getOutboundForVertex(int id){
		return this._graph.getOutboundForVertex(id);
	}
	
	public HashSet<Edge> getInboundForVertex(int id){
		return this._graph.getInboundForVertex(id);
	}
	


			
public void readGraph(String filename) throws NumberFormatException, IOException {
		
		
			BufferedReader br = null;
			try {
				br = new BufferedReader(new FileReader(filename));
			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			String line;
			int lineNo = 0;
			int edgeNo = 0;
			while((line = br.readLine()) != null){
				String[] tokens;
				if(lineNo == 0){
					tokens = line.split(" ");
					
					this.initVertices(Integer.valueOf(tokens[0]).intValue());
					edgeNo = Integer.valueOf(tokens[1]).intValue();
					
				}
				else{	tokens = line.split(" ");
						int sourceVertex = Integer.valueOf(tokens[0]).intValue();
						int targetVertex = Integer.valueOf(tokens[1]).intValue();
						this.addEdge(sourceVertex, targetVertex, Integer.valueOf(tokens[2]).intValue());
						
					}
					
				lineNo++;
			}
			
			
			
			br.close();
		
		}
		
}
	


