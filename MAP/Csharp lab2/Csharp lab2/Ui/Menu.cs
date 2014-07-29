using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.controller;
using Csharp_lab2.Domain;
using Csharp_lab2.Utils;



namespace Csharp_lab2.Ui
{
    class Menu
    {
       
        private Controller cont;
        private Validator valid;

	List<Student> repo;
    
	public Menu(Controller c,Validator v){
		this.cont=c;
        this.valid = v;
	}
	
	public bool addMenu(){ //Read parameters until they are correct
        try
        {
            int select = 0;
            Console.WriteLine("Type: \n (1)Student \n (2)Graduate \n (3)Undergraduate \n (4)PHD");
            select = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ID: ");
            String sid, thesis, supervisor;
            int id;
            int grade2, grade3;
            Student s;
            string input;
            input=Console.ReadLine();
            int.TryParse(input, out id);
            if (id == 0)
                throw new MyException("Wrong id");
           
            Console.WriteLine("Name:");
            String name = Console.ReadLine();

            Console.WriteLine("Grade:");
            int grade = Convert.ToInt32(Console.ReadLine());
            this.valid.validateGrade(grade);
            this.valid.validateId(id);
            this.valid.validateName(name);
           switch(select){
				case 1:
					s = new Student(id,name,grade);
					cont.addStudent(s);
					break;
					
				case 2:
					Console.WriteLine("Grade 2");
                    grade2 = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Grade 3");
                    grade3 = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Supervisor");
					supervisor=Console.ReadLine();
					this.valid.validateGrade(grade2);
					this.valid.validateGrade(grade3);
                    s = new GraduateStudent(id, name, supervisor,grade, grade2, grade3);
					cont.addStudent(s);
					break;
					
				case 3:
					Console.WriteLine("Grade2: ");
                    grade2 = Convert.ToInt32(Console.ReadLine());
                    this.valid.validateGrade(grade2);
                    s=new UndergraduateStudent(id,name,grade,grade2);
                    cont.addStudent(s);
                    break;
					
				
				case 4:
					Console.WriteLine("Grade2: ");
                    grade2 = Convert.ToInt32(Console.ReadLine());
                    this.valid.validateGrade(grade2);
                    Console.WriteLine("Grade3: ");
                    grade3 = Convert.ToInt32(Console.ReadLine());
                    this.valid.validateGrade(grade3);
                    Console.WriteLine("Supervisor: ");
                    supervisor = Console.ReadLine();
                    Console.WriteLine("Thesis: ");
                    thesis = Console.ReadLine();
					s=new PhdStudent(id,name,thesis,supervisor,grade,grade2,grade3);
					cont.addStudent(s);
					break;
            }
           return true;
        }
        catch (MyException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
	}


	
	public void viewMenu(){
		
     	int nr = cont.getSize();
		repo = cont.getAll();
		if (nr == 0){
			Console.WriteLine("No students");
		}
		else
		foreach(Student s in repo)
            Console.WriteLine(s);
    }
					

	
	
	public void runMenu(){
		while(true){
			Console.WriteLine("Select an option");
			Console.WriteLine("1. Add student");
			Console.WriteLine("2. View students");
			Console.WriteLine("3. Show number of students");
			Console.WriteLine("4. Delete students until grade 10 is reached");
			Console.WriteLine("5. Quit");
            Console.WriteLine("6. Compare to student (input id)");
			int opt = Convert.ToInt32(Console.ReadLine());
			if(opt==5){ 
				break;
               
			}
			if (opt ==1) 
				if (addMenu()) Console.WriteLine("Student added");
				else Console.WriteLine("Failed to add student");
			
			if(opt ==2){
				viewMenu();
			}
			
			if(opt==3){
				int nr=cont.getSize();
				Console.WriteLine("There are "+nr+" students");
			}
			
			if(opt==4){
                try
                {
                    this.cont.delete10();
                }
                catch (MyException e)
                {
                    Console.WriteLine(e.Message);
                }
			}

            if (opt == 6)
            {Console.WriteLine("Id to compare average:");
				int id =Convert.ToInt32(Console.ReadLine());
                int count = cont.countElementsGreaterThan(id);
                if (count == -1)
                    Console.WriteLine("Student doesn't exist");
                else
		            Console.WriteLine("Number of students with average greater than id"+id+" :"+count);
            }
				
			
			
		}
		
	}
	

    }
}
