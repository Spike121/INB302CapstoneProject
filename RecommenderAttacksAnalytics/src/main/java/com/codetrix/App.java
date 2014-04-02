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
		
    	RatingsLookupTable lookup = readInValuesFromTextInput();
    	exportValuesToDb(lookup);
    }
    
    public static RatingsLookupTable readInValuesFromTextInput()
    {
    	InputTextReader reader = new InputTextReader();
	    	
    	boolean readSuccesful;
    	do {
    		System.out.println("Enter filename (or enter for ratings.txt default) : ");
			Scanner in = new Scanner(System.in);			
			String fileName = in.nextLine();
			
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
    
    public static void exportValuesToDb(RatingsLookupTable lookup)
    {
    	LocalToDbFormatter.outputToDb(lookup);
    }
    
    public void getUserRatings(long userId)
    {
    	Session session = HibernateUtil.getSessionFactory().openSession();
    	Query query = session.createQuery("from DBUSerItemRating where userId = :id");
    	query.setParameter("id", String.valueOf(userId));
    	List list = query.list();
    }
}
