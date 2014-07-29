package ui;

import java.util.Observable;
import java.util.Observer;

import controller.Controller;
import domain.Student;


	public class ControllerObserver2 implements Observer {
		private Controller c;
		
		public ControllerObserver2(Controller c){
			this.c=c;
		}
		
		public void update(Observable obs,Object obj)
		{	System.out.println("Students with average lower than 5:\n");
			for(Student s:c.getAll())
				if (s.getAverage()<5)
					System.out.println(s);
			
		}
	}

