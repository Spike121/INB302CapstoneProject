package userInput;

import java.io.Console;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;

import persistence.RatingsLookupTable;
import persistence.User;

import input.InputTextReader;

public class Controller {

	
	private static RatingsLookupTable lookupTable;
	
	public static void main(String[] args) {
		
		InputTextReader reader;
		
		do
		{
			System.out.println("Enter filename: ");
			Scanner in = new Scanner(System.in);
			String fileName = in.nextLine();
			
			reader = new InputTextReader(fileName);
			
		} while(!reader.readFromFile());
		
		lookupTable = reader.getLookupTable();
		
		boolean exit = false;
		do
		{
			System.out.println("Select command: ");
			Scanner in = new Scanner(System.in);
			String input = in.next();
			switch(input)
			{
				case "1": printUsersAverageRating();
					break;
				default:
					printUsersAverageRating();
					
			}
				
		}
		while(!exit);
	}
	
	public static void printUsersAverageRating()
	{
		Map<User,Float> ratings = lookupTable.getAllUsersAverageRating();
		for(Entry<User,Float> entry : ratings.entrySet())
		{
			System.out.println("User: " + entry.getKey().getId() + " Average: " + entry.getValue().toString());
		}
	}

}
