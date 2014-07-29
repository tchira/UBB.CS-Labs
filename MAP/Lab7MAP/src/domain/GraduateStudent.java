package domain;

public class GraduateStudent extends Student implements ComparableObject<Student>,Identifiable {
	
	protected String supervisor;
	protected int grade2;
	protected int grade3;
	
	public GraduateStudent(int id, String name, String supervisor,int grade,int grade2,int grade3){
		super(id,name,grade);
		this.supervisor=supervisor;
		this.grade2=grade2;
		this.grade3=grade3;
	}
	
	@Override
	public float getAverage(){
		return (this.grade+this.grade2+this.grade3)/3;
	}
	
	@Override
	public boolean isGreaterThan(Student s){
		return (this.getAverage()>s.getAverage());
	}
	
	@Override
	public String toString(){
		return id+" "+name+" "+supervisor+" "+grade+" "+grade2+" "+grade3;
	}
}
