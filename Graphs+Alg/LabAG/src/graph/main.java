package graph;

import java.io.IOException;



public class main {

	public static void main(String[] args) {
		Graph g0 = new Graph();
		Controller cont=new Controller(g0);
		try {
			cont.readGraph("graph.txt");
		} catch (NumberFormatException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		Console ui=new Console(cont);
		ui.runMenu();
		
		
	}

}
