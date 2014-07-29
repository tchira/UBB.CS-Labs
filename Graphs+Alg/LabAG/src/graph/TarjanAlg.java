package graph;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;


public class TarjanAlg {
	private static int INFINITY = 100000;
	
	private Graph graph;
	private List<Integer> sortedList = new ArrayList<Integer>();
	private int verticesNo;
	private boolean isDAG; 
	
	private Set<Integer> unmarked = new HashSet<Integer>();
	private Set<Integer> temporaryMarked = new HashSet<Integer>();
	private Set<Integer> permanentlyMarked = new HashSet<Integer>();
	
	public TarjanAlg(Graph g) {
		this.graph = g;
		this.verticesNo = graph.countVertices(); 
		this.isDAG = true;
		
		this.unmarked = new HashSet<Integer>();
		this.temporaryMarked = new HashSet<Integer>();
		this.permanentlyMarked = new HashSet<Integer>();
	}
	
	public List<Integer> sort() {
		//set all vertices as unmarked
		for (int i = 0; i < verticesNo; i++) {
			unmarked.add(i);
		}
		
		//dfs on graph
		while (!unmarked.isEmpty()) {
			visit(unmarked.iterator().next());
		}
		//return
		if (isDAG) {
			return sortedList;
		} else {
			return null;
		}
	}
		
	private void visit(int node) {
		//if you can visit same node twice there is a cycle
		if (temporaryMarked.contains(node)) {
			isDAG = false;
		}
		//go in depth and mark as temporary
		if (unmarked.contains(node)) {
			unmarked.remove(node);
			temporaryMarked.add(node);
			
			Iterator<Edge> iterator=this.graph.getOutboundIterator(node);
			while (iterator.hasNext()) {
				Edge e=iterator.next();
				visit(e.getEnd().getId());
				
			}
			// mark as permanently when returning from depth
			temporaryMarked.remove(node);
			permanentlyMarked.add(node);
			sortedList.add(0, node);
		}
		
		
	}
	
	public List<Integer> longestPath(int source, int target) {
		if (!isDAG) {
			return null;
		}
		//init lengths and path
		int[] lengthTo = new int[verticesNo];
		int[] previous = new int[verticesNo];
		//compute paths
		sortedList=sort();
		for (int vertex: sortedList) {
			Iterator<Edge> iterator = graph.getOutboundIterator(vertex);
			while (iterator.hasNext()) {
				Edge e=iterator.next();
				int child = e.getEnd().getId();
				int edgeCost = e.getCost();
				
				if (lengthTo[child] < lengthTo[vertex] + edgeCost) {
					lengthTo[child] = lengthTo[vertex] + edgeCost;
					previous[child] = vertex;
				}
				
				
			}
		}
		//put path in list and return
		int t = target;
		List<Integer> path = new ArrayList<Integer>();
		path.add(target);
		while (previous[t] != source) {
			path.add(0, previous[t]);
			t = previous[t];
		}
		path.add(0, source);
		return path;
	}
	
	
	
	
public Integer distinctPaths(int source, int target) {
		if (!isDAG) {
			return null;
		}
		sortedList=sort();
		//init lengths and count
		int[] lengthTo = new int[verticesNo];
		for (int i = 0; i < verticesNo; i++) {
			lengthTo[i] = INFINITY;
		}
		lengthTo[source] = 0;
		
		int[] count = new int[verticesNo];
		count[source] = 1;
		//compute paths
		for (int vertex: sortedList) {
			Iterator<Edge> iterator = graph.getOutboundIterator(vertex);
			while (iterator.hasNext()) {
				Edge e=iterator.next();
				int child = e.getEnd().getId();
				int edgeCost = e.getCost();
				
				if (lengthTo[child] > lengthTo[vertex] + edgeCost) {
					lengthTo[child] = lengthTo[vertex] + edgeCost;
				}
				count[child] += count[vertex];
				
				
			}
		}
		return count[target];
	}

}
