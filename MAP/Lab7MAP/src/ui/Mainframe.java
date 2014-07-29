package ui;


import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.util.Vector;

import javax.swing.ButtonGroup;
import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.ListSelectionModel;

import controller.Controller;
import domain.GraduateStudent;
import domain.PhdStudent;
import domain.Student;
import domain.UndergraduateStudent;



public class Mainframe extends JFrame{
	
	protected JList slist;
	protected DefaultListModel lmodel;
	protected Controller c;
	protected JButton clrButton;
	protected JRadioButton l5Radio,g5Radio,a10Radio;
	Vector<String> students;
	Container contentpane;
	protected JTextField textField;
	
	public Mainframe(Controller cont){
		this.setResizable(false);
		
		students=new Vector<String>(); // all students in string format
		this.c=cont;
		
		//create radio buttons for showing students by different criteria, group them
		l5Radio=new JRadioButton("Average less than 5");
		l5Radio.setActionCommand("less5");
		g5Radio=new JRadioButton("Average greater than 5");
		g5Radio.setActionCommand("greater5");
		a10Radio=new JRadioButton("Average equals 10");
		a10Radio.setActionCommand("equal10");
		ButtonGroup group=new ButtonGroup();
		group.add(l5Radio);
		group.add(g5Radio);
		group.add(a10Radio);
		
		
		//Create a panel for the radio buttons, set their action with rListener
		RadioListener rListener=new RadioListener();
		l5Radio.addActionListener(rListener);
		g5Radio.addActionListener(rListener);
		a10Radio.addActionListener(rListener);
		JPanel rPanel=new JPanel();
		rPanel.setLayout(new GridLayout(0,1));
		rPanel.add(l5Radio);
		rPanel.add(g5Radio);
		rPanel.add(a10Radio);
		
		
		
		//
		contentpane=getContentPane(); //get the main content panel
		contentpane.setLayout(new FlowLayout());
		lmodel=new DefaultListModel();
		refreshModel(); //fill model with students (function defined below)
		slist=new JList(lmodel); //create list from model
		slist.setSelectedIndex(0);
		slist.setSelectionMode(ListSelectionModel.SINGLE_SELECTION); //set list properties
		JScrollPane scr=new JScrollPane(slist); //create scroll panel with list so list can be scrollable
		contentpane.add(scr,BorderLayout.EAST); //add the list to the main window
		this.setSize(1000,500);
		this.setVisible(true);
		clrButton=new JButton("Show all");
		clrButton.addActionListener(new clearListener()); // configure new button to refresh the list
		group.add(clrButton);
		rPanel.add(clrButton);
		contentpane.add(rPanel,BorderLayout.WEST);
		
		
		// Add student part (label, textfield and an Add Button)
		JPanel addPanel=new JPanel();
		addPanel.setLayout(new GridLayout(0,1));
		JLabel stlabel=new JLabel("Insert student data here,separated by spaces");
		JButton addButton=new JButton("Attempt to add student");
		addListener aList=new addListener();
		addButton.addActionListener(aList);
		textField=new JTextField(30);
		addPanel.add(stlabel);
		addPanel.add(textField);
		addPanel.add(addButton);
		this.add(addPanel);
		this.pack();
		
		
}
	
	public static void showGUI(Controller cntrl){
		Mainframe mf=new Mainframe(cntrl);
		mf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		
	}
	
	private void refreshModel(){
		lmodel.clear();
		for(Student s:c.getAll())
			lmodel.addElement(s.toString());
	}
	
	
	class clearListener implements ActionListener{
		public void actionPerformed(ActionEvent e){
			refreshModel();
		}
	}
	
	class RadioListener implements ActionListener{
		//fills the list according to what radio button is selected
		public void actionPerformed(ActionEvent e){
			lmodel.clear();
			if("less5".equals(e.getActionCommand())){
				for(Student s:c.getAll())
					if(s.getAverage()<5){
						lmodel.addElement(s.toString());
					}
			}
			
			
			if("greater5".equals(e.getActionCommand()))
				{for(Student s:c.getAll())
					if(s.getAverage()>=5)
						lmodel.addElement(s.toString());
				}
			
			else 
				if("equals10".equals(e.getActionCommand()))
					for(Student s:c.getAll())
						if(s.getAverage()==10)
							lmodel.addElement(s.toString());
				
		}
	}
	
	class addListener implements ActionListener{
		//uses the function used in reading data from a file to take the text from the textbox and split it by the " " character, then tries to create
		public void actionPerformed(ActionEvent e){
			String line=textField.getText();
					String[] tokens=line.split(" ");
					int length=tokens.length;
					switch(length){
						case 3:
							Student s1=new Student(Integer.parseInt(tokens[0]),tokens[1],Integer.parseInt(tokens[2]));
							c.repo.addObject(s1);
							break;
						case 4:
							UndergraduateStudent s2=new UndergraduateStudent(Integer.parseInt(tokens[0]),tokens[1],Integer.parseInt(tokens[2]),Integer.parseInt(tokens[3]));
							c.repo.addObject(s2);
							break;
						case 6:
							GraduateStudent s3=new GraduateStudent(Integer.parseInt(tokens[0]),tokens[1],tokens[2],Integer.parseInt(tokens[3]),Integer.parseInt(tokens[4]),Integer.parseInt(tokens[5]));
							c.repo.addObject(s3);
							break;
						case 7:
							PhdStudent s4=new PhdStudent(Integer.parseInt(tokens[0]),tokens[1],tokens[2],tokens[3],Integer.parseInt(tokens[4]),Integer.parseInt(tokens[5]),Integer.parseInt(tokens[6]));
							c.repo.addObject(s4);
							break;
					}
			refreshModel();
			
		}
			
	}
	
	
}
	
	
	
	
	

	
	

