package persistence;

import java.lang.invoke.MethodHandles.Lookup;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class RatingsLookupTable {

	private Map<String, Item> items = new HashMap<String, Item>();
	private Map<String, User> users = new HashMap<String, User>();
	
	private Map<ItemUserPair, Integer> ratingLookup = new HashMap<ItemUserPair, Integer>();
	
	public void addPair(User newUser, Item newItem, Integer rating)
	{
		ItemUserPair pair = new ItemUserPair(newItem, newUser);
		ratingLookup.put(pair, rating);
		
		//Items
		if(!items.containsKey(newItem))
			items.put(newItem.getId(),newItem);
		
		 Item existingItem = items.get(newItem.getId());
		 existingItem.addUser(newUser);
		 items.put(existingItem.getId(), existingItem);
		 
		 //Users
		 if(!users.containsKey(newUser))
				users.put(newUser.getId(),newUser);
			
		 User existingUser = users.get(newUser.getId());
		 existingUser.addItem(newItem);
		 users.put(existingUser.getId(), existingUser);
	}
	
	public float getAverageUserRating(User user)
	{
		List<ItemUserPair> pairs = users.get(user.getId()).getPairs();
		float rating = 0.0f;
		for(ItemUserPair pair : pairs)
			 rating += ratingLookup.get(pair);
		
		rating /= pairs.size();
		return rating;
	}
	
	public Map<User,Float> getAllUsersAverageRating()
	{
		Map<User,Float> averageRatings = new HashMap<User,Float>();
		for(User user : users.values())
			averageRatings.put(user, getAverageUserRating(user) );
		
		return averageRatings;
	}
}
