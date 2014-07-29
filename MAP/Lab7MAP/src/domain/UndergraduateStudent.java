package domain;

public class UndergraduateStudent extends Student implements ComparableObject<Student>,Identifiable{
	protected int grade2;
	
	public UndergraduateStudent(int id,String name, int grade,int grade2) {
		super(id,name,grade);
		this.grade2=grade2;
	}
	
	@Override
	public float getAverage(){
		return (this.grade2+this.grade)/2;
				
	}
	
	@Override
	public boolean isGreaterThan(Student s){
		return this.getAverage()>s.getAverage();
	}
	
	@Override
	public String toString(){
		return id+" "+name+" "+grade+" "+grade2;
	}


}
