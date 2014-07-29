package iquest2java;
import java.util.Scanner;
import java.lang.StringBuilder;
public class main {
	
	public static void main(String[] args) {
		Scanner sc=new Scanner(System.in); 

		String vowels="aeiouAEIOU";
        String input = sc.nextLine();
        int i;
        StringBuilder shifted = new StringBuilder();
        StringBuilder cons = new StringBuilder();
        StringBuilder result = new StringBuilder();
        int shift = Character.getNumericValue(input.charAt(0));
        for (i = 0; i < input.length(); i++)
        {
            if(Character.isLetter(input.charAt(i)))
            {
                if (vowels.indexOf(input.charAt(i)) != -1)
                {

                    if (Character.isLowerCase(input.charAt(i))) 
                    	result.append(Character.toUpperCase(input.charAt(i)));
                    else result.append(Character.toLowerCase(input.charAt(i)));
                }
                else
                {
                   result.append('-');
                    cons.append(input.charAt(i));
                }
           }
        }

         int index, k = 0;
         for (i = 0; i < cons.length(); i++)
         {
             index = (i + shift) % cons.length();
             shifted.append(cons.charAt(index));
         }



         for (i = 0; i < result.length(); i++)
             if (result.charAt(i)=='-'){
                result.setCharAt(i, shifted.charAt(k));
                k++;
             }

         
         System.out.println(result);
       
	}

}



