package com.codetrix;

import java.io.FileNotFoundException;
import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;

import com.codetrix.entities.database.DBUser;
import com.codetrix.entities.localpersistence.RatingsLookupTable;
import com.codetrix.input.InputTextReader;
import com.codetrix.output.LocalToDbFormatter;
import com.codetrix.util.HibernateUtil;

public class App 
{
    public static void main( String[] args )
    {
    	System.out.println("Maven + Hibernate + Oracle");
    	
    	boolean exit = false;
		do
		{
			System.out.println("Select command: ");
			Scanner in = new Scanner(System.in);
			String input = in.next();
			switch(input)
			{
				case "1": readAndExportToDb();
					break;
				case "2": getUserAverageRating();
					break;
				default:										
			}
				
		}
		while(!exit);
		
    	RatingsLookupTable lookup = readInValuesFromTextInput();
    	exportValuesToDb(lookup);
    }
    
    public static void readAndExportToDb()
    {
    	
    }
    
    public static RatingsLookupTable readInValuesFromTextInput()
    {
    	InputTextReader reader = new InputTextReader();
	    	
    	boolean readSuccesful;
    	do {
    					
			String fileName = promptWithAnswer("Enter filename (or enter for ratings.txt default) : ");
			
			if(fileName.isEmpty())
				fileName = "ratings.txt";
			
    		readSuccesful = false;    		
	    	try {
	    		readSuccesful = reader.readFromFile(fileName);
			} catch (FileNotFoundException e) {
				System.out.println("Invalid file name/path (" + fileName + ")");
				readSuccesful = false;
			}
	    	
    	} while(!readSuccesful);   
    	
    	return reader.getLookupTable();
    }
    
    public static String promptWithAnswer(String str)
    {
    	System.out.println(str);
		Scanner in = new Scanner(System.in);			
		return in.nextLine();
    }
    
    public static void exportValuesToDb(RatingsLookupTable lookup)
    {
    	LocalToDbFormatter.outputToDb(lookup);
    }
    
    public static void getUserAverageRating()
    {
    	long userId = Long.parseLong(promptWithAnswer("Input user number: "));
    	Session session = HibernateUtil.getSessionFactory().openSession();
    	Query query = session.createQuery("from DBUser where userId = :id");
    	query.setParameter("id", userId);
    	List<DBUser> list = query.list();
    	DBUser user = list.get(0);
    	System.out.println("Average for user " + user.getUserId() + " : " + user.getItemRatingsAverage());
    }
}
