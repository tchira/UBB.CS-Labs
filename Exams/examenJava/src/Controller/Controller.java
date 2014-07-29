package Controller;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

import Repository.Repository;
import domain.Aliment;


public class Controller {
	
	public Repository<Aliment> repo;
	
	public Controller(Repository<Aliment> r){
		this.repo=r;
	}
	
	public void addAliment(Aliment a){
		this.repo.addAliment(a);
	}
	
	public ArrayList<Aliment> getAll(){
		return this.repo.getAll();
	}
	
	public void printToFile(){
		try {
		
			PrintWriter writer = new PrintWriter("repo.txt", "UTF-8");
			for(Aliment a:repo.getAll()){
				if(a.weight>10){
				String astring=a.toString();
				writer.println(astring);
				}
				
			}
			
			writer.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
