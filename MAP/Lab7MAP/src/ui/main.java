package ui;
import javax.swing.JFrame;
import javax.swing.JLabel; 
import repository.RepositoryHashmap;
import controller.Controller;
import controller.Validator;

public class main extends JFrame {

	public static void main(String[] args) {
		
		RepositoryHashmap repo=new RepositoryHashmap();
		final Controller cont=new Controller(repo);
		ControllerObserver oc1=new ControllerObserver(cont);
		ControllerObserver2 oc2=new ControllerObserver2(cont);
		cont.addObserver(oc1);
		cont.addObserver(oc2);
		Validator v=new Validator();
		Console ui=new Console(cont,v);
		//ui.runMenu();
		cont.deleteObservers();
			
		javax.swing.SwingUtilities.invokeLater(new Runnable() {
			 public void run() {
				 Mainframe mf=new Mainframe(cont);
					mf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			 } });
		
		
		
		
		
		}

}
