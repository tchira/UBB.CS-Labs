package controller;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Map;
import java.util.Observable;

import repository.RepositoryHashmap;
import utilities.Stack;
import domain.GraduateStudent;
import domain.Identifiable;
import domain.MyException;
import domain.PhdStudent;
import domain.Student;
import domain.UndergraduateStudent;



public class Controller extends Observable{
	public RepositoryHashmap<Student> repo;
	
	public Controller(RepositoryHashmap<Student> rep){
		//Controller constructor
		this.repo=rep;
		this.readFromFile();
		
	}
	
	
	public boolean isEmpty(){
		//Pre: -
		//Post: true if stack contains no elements, false otherwise
		return this.repo.isEmpty();
	}
	public void addStudent(Student s) {
		//Precondition : s= student object
				//Postcondition: Element on top of the stack is the input student object
		this.serialize();
		this.deserialize();
		repo.addObject(s);
		this.printToFile();
		this.setChanged();
		this.notifyObservers();
		
	}
	
	public static<T> void copyElements(Stack<? extends T> src,Stack<T> dest){
		//leftover: copy elements from a generic stack to another
		 Stack<T> aux = new Stack<T>();
	        while (!src.isEmpty()) {
	            try {
	                aux.push(src.pop());
	            } catch (MyException e) {
	                System.out.println(e.getMessage());
	            }
	        }
	        while (!aux.isEmpty()) {
	            try {
	                dest.push(aux.pop());
	            } catch (MyException e) {
	                System.out.println(e.getMessage());
	            }
	        }
	}
	
	public static<T> void copyElementsHash(Map<Integer,? extends Identifiable> src,Map<Integer,Identifiable> dest){
		dest.putAll(src);
	}
	
	public ArrayList<Student> getAll() {
		//Pre: 
		//Post: returns an array containing all the stack's contents
		
		return repo.getAll();
	}
	
	public int getSize(){
		//Pre: = 
		//Returns number of elements in the stack
		return repo.getSize();
	}
	
	
	public void delete10() throws MyException {
		Student del=(Student)this.repo.getLastObject();
		while(del.getAverage()!=10 && del!=null ){
			this.repo.removeObject(del);
			del=(Student)this.repo.getLastObject();
		}
		
		this.setChanged();
		this.notifyObservers();
	}
	
	
		
	public void serialize(){
		try {
			FileOutputStream fos =new FileOutputStream("students.out");
			ObjectOutputStream out =new ObjectOutputStream(fos);
			out.writeObject(repo);
			out.flush();
			fos.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	
	
	public void deserialize(){
		try {
			FileInputStream fis= new FileInputStream("students.out");
			ObjectInputStream in=new ObjectInputStream(fis);
			this.repo=(RepositoryHashmap<Student>)in.readObject();
			fis.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public int countElementsGreaterThan(int id){
		Student s=(Student) this.repo.getObjectForId(id);
		if(s==null)
			return -1;
		return this.repo.countElementsGreaterThan(s);
	}
	
	public void printToFile(){
		try {
			//BufferedWriter output;
			//File file = new File("studentrepo.txt");
			//output = new BufferedWriter(new FileWriter(file));
			PrintWriter writer = new PrintWriter("studentrepo.txt", "UTF-8");
			for(Object element:repo.getAll()){
				String studstring=element.toString();
				writer.println(studstring);
				
			}
			//output.close();
			writer.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public void readFromFile(){
		BufferedReader br=null;
		int length;
		String line;
		String[] tokens;
		try {
			br=new BufferedReader(new FileReader("studentrepo.txt"));
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		try {
			while((line=br.readLine())!=null){
				
				tokens=line.split(" ");
				length=tokens.length;
				switch(length){
					case 3:
						Student s1=new Student(Integer.parseInt(tokens[0]),tokens[1],Integer.parseInt(tokens[2]));
						repo.addObject(s1);
						break;
					case 4:
						UndergraduateStudent s2=new UndergraduateStudent(Integer.parseInt(tokens[0]),tokens[1],Integer.parseInt(tokens[2]),Integer.parseInt(tokens[3]));
						repo.addObject(s2);
						break;
					case 6:
						GraduateStudent s3=new GraduateStudent(Integer.parseInt(tokens[0]),tokens[1],tokens[2],Integer.parseInt(tokens[3]),Integer.parseInt(tokens[4]),Integer.parseInt(tokens[5]));
						repo.addObject(s3);
						break;
					case 7:
						PhdStudent s4=new PhdStudent(Integer.parseInt(tokens[0]),tokens[1],tokens[2],tokens[3],Integer.parseInt(tokens[4]),Integer.parseInt(tokens[5]),Integer.parseInt(tokens[6]));
						repo.addObject(s4);
						break;
				}
			}
		} catch (NumberFormatException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
}
	
	





