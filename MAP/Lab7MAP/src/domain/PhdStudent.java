package domain;

public class PhdStudent extends Student implements ComparableObject<Student>,Identifiable {
	protected String thesis;
	protected String supervisor;
	protected int grade2;
	protected int grade3;
	
	public PhdStudent(int id, String name,String thesis, String supervisor, int grade,int grade2,int grade3){
		super(id,name,grade);
		this.thesis=thesis;
		this.grade2=grade2;
		this.grade3=grade;
	}
	
	@Override
	public float getAverage(){
		return (grade+grade2+grade3)/3;
	}
	
	@Override
	public boolean isGreaterThan(Student s){
		return this.getAverage()>s.getAverage();
	}
	
	@Override
	public String toString(){
		return +id+" "+name+" "+supervisor+" "+thesis+" "+grade+" "+grade2+" "+grade3;
	}

}
