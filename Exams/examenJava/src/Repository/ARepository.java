package Repository;

import java.util.ArrayList;



public class ARepository<T> implements Repository<T> {
	public ArrayList<T> repo;
	
	public ARepository(){
		repo=new ArrayList<T>();
	}
	
	public void addAliment(T element){
		this.repo.add(element);
	}

	public ArrayList<T> getAll(){
		ArrayList<T> copy=new ArrayList<T>();
		for(T element:repo)
			copy.add(element);
		return copy;
		
	}
}
