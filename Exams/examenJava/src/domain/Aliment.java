package domain;

public class Aliment {
	public String name;
	public String type;
	public int weight;
	
	public Aliment(String t,String n,int w){
		this.type=t;
		this.name=n;
		this.weight=w;
		
	}
	
	public String toString(){
		return this.type+ " "+this.name+ " "  + this.weight;
	}

}
