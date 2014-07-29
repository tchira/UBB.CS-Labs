package examenJava;

import Controller.Controller;
import Repository.ARepository;
import UInterface.UserConsole;
import domain.Aliment;

public class main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ARepository<Aliment> repo=new ARepository<Aliment>();
		Controller cont=new Controller(repo);
		UserConsole cons=new UserConsole(cont);
		cons.run();
		

	}

}
