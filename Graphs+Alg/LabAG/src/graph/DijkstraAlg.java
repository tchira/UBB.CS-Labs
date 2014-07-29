package graph;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class DijkstraAlg {
	
	private final List<Node> nodes;
	private final List<Edge> edges;
	private Set<Node> sNodes;
	private Set<Node> unsNodes;
	private Map<Node,Node> prev;
	private Map<Node,Integer> distance;
	
	
	public DijkstraAlg(Graph gr){
		this.nodes=gr.getVertices();
		this.edges=gr.getEdges();
	}
	
	public void execute(Node source){
		sNodes=new HashSet<Node>();
		unsNodes= new HashSet<Node>();
		distance=new HashMap<Node,Integer>();
		prev=new HashMap<Node,Node>();
		distance.put(source,0);
		prev.put(source,null);
		unsNodes.add(source);
		while(unsNodes.size()>0)
		{
			Node n=getMinimum(unsNodes);
			sNodes.add(n);
			unsNodes.remove(n);
			findMinimalDistances(n);
		}
	}
	

	private void findMinimalDistances(Node n){
		List<Node> adjNodes=getNeighbours(n);
		for(Node target: adjNodes){
			if(getShortestDistance(target)>getShortestDistance(n)+getDistance(n,target)){
				distance.put(target,getShortestDistance(n)+getDistance(n,target));
				prev.put(target,n);
				unsNodes.add(target);
			}
		}
	}
	
	private int getDistance(Node n,Node t){
		for(Edge e:edges){
			if(e.getStart().equals(n)&&e.getEnd().equals(t))
				return e.getCost();
		}
		throw new RuntimeException("Should not happen");
	}
	
	private List<Node> getNeighbours(Node n){
		List<Node> neighbours=new ArrayList<Node>();
		for(Edge e:edges){
			if(e.getStart().equals(n)&&!isSettled(e.getEnd())){
				neighbours.add(e.getEnd());
			}
		}
		return neighbours;
	}
	
	private Node getMinimum(Set<Node> vertices){
		Node min=null;
		for(Node n:vertices){
			if(min==null){
				min=n;
			}
			else{
				if(getShortestDistance(n)<getShortestDistance(min)){
					min=n;
				}
			}
		}
		return min;
	}
	
	private boolean isSettled(Node vertex){
		return sNodes.contains(vertex);
	}
	
	private int getShortestDistance(Node dest){
		Integer d=distance.get(dest);
		if(d==null){
			return Integer.MAX_VALUE;	
		}
		else{
			return d;
		}
	}
	
	public LinkedList<Node> getPath(Node target){
		LinkedList<Node> path=new LinkedList<Node>();
		Node step=target;
		if(prev.get(step)==null){
			return null;
		}
		path.add(step);
		while(prev.get(step)!=null){
			step=prev.get(step);
			path.add(step);
		}
		Collections.reverse(path);
		return path;
	}
	
	public Map<Node,Node> getPrev(){
		return this.prev;
	}
}
