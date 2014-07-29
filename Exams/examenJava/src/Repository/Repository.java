package Repository;

import java.util.ArrayList;

public interface Repository<T> {
	void addAliment(T element);
	ArrayList<T> getAll();

}
