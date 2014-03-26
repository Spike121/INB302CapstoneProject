package input;

import java.io.*;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

import persistence.Item;
import persistence.ItemUserPair;
import persistence.RatingsLookupTable;
import persistence.User;

public class InputTextReader {
	
	//private HashMap<String, User> users = new HashMap<String, User>();
	
	private String filePath; 
	private RatingsLookupTable lookupTable = new RatingsLookupTable();
			
	public InputTextReader( String filePath ){

		this.filePath = filePath;
	}
	
	public boolean readFromFile()
	{
		Scanner scanner = null;
		File f;
		try {
			f = new File(filePath);
			scanner = new Scanner(f);
			
		} catch (FileNotFoundException e) {
			System.out.println("Invalid file name/ file path");
			return false;	
		}
		
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
				
				User user = new User(userId);
				Item item = new Item(itemId);
				Integer rating = new Integer(ratingNum);
				
				ItemUserPair pair = new ItemUserPair(item, user);
				System.out.println(user.toString() + " " + item.toString() + " " + rating.toString());
				lookupTable.addPair(user, item, rating);
			}
			
			scanner.nextLine();			
		}
		
		return true;
	}

	public RatingsLookupTable getLookupTable() {
		return lookupTable;
	}
}
