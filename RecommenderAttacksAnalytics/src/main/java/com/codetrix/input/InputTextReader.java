package com.codetrix.input;

import java.io.*;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

import com.codetrix.entities.localpersistence.Item;
import com.codetrix.entities.localpersistence.ItemUserPair;
import com.codetrix.entities.localpersistence.RatingsLookupTable;
import com.codetrix.entities.localpersistence.User;



public class InputTextReader {
	
	//private HashMap<String, User> users = new HashMap<String, User>();
	
	private int invalidEntriesCount = 0;
	private int totalEntryCount = 0;
	
	private RatingsLookupTable lookupTable = new RatingsLookupTable();
			
	public InputTextReader() { }
	
	public int getInvalidEntriesCount()
	{
		return invalidEntriesCount;
	}
	
	public boolean readFromFile(String filePath) throws FileNotFoundException
	{
		Scanner scanner = null;
		File f = new File(filePath);
		scanner = new Scanner(f);
	
		invalidEntriesCount = 0;
		totalEntryCount = 0;
		
		System.out.println("Starting batch reading...");
		
		while(scanner.hasNextLine())
		{
			String firstElem = scanner.next();
			
			// TODO: Switch to getLine preview with regex
			if(!firstElem.equals("%") )
			{
				String userId = firstElem;
				String itemId = scanner.next();
				String ratingNum = scanner.next();
				
				//users.containsKey(userId) ? users.get(userId) : users.get(userId) ;
				try{
					User user = new User(Long.parseLong(userId));
					Item item = new Item(Long.parseLong(itemId));
					Integer rating = new Integer(ratingNum);
					
					ItemUserPair pair = new ItemUserPair(item, user);
					//System.out.println(user.toString() + " " + item.toString() + " " + rating.toString());
					lookupTable.addPair(user, item, rating);
				} catch(NumberFormatException e){
					invalidEntriesCount++;
				}
			}
			
			totalEntryCount++;
			scanner.nextLine();			
		}
		
		System.out.println("Done.");
		System.out.println(totalEntryCount + " total entries read. " + invalidEntriesCount + " invalid entries.");
		return true;
	}

	public RatingsLookupTable getLookupTable() {
		return lookupTable;
	}
}
