package ui;
import java.util.ArrayList;
import java.util.Scanner;


import controller.Controller;
import controller.Validator;
import domain.GraduateStudent;
import domain.MyException;
import domain.PhdStudent;
import domain.Student;
import domain.UndergraduateStudent;
import java.util.Observable;
import java.util.Observer;

public class Console {
	private Controller cont;
	private Validator valid;
	Scanner input=new Scanner(System.in);
	ArrayList<Student> repo;
	
	
	
	public Console(Controller c,Validator v){
		this.cont=c;
		this.valid=v;
	}
	
	public boolean addMenu(){ //Read parameters until they are correct
		try {int select=0;
			System.out.println("Type: \n (1)Student \n (2)Graduate \n (3)Undergraduate \n (4)PHD");
			select=input.nextInt();
			System.out.println("ID: ");
			String sid,thesis,supervisor;
			int id;
			int grade2,grade3;
			Student s;
			
			sid=input.next();
			try { id=Integer.parseInt(sid);
			}
			catch(NumberFormatException e) { 
		        return false; 
			}
			
			System.out.println("Name:");
			String name = null;
			name = input.next();
			System.out.println("Grade:");
			int grade = input.nextInt();
			this.valid.validateId(id);
			this.valid.validateGrade(grade);
			this.valid.validateName(name);
			switch(select){
				case 1:
					s = new Student(id,name,grade);
					cont.addStudent(s);
					break;
					
				case 2:
					System.out.println("Grade 2");
					grade2=input.nextInt();
					System.out.println("Grade 3");
					grade3=input.nextInt();
					System.out.println("Supervisor");
					supervisor=input.next();
					this.valid.validateGrade(grade2);
					this.valid.validateGrade(grade3);
					s=new GraduateStudent(id,name,supervisor,grade,grade2,grade3);
					cont.addStudent(s);
					break;
					
				case 3:
					System.out.print("Grade2: ");
                    grade2 = input.nextInt();
                    this.valid.validateGrade(grade2);
                    s=new UndergraduateStudent(id,name,grade,grade2);
                    cont.addStudent(s);
                    break;
					
				
				case 4:
					System.out.print("Grade2: ");
                    grade2 = input.nextInt();
                    this.valid.validateGrade(grade2);
                    System.out.print("Grade3: ");
                    grade3= input.nextInt();
                    this.valid.validateGrade(grade3);
                    System.out.print("Supervisor: ");
                    supervisor = input.next();
                    System.out.print("Thesis: ");
                    thesis = input.next();
					s=new PhdStudent(id,name,thesis,supervisor,grade,grade2,grade3);
					cont.addStudent(s);
					break;
			}
			
			return true;
		} catch (MyException e) {
			// TODO Auto-generated catch block
			System.out.println(e.getMessage());
			return false;
		}
		
	}
	
	public void viewMenu(){
		int nr = cont.getSize();
		repo = cont.getAll();
		if (nr == 0){
			System.out.println("No students");
		}
		else
			for(Student s:repo){
				System.out.println(s);
			}
		
	
	}
	
	
	public void runMenu(){
		while(true){
			System.out.println("Select an option");
			System.out.println("1. Add student");
			System.out.println("2. View students");
			System.out.println("3. Show number of students");
			System.out.println("4. Delete students until grade 10 is reached");
			System.out.println("5. Quit");
			System.out.println("6. Count students with average greater than x");
			int opt = input.nextInt();
			if(opt==5){ 
				break;
			}
			if (opt ==1) 
				if (addMenu()) System.out.println("Student added");
				else System.out.println("Failed to add student");
			
			if(opt ==2){
				viewMenu();
			}
			
			if(opt==3){
				int nr=cont.getSize();
				System.out.println("There are "+nr+" students");
			}
			
			if(opt==4){
				try{
				this.cont.delete10();
				}
				catch (MyException e){
					System.out.println(e.getMessage());
				}
			}
			
			if(opt==6){
				System.out.println("Id to compare average:");
				int id = input.nextInt();
		        int count = cont.countElementsGreaterThan(id);
		        if (count==-1)
		        	System.out.println("Student with id doesn't exist");
		        else
		        System.out.println("Number of students with average greater than id "+id+" :"+count);
			}
				
			
			
		}
		
	}
	

}
