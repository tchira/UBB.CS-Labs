using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Domain
{   [Serializable]
    public class Student :Identifiable,ComparableObject<Student>
    {
        
	protected int id;
	protected String name;
	protected int grade;


public Student(){
	/*Student constructor method
	 Precondition - 
	 Postcondition - A new Student object is created (default values)
	 */
}

public Student(int id,String name,int grade){
	//Student constructor method
	//Precondition - 
	//Postcondition - New student object is created, with function arguments as values 
	this.id=id;
	this.name=name;
	this.grade=grade;
}


public void setId(int id){
	//Student id setter
	//Precond:- id= integer
	//Postcondition - id field of the calling object receives new id value
	this.id=id;
}

public void setName(String name){
	//Student name setter
	//Precond: - name=string
	//Postcond: - Object name field gets a new value
	this.name=name;
}

public void setGrade(int grade){
	//Student grade setter
	//Precond:- grade=integer
	//Postcont: Object grade gets a new value
}


//Object getters:
//Functions return the values of the object fields
public int getId(){
	//returns the id (int)
	return this.id;
}

public String getName(){
	//returns the name(string)
	return this.name;
}

public int getGrade(){
	//returns the grade (int)
	return this.grade;
}


public override string ToString(){
	//Override for the string output function
	//Precond:- function called by a student object
	//Postcont:- outputs the object values in a string format
	
	return id+" "+name+" "+grade;
}

public virtual float getAverage(){
    return this.grade;
}

public bool isGreaterThan(Student s)
{
    return (this.getAverage() > s.getAverage());
}


        }
}
