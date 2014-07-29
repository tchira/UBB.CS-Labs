package graph;


import java.util.Arrays;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;



public class Console {
	private int st,end;
	private Controller cont;
	Scanner input=new Scanner(System.in);
	public Console(Controller c){
		this.cont=c;
	}
	
	
	public void runMenu(){
		while(true){
			System.out.println("Select an option");
			System.out.println("1. Get number of vertices");
			System.out.println("2. Get all outbound edges");
			System.out.println("3. Get all inbound edges");
			System.out.println("4. Breadth first starting from ending node");
			System.out.println("6. Quit");
			System.out.println("7. Check if edge exists");
			System.out.println("8. Get vertex degree");
			System.out.println("9. Get edge cost");
			System.out.println("10. Parse outbound edges for vertex");
			System.out.println("11. Parse inbound edges for vertex");
			System.out.println("12. Find shortest path between vertices (Dijkstra)");
			System.out.println("13. Find hamiltonian cycle");
			System.out.println("14. Remove edge");
			System.out.println("15. Highest cost path in DAG (with topo sorting)");			
			System.out.println("16. Number of distinct paths between source and target");
			
			int opt = input.nextInt();
			
			if(opt==6){ 
				break;
			}
			if (opt ==1)
				System.out.println(cont.count()+" vertices.");
				
			
			if(opt ==2){
				cont.printOutbound();
			}
			
			if(opt==3){
				cont.printInbound();
			}
			
			if(opt==4){
				System.out.println("Insert source vertex:");
				int sid=input.nextInt();
				System.out.println("Insert ending vertex:");
				int eid=input.nextInt();
				BreadthFirstSearch bfs=new BreadthFirstSearch(this.cont._graph,sid);
				if(bfs.hasPathTo(eid)){{
					System.out.print(Integer.toString(sid)+" to "+Integer.toString(eid)+"("+Integer.toString(bfs.distTo(eid))+")");
					System.out.println();
				}
				LinkedList<Integer> path=bfs.pathTo(eid);
				Collections.reverse(path);
				for(int x:path){
					if(x==sid) System.out.print(x);
					else System.out.print("->"+x);
				}
				System.out.println();
				}
				else System.out.println("Not connected");
				
			
			}
			
			if(opt==7){
				System.out.println("Insert edge startpoint");
				st=input.nextInt();
				System.out.println("Insert edge endpoint");
				end=input.nextInt();
				if(cont.containsEdge(st, end))
					System.out.println("Edge exists");
				else
					System.out.println("Edge doesn't exist");
			}
			
			if(opt==8){
				System.out.println("Insert vertex id:");
				st=input.nextInt();
				if(cont.getVertexDegree(st)==null)
					System.out.println("Vertex doesn't exist");
					else{
				int[] degree=cont.getVertexDegree(st);
				System.out.println("In degree:"+degree[0]);
				System.out.println("Out degree:"+degree[1]);
				}
			}
				
			if(opt==9){
				System.out.println("Insert edge startpoint");
				st=input.nextInt();
				System.out.println("Insert edge endpoint");
				end=input.nextInt();
				if(!cont.containsEdge(st, end))
					System.out.println("Edge doesn't exist");
				else
					System.out.println("Edge cost:"+cont.getEdge(st, end).getCost());
				
			}
			
			if(opt==10){
				System.out.println("Insert vertex id:");
				st=input.nextInt();
				System.out.println(this.cont.getOutboundForVertex(st));
			}
			
			if(opt==11){
				System.out.println("Insert vertex id:");
				st=input.nextInt();
				System.out.println(this.cont.getInboundForVertex(st));
			}
			
			if(opt==12){
				System.out.println("Source vertex:");
				st=input.nextInt();
				System.out.println("Destination vertex:");
				end=input.nextInt();
				Node start=new Node(st);
				Node target=new Node(end);
				DijkstraAlg da=new DijkstraAlg(this.cont._graph);
				da.execute(start);
				LinkedList<Node> path=da.getPath(target);
				try {
					System.out.println(Arrays.toString(path.toArray()));
				} catch (Exception e) {
					// TODO Auto-generated catch block
					System.out.println("Path does not exist");
				}
			
				
			}
			
		
				
			if(opt==14)
			{
				System.out.println("Insert edge startpoint");
				st=input.nextInt();
				System.out.println("Insert edge endpoint");
				end=input.nextInt();
				if(!cont.containsEdge(st, end))
					System.out.println("Edge doesn't exist");
				else
					this.cont._graph.removeEdge(st, end);
				
			}
			
			if(opt==15)
			{	
				
				TarjanAlg ttj=new TarjanAlg(cont._graph);
				List<Integer> sortedList=ttj.sort();
				System.out.println(sortedList);
				System.out.println("Insert source vertex");
				st=input.nextInt();
				System.out.println("Insert target vertex");
				end=input.nextInt();
				List<Integer> path=ttj.longestPath(st,end);
				System.out.println(path);
			}
			
			if(opt==16)
			{
				TarjanAlg ttj=new TarjanAlg(cont._graph);
				System.out.println("Insert source vertex");
				st=input.nextInt();
				System.out.println("Insert target vertex");
				end=input.nextInt();
				int distinct=ttj.distinctPaths(st,end);
				System.out.println(distinct);
			}
			
			
				
				
		}
		
	}
	

}
