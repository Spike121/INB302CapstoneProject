package com.codetrix.entities.localpersistence;


import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class RatingsLookupTable {

	private Map<Long, Item> items = new TreeMap<Long, Item>();
	private Map<Long, User> users = new TreeMap<Long, User>();
	
	private Map<ItemUserPair, Integer> ratingLookup = new HashMap<ItemUserPair, Integer>();
	
	public void addPair(User newUser, Item newItem, Integer rating)
	{
		ItemUserPair pair = new ItemUserPair(newItem, newUser);
		ratingLookup.put(pair, rating);
		
		//Items
		if(!items.containsKey(newItem.getId()))
			items.put(newItem.getId(),newItem);
		
		 Item existingItem = items.get(newItem.getId());
		 existingItem.addUser(newUser);
		 items.put(existingItem.getId(), existingItem);
		 
		 //Users
		 if(!users.containsKey(newUser.getId()))
				users.put(newUser.getId(),newUser);
			
		 User existingUser = users.get(newUser.getId());
		 existingUser.addItem(newItem);
		 users.put(existingUser.getId(), existingUser);
	}
	
	public Map<ItemUserPair, Integer> getRatingsLookup()
	{
		return this.ratingLookup;
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
		Map<User,Float> averageRatings = new TreeMap<User,Float>();
		for(User user : users.values())
			averageRatings.put(user, getAverageUserRating(user) );
		
		
		return averageRatings;
	}
}
