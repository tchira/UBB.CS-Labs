package controller;
import domain.MyException;
public class Validator {
	
	public boolean validateGrade(int g) throws MyException{
		if(g<1||g>10)
			throw new MyException("Invalid grade");
		return true;
	}
	
	public boolean validateName(String name) throws MyException{
		if(name=="")
			throw new MyException("Empty string for name");
		return true;
	}
	
	public boolean validateId(int id) throws MyException{
		if(id<1)
			throw new MyException("Id must be greater than 0");
		return true;
	}
	

}
