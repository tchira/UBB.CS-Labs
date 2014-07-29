package UInterface;

import java.util.ArrayList;
import java.util.Scanner;

import Controller.Controller;
import domain.Aliment;

public class UserConsole {
	public Controller cont;
	
	public UserConsole(Controller c){
		this.cont=c;
	}
	
	public void run(){
		Scanner input=new Scanner(System.in);
		int option=-1;
		String name,type;
		int weight;
		while(option!=0){
		System.out.println("0. exit");
		System.out.println("1.Insert aliment");
		System.out.println("2.Print reqs to file");
		
		option=input.nextInt();
		
		if(option==1){
			System.out.println("Insert type (zahar/faina/sare)");
			type=input.next();
			System.out.println("Insert price per kg ( X RON /kg)");
			weight=input.nextInt();
			System.out.println("Insert name");
			name=input.next();
			Aliment al=new Aliment(type,name,weight);
			this.cont.addAliment(al);
			
		}
		
		if(option==2){
			this.cont.printToFile();
		}
		}
		
	}

}
